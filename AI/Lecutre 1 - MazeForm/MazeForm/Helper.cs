using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeForm
{
    class Helper
    {
        public static void SetRoots(ref int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = -1;
            }
        }

        public static void SetWalls(ref List<Tuple<int, int>> walls, int rows, int collumn)
        {
            int totalElem = rows * collumn;
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < collumn; j++)
                {
                    if(j + 1 < collumn)
                        walls.Add(new Tuple<int, int>(j + (i * collumn), j + 1 + (i * collumn)));
                    if (j + (i * collumn) + collumn < totalElem)
                        walls.Add(new Tuple<int, int>(j + (i * collumn), j + collumn + (i * collumn)));
                }
            }
        }
        public static void PrintMaze(Graphics g, int rows, int collumns, int OFFSET, List<Tuple<int, int>> Walls)
        {
            Pen p = new Pen(Color.Black, 1);
            // Eerst border tekenen
            g.DrawRectangle(p, 0, 0, collumns * OFFSET, rows * OFFSET);

            Console.WriteLine("Totaal aantal walls: {0}", Walls.Count);
            int counter = 0;

            // Loop door elk element
            for (int i = 0; i < rows * collumns; i++)
            {
                int row = i / collumns;
                // Kijk of nog een muur is
                for (int j = 0; j < Walls.Count; j++)
                {
                    if (Walls[j].Item1 == i)
                    {
                        //Is het rechts?
                        if (Walls[j].Item2 == i + 1)
                        {
                            g.DrawLine(p, new Point(OFFSET * (i % collumns) + OFFSET, OFFSET * row), new Point(OFFSET * (i % collumns) + OFFSET, (OFFSET * row) + OFFSET));
                        }
                        //Dan moet het wel onder zijn
                        else
                        {
                            g.DrawLine(p, new Point(OFFSET * (i % collumns), OFFSET * row + OFFSET), new Point(OFFSET * (i % collumns) + OFFSET, OFFSET * row + OFFSET));
                        }

                        counter++;
                        Walls.RemoveAt(j);
                        j--;
                    }
                }
            }
            PrintEntranceAndExit(g, OFFSET, rows - 1, collumns - 1);
        }

        public static void PrintSolution(Graphics g, int OFFSET, int col, int row, List<int> sol)
        {
            Pen p = new Pen(Color.Red, OFFSET);
            foreach(int s in sol)
            {
                int x1 = (s % col) * OFFSET + (OFFSET / 2);
                int y1 = (s / col) * OFFSET;
                int x2 = (s % col) * OFFSET + (OFFSET / 2);
                int y2 = ((s / col) * OFFSET) + OFFSET;
                g.DrawLine(p, x1, y1, x2, y2);
            }
        }

        public static void PrintEntranceAndExit(Graphics g, int OFFSET, int rows, int collumns)
        {
            Pen p = new Pen(Color.White, 1);
            // Print entrance
            g.DrawLine(p, new Point(0, 0), new Point(0, OFFSET));

            // Print exit
            g.DrawLine(p, new Point(collumns * OFFSET + OFFSET, rows * OFFSET), new Point(collumns * OFFSET + OFFSET, rows * OFFSET + OFFSET));
        }
    }
}
