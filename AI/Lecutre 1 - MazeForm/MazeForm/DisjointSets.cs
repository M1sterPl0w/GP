using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeForm
{
    class DisjointSets
    {
        private int[] setArray;
        public int Size { get; set; }
        public DisjointSets(int numElements)
        {
            this.setArray = new int[numElements];
            Helper.SetRoots(ref setArray);
            this.Size = numElements;
        }

        //public void Union(int elem1, int elem2)
        //{
        //    int root1 = Find(elem1);
        //    int root2 = Find(elem2);

        //    if (root1 == root2)
        //    {
        //        return;
        //    }
        //    int value1 = setArray[root1];
        //    int value2 = setArray[root2];
        //    int newsize = value1 + value2;
        //    if (value1 < value2)
        //    {
        //        setArray[root2] = root1;
        //        setArray[root1] = newsize;
        //    }
        //    else
        //    {
        //        setArray[root1] = root2;
        //        setArray[root2] = newsize;
        //    }
        //}

        public void Union(int elem1, int elem2)
        {
            int root1 = Find(elem1);
            int root2 = Find(elem2);

            if (root1 != root2)
            {
                // Haal dieptes op
                int depth1 = setArray[root1];
                int depth2 = setArray[root2];

                // Vergelijk dieptes -> als links kleiner of gelijk is aan rechts
                if (depth1 <= depth2)
                {
                    // Verwijs naar nieuwe root
                    setArray[root2] = root1;
                    // Pas diepte aan
                    setArray[root1] = depth1 + depth2;
                }
                else
                {
                    // Verwijs naar nieuwe root
                    setArray[root1] = root2;
                    // Pas diepte aan
                    setArray[root2] = depth1 + depth2;
                }
            }
        }

        //public int Find(int x)
        //{
        //    var value = setArray[x];
        //    return value >= 0 ? Find(value) : x;
        //}

        // Find with compression
        public int Find(int x)
        {
            if (setArray[x] < 0)
                return x;
            else
                return setArray[x] = Find(setArray[x]);
        }
    }
}
