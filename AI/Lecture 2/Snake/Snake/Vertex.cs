using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Vertex
    {
        public string name;
        public List<Edge> adj;
        public List<Vertex> Path;

        public Vertex(string nm)
        {
            name = nm;
            adj = new List<Edge>();
            Path = new List<Vertex>();
        }
    }
}
