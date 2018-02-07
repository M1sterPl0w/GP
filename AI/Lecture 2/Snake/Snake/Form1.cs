using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            if(this.graaf.result != null)
            {
                Tekenaar.DrawGrid(g, this.graaf.VertexMap);
                Tekenaar.DrawPath(g, this.graaf.result, this.graaf.VertexMap);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReloadRandom();
        }

        private void ReloadRandom()
        {
            this.graaf.Hamiltonian(GetRandom());
            this.label2.Text = this.graaf.result.Count.ToString();

            Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReloadLongest();
        }

        private void ReloadLongest()
        {
            do
            {
                this.graaf.Hamiltonian(GetRandom());
                this.label2.Text = this.graaf.result.Count.ToString();
                Invalidate();
            } while (this.graaf.result.Count < 25);
        }

        private string GetRandom()
        {
            Random rnd = new Random();
            string allVertices = "ABCDEFGHIJKLMOPQRSTUVWXY";
            int index = rnd.Next(allVertices.Length);
            string uhm = allVertices[index].ToString();
            return uhm;
        }
    }
}
