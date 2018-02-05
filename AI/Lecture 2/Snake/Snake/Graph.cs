using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Graph
    {
        public static double INFINITY = double.MaxValue;
        public static int LENGTH = 24;
        public List<Vertex> result = new List<Vertex>();

        public void AddEdge(string sourceName, string destName, double cost)
        {
            Vertex v = GetVertex(sourceName);
            Vertex w = GetVertex(destName);
            v.adj.Add(new Edge(w, cost));
        }

        private Vertex GetVertex(string vertexName)
        {
            Vertex v = null;
            try
            {
                v = VertexMap[vertexName];
            }
            catch { }

            if (v == null)
            {
                v = new Vertex(vertexName);
                VertexMap.Add(vertexName, v);
            }
            return v;
        }

        private void ClearAll()
        {
            foreach(Vertex v in VertexMap.Values)
            {
                v.Reset();
            }
        }

        public void Hamiltonian()
        {
            List<Vertex> path = new List<Vertex>();
            path.Add(GetVertex("A"));
            Hamiltonian("A", path);
        }

        private void Hamiltonian(string start, List<Vertex> path)
        {
            Vertex v = GetVertex(start);
            List<Vertex> newPath = new List<Vertex>(path);
            if (v.adj.Count == 0)
            {
                if (newPath.Count > result.Count)
                    result = new List<Vertex>(newPath);
                return;
            }
                

            foreach(Edge ad in v.adj)
            {
                if(newPath.Select(x => x).Where(x => x.name == ad.dest.name) == null)
                {
                    Hamiltonian(ad.dest.name, newPath);
                } 
            }
        }

        public Dictionary<string, Vertex> VertexMap = new Dictionary<string, Vertex>();
    }
}
