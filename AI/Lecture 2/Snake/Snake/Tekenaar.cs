using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Tekenaar
    {

        private const int _OFFSET = 50;


        /*
         * Dots 
         */
        private const int _DOTSIZE = 5;
        private static Pen _DotPen = new Pen(Color.Black, 5);


        /*
         * Grid lines
         */
        private static Pen _GridPen = new Pen(Color.Black, 1);

        /*
         * Path line
         */
        private static Pen _PathPen = new Pen(Color.Red, 4);
        private static Pen _PathStartPen = new Pen(Color.Pink, 5);

        public static void DrawGrid(Graphics g, Dictionary<string, Vertex> dictionary)
        {
            // Eerst all punten tekenen
            var map = Helper.ConvertMapToCoordinates(dictionary);
            foreach(var x in map)
            {
                g.DrawEllipse(_DotPen, (x.Value.Item1 * _OFFSET) + _OFFSET , (x.Value.Item2 * _OFFSET) + _OFFSET, _DOTSIZE, _DOTSIZE);
            }

            // Edges tekenen
            var edges = Helper.CoordinatesOfEdges(dictionary);
            foreach(var edge in edges)
            {
                int x1 = (edge.Item1.Item1 * _OFFSET) + _OFFSET;
                int x2 = (edge.Item2.Item1 * _OFFSET) + _OFFSET;
                int y1 = (edge.Item1.Item2 * _OFFSET) + _OFFSET;
                int y2 = (edge.Item2.Item2 * _OFFSET) + _OFFSET;
                g.DrawLine(_GridPen, x1, y1, x2, y2);
            }
        }
        
        public static void DrawPath(Graphics g, List<string> path, Dictionary<string, Vertex> map)
        {
            var coor = Helper.ConvertMapToCoordinates(map);

            for(int i = 0; i < path.Count && i + 1 < path.Count; i++)
            {
                int x1 = (coor[path[i]].Item1 * _OFFSET) + _OFFSET;
                int y1 = (coor[path[i]].Item2 * _OFFSET) + _OFFSET;
                int x2 = (coor[path[i + 1]].Item1 * _OFFSET) + _OFFSET;
                int y2 = (coor[path[i + 1]].Item2 * _OFFSET) + _OFFSET;
                if (i == 0)
                    g.DrawLine(_PathStartPen, x1, y1, x2, y2);
                else
                    g.DrawLine(_PathPen, x1, y1, x2, y2);
                Thread.Sleep(7);
            }
        }
    }
}
