using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_2_graphics_vector
{
    public class Vector
    {
        public float X { get; set; }
        public float Y { get; set; }

        public float array[,];

        public Vector(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Vector operator +(Vector A, Vector B)
        {
            return new Vector((A.X + B.X), (A.Y + B.Y));
        }
        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}
