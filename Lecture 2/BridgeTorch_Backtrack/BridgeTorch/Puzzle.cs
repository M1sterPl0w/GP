using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BridgeTorch
{
    public class Puzzle
    {
        private List<int> LeftSide { get; set; }
        private List<int> RightSide { get; set; }
        // From right to left is true;
        // From left to right is false;
        private const int _Time = 30;
        public int AmountOfSolutions { get; set; }

        public Puzzle()
        {
            Reset();
        }

        private void Reset()
        {
            this.LeftSide = new List<int>();
            this.RightSide = new List<int>() { 1, 3, 6, 8, 12 };
            AmountOfSolutions = 0;
        }

        public void Solve()
        {
            Stopwatch t = new Stopwatch();
            t.Start();
            List<Tuple<int, int>> Moves = PossibleMovesToLeft(this.RightSide);
            Solve(new List<Tuple<int, int>>(), this.LeftSide, this.RightSide, true);
            Console.WriteLine("Time: {0}", t.ElapsedMilliseconds);
        }

        public void Solve(List<Tuple<int, int>> Moves, List<int> left, List<int> right, bool direction)
        {
            if(right.Count == 0)
            {
                CheckAndPrint(Moves);
                return;
            }

            // Backtracking
            if (AboveTime(Moves))
                return;

            // Rechts naar Links
            if (direction)
            {
                List<Tuple<int, int>> PossibleMoves = PossibleMovesToLeft(right);
                foreach(Tuple<int, int> move in PossibleMoves)
                {
                    List<int> NewLeft = new List<int>(left);
                    List<int> NewRight = new List<int>(right);
                    NewLeft.Add(move.Item1);
                    NewLeft.Add(move.Item2);
                    NewRight.Remove(move.Item1);
                    NewRight.Remove(move.Item2);
                    List<Tuple<int, int>> UpdatedMove = new List<Tuple<int, int>>(Moves);
                    UpdatedMove.Add(move);
                    Solve(UpdatedMove, NewLeft, NewRight, false);
                }
            }
            else
            {
                List<Tuple<int, int>> PossibleMoves = PossibleMovesToRight(left);
                foreach (Tuple<int, int> move in PossibleMoves)
                {
                    List<int> NewLeft = new List<int>(left);
                    List<int> NewRight = new List<int>(right);
                    NewLeft.Remove(move.Item1);
                    NewRight.Add(move.Item1);
                    List<Tuple<int, int>> UpdatedMove = new List<Tuple<int, int>>(Moves);
                    UpdatedMove.Add(move);
                    Solve(UpdatedMove, NewLeft, NewRight, true);
                }
            }

        }

        private List<Tuple<int, int>> PossibleMovesToLeft(List<int> side)
        {
            List<Tuple<int, int>> TempList = new List<Tuple<int, int>>();
            for(int i = 0; i < side.Count; i++)
            {
                for(int j = i + 1; j < side.Count; j++)
                {
                    TempList.Add(new Tuple<int, int>(side[i], side[j]));
                }
            }
            return TempList;
        }

        private List<Tuple<int, int>> PossibleMovesToRight(List<int> side)
        {
            List<Tuple<int, int>> TempList = new List<Tuple<int, int>>();
            for(int i = 0; i < side.Count; i++)
            {
                TempList.Add(new Tuple<int, int>(side[i], 0));
            }
            return TempList;
        }

        private void CheckAndPrint(List<Tuple<int, int>> moves)
        {
            int totalTime = 0;
            foreach (Tuple<int, int> move in moves)
            {
                if (move.Item1 > move.Item2)
                    totalTime += move.Item1;
                else
                    totalTime += move.Item2;
            }

            if(totalTime < _Time)
            {
                Console.WriteLine("------------");

                foreach (Tuple<int, int> move in moves)
                {
                    if (move.Item2 != 0)
                        Console.WriteLine("<-- person@speed {0} + person@speed {1}", move.Item1, move.Item2);
                    else
                        Console.WriteLine("--> person@speed {0}", move.Item1);
                }
                Console.WriteLine("------------");
                this.AmountOfSolutions++;
            }
        }

        private bool AboveTime(List<Tuple<int, int>> Moves)
        {
            int totalTime = 0;
            foreach(Tuple<int, int> t in Moves)
            {
                if (t.Item1 > t.Item2)
                    totalTime += t.Item1;
                else
                    totalTime += t.Item2;
            }
            return totalTime > _Time;
        }
    }
}
