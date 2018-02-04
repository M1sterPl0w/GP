using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeTorch
{
    class Program
    {
        static void Main(string[] args)
        {
            Puzzle p = new Puzzle();
            p.Solve();
            Console.WriteLine("Amount of solutions: {0}", p.AmountOfSolutions);
            Console.ReadKey();
        }
    }
}
