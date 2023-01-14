using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Script
{
    /// <summary>
    /// ライン座標一覧
    /// </summary>
    internal class LineCords
    {
        private List<LineCord> list = new List<LineCord>();

        public LineCords(List<LineCord> list)
        {
            this.list = list;
        }

        /// <summary>
        /// 先端と後端をつなげたラインドットリストを生成する
        /// </summary>
        /// <param name="width">線の幅</param>
        /// <returns>先端と後端をつなげたラインドットリスト</returns>
        public List<Tuple<int, int>> CreateLineDotListCircle(int width)
        {
            // 点の数が3つ以上が対象
            if (list.Count <= 2)
            {
                return new List<Tuple<int, int>>();
            }

            List<Tuple<int, int>> dstList = new List<Tuple<int, int>>();
            for (int i = 1; i < list.Count; i++)
            {
                LineCord startCord = list[i - 1];
                LineCord endCord = list[i];
                dstList.AddRange(LineCord.CreateLineDotList(startCord, endCord, width));
            }

            // 先端と後端のライン
            dstList.AddRange(LineCord.CreateLineDotList(list[list.Count - 1], list[0], width));

            // 重複を消去する
            dstList = dstList.Distinct().ToList();

            return dstList;
        }
    }
}
