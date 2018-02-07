using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class PreMadeGraph
    {
        public static Graph Create()
        {
            Graph g = new Graph();
            // A
            g.AddEdge("A", "B", 0);
            g.AddEdge("A", "F", 0);

            // B
            g.AddEdge("B", "A", 0);
            g.AddEdge("B", "C", 0);

            // C
            g.AddEdge("C", "B", 0);
            g.AddEdge("C", "G", 0);
            g.AddEdge("C", "I", 0);
            g.AddEdge("C", "D", 0);

            // D
            g.AddEdge("D", "C", 0);
            g.AddEdge("D", "E", 0);

            // E
            g.AddEdge("E", "D", 0);
            g.AddEdge("E", "J", 0);

            // F
            g.AddEdge("F", "A", 0);
            g.AddEdge("F", "K", 0);

            // G
            g.AddEdge("G", "C", 0);
            g.AddEdge("G", "H", 0);
            g.AddEdge("G", "L", 0);
            g.AddEdge("G", "K", 0);

            // H
            g.AddEdge("H", "I", 0);
            g.AddEdge("H", "N", 0);
            g.AddEdge("H", "M", 0);
            g.AddEdge("H", "L", 0);
            g.AddEdge("H", "G", 0);

            // I
            g.AddEdge("I", "C", 0);
            g.AddEdge("I", "O", 0);
            g.AddEdge("I", "N", 0);
            g.AddEdge("I", "H", 0);

            // J
            g.AddEdge("J", "E", 0);
            g.AddEdge("J", "O", 0);

            // K
            g.AddEdge("K", "F", 0);
            g.AddEdge("K", "G", 0);
            g.AddEdge("K", "Q", 0);
            g.AddEdge("K", "P", 0);

            // L
            g.AddEdge("L", "G", 0);
            g.AddEdge("L", "H", 0);
            g.AddEdge("L", "R", 0);
            g.AddEdge("L", "Q", 0);

            // M
            g.AddEdge("M", "H", 0);
            g.AddEdge("M", "R", 0);

            // N
            g.AddEdge("N", "H", 0);
            g.AddEdge("N", "I", 0);
            g.AddEdge("N", "R", 0);
            g.AddEdge("N", "S", 0);

            // O
            g.AddEdge("O", "J", 0);
            g.AddEdge("O", "T", 0);

            // P
            g.AddEdge("P", "K", 0);
            g.AddEdge("P", "U", 0);

            // Q
            g.AddEdge("Q", "K", 0);
            g.AddEdge("Q", "L", 0);
            g.AddEdge("Q", "R", 0);
            g.AddEdge("Q", "W", 0);

            // R
            g.AddEdge("R", "L", 0);
            g.AddEdge("R", "M", 0);
            g.AddEdge("R", "N", 0);
            g.AddEdge("R", "Q", 0);
            g.AddEdge("R", "S", 0);

            // S
            g.AddEdge("S", "N", 0);
            g.AddEdge("S", "O", 0);
            g.AddEdge("S", "W", 0);
            g.AddEdge("S", "R", 0);

            // T
            g.AddEdge("T", "O", 0);
            g.AddEdge("T", "Y", 0);

            // U
            g.AddEdge("U", "P", 0);
            g.AddEdge("U", "V", 0);

            // V
            g.AddEdge("V", "W", 0);
            g.AddEdge("V", "U", 0);

            // W
            g.AddEdge("W", "V", 0);
            g.AddEdge("W", "Q", 0);
            g.AddEdge("W", "S", 0);
            g.AddEdge("W", "X", 0);

            // X
            g.AddEdge("X", "W", 0);
            g.AddEdge("X", "Y", 0);

            // Y
            g.AddEdge("Y", "X", 0);
            g.AddEdge("Y", "T", 0);

            return g;
        }
    }
}
