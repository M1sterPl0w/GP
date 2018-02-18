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

namespace Lecture3
{
    public partial class Form1 : Form
    {
        AxisX x_axis;
        AxisY y_axis;
        AxisZ z_axis;
        Cube c;
        public Form1()
        {
            InitializeComponent();
            this.Width = 800;
            this.Height = 600;

            x_axis = new AxisX(200);
            y_axis = new AxisY(200);
            z_axis = new AxisZ(200);
            c = new Cube(Color.Blue);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            List<Vector> vb;
            base.OnPaint(e);


            vb = ViewPortTransformation(800, 600, 600, x_axis.vb);
            x_axis.Draw(e.Graphics, vb);
            vb = ViewPortTransformation(800, 600, 600, y_axis.vb);
            y_axis.Draw(e.Graphics, vb);
            vb = ViewPortTransformation(800, 600, 600, z_axis.vb);
            z_axis.Draw(e.Graphics, vb);

            for (int i = 0; i < c.vertexbuffer.Count; i++)
            {
                c.vertexbuffer[i] = Matrix.Scale3D(150f) * c.vertexbuffer[i];
                c.vertexbuffer[i] = Matrix.RotateZ(30) * c.vertexbuffer[i];
                c.vertexbuffer[i] = Matrix.Viewtransformation(100, -10, 10) * c.vertexbuffer[i];
                c.vertexbuffer[i] = Matrix.ToVector(Matrix.ProjectionTransformation(800, 800) * (Vector.ToMatrix(c.vertexbuffer[i])));
            }
            vb = ViewPortTransformation(800, 600, 600, c.vertexbuffer);
            c.Draw(e.Graphics, vb);
        }

        public static List<Vector> ViewPortTransformation(float width, float height, float depth, List<Vector> vb)
        {
            List<Vector> result = new List<Vector>();
            float cx = width / 2;
            float cy = height / 2;
            float cz = depth / 2;
            foreach(Vector v in vb)
            {
                Vector v2 = new Vector(v.x + cx, cy - v.y, cz - v.z);
                result.Add(v2);
            }
            return result;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
