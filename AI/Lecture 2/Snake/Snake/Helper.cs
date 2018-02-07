using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Helper
    {
        public static Dictionary<string, Tuple<int, int>> ConvertMapToCoordinates(Dictionary<string, Vertex> map)
        {
            Dictionary<string, Tuple<int, int>> Coordinates = new Dictionary<string, Tuple<int, int>>();
            int cell = 0;
            var orderedMap = map.OrderBy(x => x.Key);
            foreach (var item in orderedMap)
            {
                Coordinates.Add(item.Key, new Tuple<int, int>(cell % 5, cell / 5));
                cell++;
            }
            return Coordinates;
        }

        public static List<Tuple<Tuple<int, int>, Tuple<int, int>>> CoordinatesOfEdges(Dictionary<string, Vertex> map)
        {
            Dictionary<string, Tuple<int, int>> Coor = ConvertMapToCoordinates(map);
            List<Tuple<Tuple<int, int>, Tuple<int, int>>> edges = new List<Tuple<Tuple<int, int>, Tuple<int, int>>>();
            foreach(var v in map)
            {
                foreach(var e in v.Value.adj)
                {
                    Tuple<int, int> FirstXY = new Tuple<int, int>(Coor[v.Key].Item1, Coor[v.Key].Item2);
                    Tuple<int, int> SecondXY = new Tuple<int, int>(Coor[e.dest.name].Item1, Coor[e.dest.name].Item2);
                    Tuple<Tuple<int, int>, Tuple<int, int>> EdgeCoor = new Tuple<Tuple<int, int>, Tuple<int, int>>(FirstXY, SecondXY);
                    edges.Add(EdgeCoor);
                }
            }
            return edges;
        }
    }
}
