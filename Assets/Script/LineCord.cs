using System;
using System.Collections.Generic;

namespace Assets.Script
{
    /// <summary>
    /// ライン座標
    /// </summary>
    internal class LineCord
    {
        private int x;
        private int y;

        public LineCord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            LineCord other = obj as LineCord;
            return other.x == x && other.y == y;
        }

        public override int GetHashCode()
        {
            return x^y;
        }

        /// <summary>
        /// ラインドット一覧を生成する
        /// </summary>
        /// <param name="sCord">点1</param>
        /// <param name="eCord">点2</param>
        /// <param name="width">幅</param>
        /// <returns>ラインドット一覧</returns>
        public static List<Tuple<int, int>> CreateLineDotList( LineCord sCord, LineCord eCord, int width)
        {
            List<Tuple<int, int>> dstList = new List<Tuple<int, int>>();

            int i;
            int E;
            int x = sCord.x;
            int y = sCord.y;

            /* 二点間の距離 */
            int dx = eCord.x > sCord.x ? eCord.x - sCord.x : sCord.x - eCord.x;
            int dy = eCord.y > sCord.y ? eCord.y - sCord.y : sCord.y - eCord.y;

            /* 二点の方向 */
            int sx = eCord.x > sCord.x ? 1 : -1;
            int sy = eCord.y > sCord.y ? 1 : -1;

            CircleDotsFactory circleDotsFactory = new CircleDotsFactory();
            CircleDots circleDots = circleDotsFactory.Create(width);

            /* 傾きが1より小さい場合 */
            if (dx > dy)
            {
                E = -dx;
                for (i = 0; i <= dx; i++)
                {
                    dstList.AddRange(circleDots.MoveCircleDots(x, y));
                    x += sx;
                    E += 2 * dy;
                    if (E >= 0)
                    {
                        y += sy;
                        E -= 2 * dx;
                    }
                }
                return dstList;
            }

            /* 傾きが1以上の場合 */
            E = -dy;
            for (i = 0; i <= dy; i++)
            {
                dstList.AddRange(circleDots.MoveCircleDots(x, y));
                y += sy;
                E += 2 * dx;
                if (E >= 0)
                {
                    x += sx;
                    E -= 2 * dy;
                }
            }
            return dstList;
        }
    }
}

