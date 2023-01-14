using System;
using System.Collections.Generic;

namespace Assets.Script
{
    /// <summary>
    /// 円の点一覧ファクトリー
    /// </summary>
    class CircleDotsFactory
    {
        public CircleDots Create(int width)
        {
            List<Tuple<int, int>> dst = new List<Tuple<int, int>>();

            // 半径
            int r = width / 2;

            for (int y = -r; y <= r; y++)
            {
                for (int x = -r; x <= r; x++)
                {
                    if (x * x + y * y <= r * r)
                    {
                        dst.Add(new Tuple<int, int>(x, y));
                    }
                }
            }
            return new CircleDots(dst);
        }
    }
}
