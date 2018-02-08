using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_2_graphics_vector
{
    public class Matrix
    {
        public float[,] array;

        public Matrix()
        {
            this.array = new float[2,2];
        }
        public Matrix(float m11, float m12,
                      float m21, float m22)
        {
            this.array = new float[,]{ { m11, m12 }, { m21, m22 } };
        }

        public Matrix(Vector v)
        {
            this.array = new float[,] { { v.X }, { v.Y } };
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            Matrix newMatrix = new Matrix();
            newMatrix.array[0, 0] = m1.array[0, 0] + m2.array[0, 0];
            newMatrix.array[0, 1] = m1.array[0, 1] + m2.array[0, 1];
            newMatrix.array[1, 0] = m1.array[1, 0] + m2.array[1, 0];
            newMatrix.array[1, 1] = m1.array[1, 1] + m2.array[1, 1];
            return newMatrix;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            Matrix newMatrix = new Matrix();
            newMatrix.array[0, 0] = m1.array[0, 0] - m2.array[0, 0];
            newMatrix.array[0, 1] = m1.array[0, 1] - m2.array[0, 1];
            newMatrix.array[1, 0] = m1.array[1, 0] - m2.array[1, 0];
            newMatrix.array[1, 1] = m1.array[1, 1] - m2.array[1, 1];
            return newMatrix;
        }
        public static Matrix operator *(Matrix m1, float f)
        {
            Matrix newMatrix = new Matrix();
            newMatrix.array[0, 0] = m1.array[0, 0] * f;
            newMatrix.array[0, 1] = m1.array[0, 1] * f;
            newMatrix.array[1, 0] = m1.array[1, 0] * f;
            newMatrix.array[1, 1] = m1.array[1, 1] * f;
            return newMatrix;
        }

        public static Matrix operator *(float f, Matrix m1)
        {
            return m1 * f;
        }
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            Matrix newMatrix = new Matrix();
            for (int r = 0; r < 2; r++)
            {
                for (int c = 0; c < 2; c++)
                {
                    for(int i = 0; i < 2; i++)
                    {
                        newMatrix.array[r, c] += m1.array[r, i] * m2.array[i, c];
                    }
                }
            }
            return newMatrix;
        }

        public static Vector operator *(Matrix m1, Vector v)
        {
            Matrix newMatrix = new Matrix(new Vector(0,0));
            for (int r = 0; r < 2; r++)
            {
                for (int c = 0; c < 2; c++)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        newMatrix.array[r, c] += m1.array[r, i] * m2.array[i, c];
                    }
                }
            }
            return newMatrix;
        }

        public static Matrix Identity()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
