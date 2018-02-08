using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_2_graphics_vector
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix m1 = new Matrix(2, 4, -1, 3);
            Matrix m2 = new Matrix(1, 3, 2, 1);
            Matrix m3 = m1 * m2;

            Matrix m4 = new Matrix(2, 4, -1, 3);
            Vector v1 = new Vector(2, 6);
            Vector v2 = m4 * v1;
            Console.ReadKey();
        }
    }
}
