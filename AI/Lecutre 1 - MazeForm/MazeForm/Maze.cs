using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeForm
{
    class Maze
    {
        public DisjointSets Set;
        public List<Tuple<int, int>> Edges;
        public List<Tuple<int, int>> Walls;

        private int r;
        private int c;

        public Maze(int rows, int collumns)
        {
            this.r = rows;
            this.c = collumns;
            this.Walls = new List<Tuple<int, int>>();
            this.Set = new DisjointSets(CalculateNumberOfElements(rows, collumns));
            Console.Clear();
            Console.WriteLine("Calculating edges...");
            this.Edges = CalculateEdges(rows, collumns);
            Console.Clear();
            Console.WriteLine("Genering maze, progress: 0%");
            Helper.SetWalls(ref this.Walls, rows, collumns);
            GenerateMaze();
        }

        private void CalculateAndPrintProgress()
        {
            //Console.Clear();
            float temp = Walls.Count / ((r * c) - (r + c));
            Console.WriteLine("Progress: {0}%", (temp * 100));
        }

        private int CalculateNumberOfElements(int rows, int collumns)
        {
            return rows * collumns;
        }

        private List<Tuple<int, int>> CalculateEdges(int rows, int collumns)
        {
            List<Tuple<int, int>> TempList = new List<Tuple<int, int>>();
            int elements = rows * collumns;
            // Bekijk voor elk element zijn buren
            for (int i = 0; i < rows * collumns; i++)
            {
                // Bekijk of element rechter buurman heeft
                if (i % collumns != collumns - 1 && i <= elements)
                    TempList.Add(new Tuple<int, int>(i, i + 1));

                // Bekijk of element onder buurman heeft
                if (i + collumns < elements)
                    TempList.Add(new Tuple<int, int>(i, i + collumns));
            }
            return TempList;
        }

        private void GenerateMaze()
        {
            Random rnd = new Random();

            while (Set.Size > 1)
            {
                // Selecteer random edge
                int r = rnd.Next(Edges.Count);
                // Neem over en verwijder
                Tuple<int, int> tempEdge = Edges[r];
                Edges.RemoveAt(r);
                int u = Set.Find(tempEdge.Item1);
                int v = Set.Find(tempEdge.Item2);

                if (u != v)
                {
                    Set.Union(u, v);
                    this.Set.Size--;
                    this.Walls.Remove(tempEdge);
                    
                }

                else
                {
                    //this.Walls.Add(tempEdge);
                    CalculateAndPrintProgress();
                }
                    
            }

            for (int i = 0; i < Edges.Count; i++)
            {
                this.Walls.Add(Edges[i]);
                CalculateAndPrintProgress();
            }
            Console.WriteLine("Progress: 100%");
        }
    }
}
