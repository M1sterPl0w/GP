using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Graph
    {
        public List<string> result = new List<string>();

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

        public void Hamiltonian(string start)
        {
            List<string> path = new List<string>();
            Hamiltonian(start, path);
        }

        private void Hamiltonian(string start, List<string> path)
        {
            Vertex v = GetVertex(start);
            List<string> newPath = new List<string>(path);
            newPath.Add(v.name);
            bool noNextMoves = true;
            foreach(Edge ad in v.adj)
            {
                if(newPath.Select(x => x).Where(x => x == ad.dest.name).FirstOrDefault() == null)
                {
                    Hamiltonian(ad.dest.name, newPath);
                    noNextMoves = false;
                } 
            }
            if(noNextMoves && path.Count > result.Count)
            {
                this.result = new List<string>(newPath);
            }
        }

        public Dictionary<string, Vertex> VertexMap = new Dictionary<string, Vertex>();
    }
}
