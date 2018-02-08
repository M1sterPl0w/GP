using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeForm
{
    class MazeSolver
    {
        private int rows;
        private int columns;
        private List<Tuple<int, int>> Walls;
        private bool solved;
        private int numberOfElem;

        public List<int> Result { get; set; }
        
        public void Solve(int rows, int columns, List<Tuple<int, int>> Walls)
        {
            this.rows = rows;
            this.columns = columns;
            this.Walls = Walls;
            this.solved = false;
            List<int> Path = new List<int>();
            this.Result = new List<int>();
            this.numberOfElem = rows * columns; 
            this.Solve(Path, 0);
            Console.WriteLine("done");
        }

        private void Solve(List<int> path, int elem)
        {
            List<int> newPath = new List<int>(path);
            newPath.Add(elem);

            // Is maze opgelost?
            if(elem == (rows * columns) - 1)
            {
                solved = true;
                Result = new List<int>(newPath);
                return;
            }

            // Kan ik naar rechts?
            if (elem / columns == (elem + 1) / columns)
                if(!Walls.Any(x => (x.Item1 == elem || x.Item2 == elem) && (x.Item1 == elem + 1 || x.Item2 == elem + 1)))
                    if(elem + 1 < numberOfElem)
                        if(!newPath.Contains(elem + 1))
                            if(!solved)
                                Solve(newPath, elem + 1);
                    

            // Kan ik naar beneden?
            if (elem + columns < numberOfElem)
                if (!Walls.Any(x => (x.Item1 == elem || x.Item2 == elem) && (x.Item1 == elem + columns || x.Item2 == elem + columns)))
                    if (!newPath.Contains(elem + columns))
                        if(!solved)
                            Solve(newPath, elem + columns);

                    
            // Kan ik naar links?
            if (elem / columns == (numberOfElem - 1) / columns)
                if (!Walls.Any(x => (x.Item1 == elem || x.Item2 == elem) && (x.Item1 == elem - 1 || x.Item2 == elem - 1)))
                    if(elem - 1 > 0)
                        if(!newPath.Contains(elem - 1))
                            if(!solved)
                                Solve(newPath, elem - 1);

            // Kan ik naar boven?
            if(elem - columns > 0)
                if (!Walls.Any(x => (x.Item1 == elem || x.Item2 == elem) && (x.Item1 == elem - columns || x.Item2 == elem - columns)))
                    if(!newPath.Contains(elem - columns))
                        if(!solved)
                            Solve(newPath, elem - columns);
        }
    }
}
