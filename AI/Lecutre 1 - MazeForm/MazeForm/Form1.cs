using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeForm
{
    public partial class Form1 : Form
    {
        private int rows = 20;
        private int collumns = 30;
        private const int OFFSET = 25;
        private List<Tuple<int, int>> walls;
        private List<int> sol;
        public Form1()
        {
            Console.WriteLine("How many rows?");
            this.rows = Int32.Parse(Console.ReadLine());
            Console.WriteLine("How many collumns?");
            this.collumns = Int32.Parse(Console.ReadLine());


            this.Width = collumns * OFFSET;
            this.Height = rows * OFFSET;
            
            Maze m = new Maze(rows, collumns);
            this.walls = m.Walls;
            
            MazeSolver solver = new MazeSolver();

            solver.Solve(this.rows, this.collumns, this.walls);
            sol = new List<int>(solver.Result);
            foreach (var s in sol)
                Console.WriteLine(s);
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Helper.PrintSolution(g, OFFSET, collumns, rows, sol);
            Helper.PrintMaze(g, rows, collumns, OFFSET, walls);
            
        }
    }
}
