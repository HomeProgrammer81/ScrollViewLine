using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script
{
    /// <summary>
    /// 円の点一覧
    /// </summary>
    class CircleDots
    {
        List<Tuple<int, int>> list;

        public CircleDots(List<Tuple<int, int>> list)
        {
            this.list = list;
        }

        public List<Tuple<int, int>> MoveCircleDots(int x, int y)
        {
            List<Tuple<int, int>> dst = list.Select(dot =>
            {
                int dx = dot.Item1 + x;
                int dy = dot.Item2 + y;

                return new Tuple<int, int>(dx, dy);
            }).ToList();
            return dst;
        }
    }
}
