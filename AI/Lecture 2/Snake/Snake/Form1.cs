using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        private Graph graaf;
        public Form1()
        {
            this.graaf = PreMadeGraph.Create();

            this.graaf.Hamiltonian("M");
          
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Tekenaar.DrawPath(g, this.graaf.result, this.graaf.VertexMap);
            Tekenaar.DrawGrid(g, this.graaf.VertexMap);
            
        }
    }
}
