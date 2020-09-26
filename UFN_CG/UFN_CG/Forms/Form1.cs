using System;
using System.Drawing;
using System.Windows.Forms;

namespace UFN_CG
{
    public partial class Form1 : Form
    {
        Transform2D transform;
        Vector2[] vertices;

        public Form1()
        {
            InitializeComponent();
            
            transform = new Transform2D();
            transform.Position = new Vector2(200,200);

            vertices = new Vector2[]
            {
                new Vector2(-100,-100),
                new Vector2(100,-100),
                new Vector2(100,100),
                new Vector2(-100,100)
            };
         
            this.Size = new Size(1000, 1000);
            canvas.Size = Size;
            paintLines();
        }

        private void button1_Click(object sender, System.EventArgs e) 
        {
            //transform.translate(50, 0);
            //transform.Scale *= .5f;
            transform.rotate(10);
            paintLines();
        }

        void paintLines()
        {
            Graphics graphic = canvas.CreateGraphics();
            canvas.Size = Size;
            graphic.Clear(Color.White);
            Brush brush = new SolidBrush(Color.Red);
            Pen p = new Pen(brush, 3);

            for (int i = 0; i < vertices.Length; i++)
            {
                Vector3 v_Ini = (new Vector3(vertices[i].x, vertices[i].y, 1) - (Vector3)transform.Position) * transform.TransformationMatrix;
                Vector3 v_End = (((i + 1 >= vertices.Length) ? new Vector3(vertices[0].x, vertices[0].y, 1) : new Vector3(vertices[i+1].x, vertices[i+1].y, 1)) - (Vector3)transform.Position) * transform.TransformationMatrix;

                v_Ini += (Vector3)transform.Position;
                v_End += (Vector3)transform.Position;

                Point ini = new Point((int)v_Ini.x, (int)v_Ini.y);
                Point end = new Point((int)v_End.x, (int)v_End.y);
                
                graphic.DrawLine(p, ini, end);
            }
        }
    }
}
