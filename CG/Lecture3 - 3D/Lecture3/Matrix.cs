using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture3
{
    public class Matrix
    {
        public float[,] array;

        public Matrix() { }

        public Matrix(int dimension0, int dimension1)
        {
            this.array = new float[dimension0, dimension1];
        }

        public Matrix(float m11, float m21)
        {
            this.array = new float[,] { { m11 }, { m21 }, { 1 } };
        }

        public Matrix(float m11, float m12,
                      float m21, float m22)
        {
            this.array = new float[,] {{ m11, m12, 0 }, { m21, m22, 0 }, { 0, 0, 1} };
        }

        public Matrix(float m11, float m12, float m13,
                      float m21, float m22, float m23,
                      float m31, float m32, float m33)
        {
            this.array = new float[,] { { m11, m12, m13, 0 }, { m21, m22, m23, 0 }, { m31, m32, m33, 0 }, { 0, 0, 0, 1 } };
        }

        public Matrix(Vector v)
        {
            if (v.z == 0)
                this.array = new float[,] { { v.x }, { v.y }, { v.w } };
            else
                this.array = new float[,] { { v.x }, { v.y }, { v.z }, { v.w } };
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if(m1.array.GetLength(0) != m2.array.GetLength(0) || m1.array.GetLength(1) != m2.array.GetLength(1))
            {
                throw new Exception("Matrices are not the same!");
            }
            Matrix newMatrix = new Matrix(m1.array.GetLength(0), m1.array.GetLength(1));
            for(int r = 0; r < m1.array.GetLength(1) - 1; r++)
            {
                for(int c = 0; c < m1.array.GetLength(0) - 1; c++)
                {
                    newMatrix.array[r, c] = m1.array[r, c] + m2.array[r, c];
                }
            }
            return newMatrix;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (m1.array.GetLength(0) != m2.array.GetLength(0) || m1.array.GetLength(1) != m2.array.GetLength(1))
            {
                throw new Exception("Matrices are not the same!");
            }
            Matrix newMatrix = new Matrix(m1.array.GetLength(0), m1.array.GetLength(1));
            for (int r = 0; r < m1.array.GetLength(1) - 1; r++)
            {
                for (int c = 0; c < m1.array.GetLength(0) - 1; c++)
                {
                    newMatrix.array[r, c] = m1.array[r, c] - m2.array[r, c];
                }
            }
            return newMatrix;
        }
        public static Matrix operator *(Matrix m1, float f)
        {
            Matrix newMatrix = new Matrix(m1.array.GetLength(0), m1.array.GetLength(1));
            for(int r = 0; r < m1.array.GetLength(0) - 1; r++)
            {
                for(int c = 0; c < m1.array.GetLength(1) - 1; c++)
                {
                    newMatrix.array[r, c] = m1.array[r, c] * f;
                }
            }
            return newMatrix;
        }

        public static Matrix operator *(float f, Matrix m1)
        {
            return m1 * f;
        }
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.array.GetLength(1) != m2.array.GetLength(0))
            {
                throw new Exception("Matrix sizes are not the same");
            }
            Matrix newMatrix = new Matrix()
            {
                array = new float[m1.array.GetLength(0), m2.array.GetLength(1)]
            };
            for (int r = 0; r < m1.array.GetLength(0); r++)
            {
                for (int c = 0; c < m2.array.GetLength(1); c++)
                {
                    for (int i = 0; i < m1.array.GetLength(1); i++)
                    {
                        newMatrix.array[r, c] += m1.array[r, i] * m2.array[i, c];
                    }
                }
            }
            return newMatrix;
        }

        public static Vector operator *(Matrix m1, Vector v)
        {
            Vector newVector = new Vector();
            if(m1.array.GetLength(1) == 3)
            {
                newVector.x += m1.array[0, 0] * v.x;
                newVector.x += m1.array[0, 1] * v.y;
                newVector.x += m1.array[0, 2] * v.w;
                newVector.y += m1.array[1, 0] * v.x;
                newVector.y += m1.array[1, 1] * v.y;
                newVector.y += m1.array[1, 2] * v.w;
            }
            else if(m1.array.GetLength(1) == 4)
            {
                newVector.x += m1.array[0, 0] * v.x;
                newVector.x += m1.array[0, 1] * v.y;
                newVector.x += m1.array[0, 2] * v.z;
                newVector.x += m1.array[0, 3] * v.w;
                newVector.y += m1.array[1, 0] * v.x;
                newVector.y += m1.array[1, 1] * v.y;
                newVector.y += m1.array[1, 2] * v.z;
                newVector.y += m1.array[1, 3] * v.w;
                newVector.z += m1.array[2, 0] * v.x;
                newVector.z += m1.array[2, 1] * v.y;
                newVector.z += m1.array[2, 2] * v.z;
                newVector.z += m1.array[2, 3] * v.w;
            }
            
            return newVector;
        }

        public static Matrix Identity(int d)
        {
            return new Matrix(1, 0, 0, 
                              0, 1, 0, 
                              0, 0, 1);
        }

        public static Matrix Scale3D(float s)
        {
            return new Matrix(s, 0, 0,
                              0, s, 0,
                              0, 0, s);
        }

        public static Matrix RotateX(float degrees)
        {
            double rad = (Math.PI / 180) * degrees;
                return new Matrix(1, 0, 0, 
                                  0, (float)Math.Cos(rad), (float)-Math.Sin(rad), 
                                  0f, (float)Math.Sin(rad), (float)Math.Cos(rad));
        }

        public static Matrix RotateY(float degrees)
        {
            double rad = (Math.PI / 180) * degrees;
            return new Matrix((float)Math.Cos(rad), 0, (float)Math.Sin(rad),
                                  0, 1, 0,
                                  (float)-Math.Sin(rad), 0, (float)Math.Cos(rad));
        }

        public static Matrix RotateZ(float degrees)
        {
            double rad = (Math.PI / 180) * degrees;
            return new Matrix((float)Math.Cos(rad), (float)-Math.Sin(rad), 0,
                                  (float)Math.Sin(rad), (float)Math.Cos(rad), 0,
                                  0, 0, 1);
        }
            

        public static Matrix Translate(Vector t)
        {
            return new Matrix()
            {
                array = new float[,] { { 1, 0, 0, t.x},
                                        { 0, 1, 0, t.y},
                                        { 0, 0, 1, t.z},
                                        { 0, 0, 0, 1}}
            };
        }

        public static Vector ToVector(Matrix m)
        {
            return new Vector(m.array[0, 0], m.array[1, 0]);
        }

        public static Matrix Viewtransformation(float theta, float phi, float r)
        {
            Matrix temp = new Matrix((float)-Math.Sin(theta), (float)Math.Cos(theta), 0,
                              (float)-Math.Cos(theta) * (float)Math.Cos(phi), (float)-Math.Cos(phi) * (float)Math.Sin(theta), (float)Math.Sin(phi),
                              (float)Math.Cos(theta) * (float)Math.Sin(phi), (float)Math.Sin(theta) * (float)Math.Sin(phi), (float)Math.Cos(phi));
            temp.array[2, 3] = -r;

            return temp;
        }

        public static Matrix ProjectionTransformation(float d, float z)
        {
            float i = -(d / z);
            return new Matrix()
            {
                array = new float[,]
                {
                    { i, 0 , 0 , 0 },
                    { 0, i, 0, 0 }
                }
            };
        }
    }
}

