using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Script
{
    internal class LineCords
    {
        private List<LineCord> list = new List<LineCord>();

        public LineCords(List<LineCord> list )
        {
            this.list = list;
        }

        public List<Tuple<int, int>> CreateLineDotList( int width )
        {
            if(list.Count <= 1)
            {
                return new List<Tuple<int, int>>();
            }

            List<Tuple<int, int>> dstList = new List<Tuple<int, int>>();

            for( int i=1; i<list.Count; i++)
            {
                LineCord startCord = list[i - 1];
                LineCord endCord = list[i];
                dstList.AddRange(LineCord.CreateLineDotList(startCord, endCord, width));
            }

            return dstList;
        }
    }

    internal class LineCord
    {
        private int x;
        private int y;

        public LineCord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static List<Tuple<int, int>> CreateLineDotList( LineCord sCord, LineCord eCord, int width)
        {
            List<Tuple<int, int>> dstList = new List<Tuple<int, int>>();

            int i;
            int E;
            int x = sCord.x;
            int y = sCord.y;

            /* ìÒì_ä‘ÇÃãóó£ */
            int dx = eCord.x > sCord.x ? eCord.x - sCord.x : sCord.x - eCord.x;
            int dy = eCord.y > sCord.y ? eCord.y - sCord.y : sCord.y - eCord.y;

            /* ìÒì_ÇÃï˚å¸ */
            int sx = eCord.x > sCord.x ? 1 : -1;
            int sy = eCord.y > sCord.y ? 1 : -1;

            CircleDotsFactory circleDotsFactory = new CircleDotsFactory();
            CircleDots circleDots = circleDotsFactory.Create(width);

            /* åXÇ´Ç™1ÇÊÇËè¨Ç≥Ç¢èÍçá */
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

            /* åXÇ´Ç™1à»è„ÇÃèÍçá */
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

        private class CircleDots
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

        private class CircleDotsFactory
        {
            public CircleDots Create(int width)
            {
                List<Tuple<int, int>> dst = new List<Tuple<int, int>>();

                // îºåa
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
}

