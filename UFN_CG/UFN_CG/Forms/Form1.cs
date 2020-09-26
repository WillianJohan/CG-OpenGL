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
            
            //Criando um objeto de transformações 2D
            transform = new Transform2D();

            //Setando a posicao do objeto para um ponto da tela
            transform.Position = new Vector2(200,200);
            //transform.Scale *= 2;
            transform.rotate(30);

            //Criando as vértices no ponto central de origem e posicionando na posição inicial da tela
            vertices = new Vector2[]
            {
                new Vector2(-100,-100) + transform.Position,
                new Vector2(100,-100)  + transform.Position,
                new Vector2(100,100)   + transform.Position,
                new Vector2(-100,100)  + transform.Position
            };
         
            this.Size = new Size(1000, 1000);
            canvas.Size = Size;
            paintLines();

            //Console.WriteLine("Criando o Transform.");
            //Transform2D t = new Transform2D();
            //t.Position = new Vector2(10, 10);
            //Console.WriteLine("T::Posicao Inicial: " + t.Position);
            //
            //t.translate(10, 5);
            //Console.WriteLine("T::Transladando: " + new Vector2(10, 5));
            //Console.WriteLine("T::Posicao final: " + t.Position);
            //
            //Console.WriteLine("Vertice no ponto (0,0)");
            //Console.WriteLine("vertice aplicada transformacao: " +
            //     t.TransformationMatrix * new Vector3(0, 0, 1));

        }

        private void button1_Click(object sender, System.EventArgs e)
        {

            //transform.translate(0, 50);
            //transform.rotate(-5);
            //transform.Scale *=1.01f;

            for (int i = 0; i < vertices.Length; i++)
            {
                Vector3 vertice = new Vector3(vertices[i].x, vertices[i].y, 1) - (Vector3)transform.Position;
                Vector3 newPoint = transform.TransformationMatrix * vertice;
                vertices[i] = (Vector2)newPoint + transform.Position;
            }
            Console.WriteLine(transform.TransformationMatrix*(Vector3)vertices[2]);
            paintLines();
            
        }


        void paintLines()
        {
            Graphics g = canvas.CreateGraphics();
            canvas.Size = Size;
            g.Clear(Color.White);
            Brush brush = new SolidBrush(Color.Red);
            Pen p = new Pen(brush, 3);

            for (int i = 0; i < vertices.Length; i++)
            {
                Point ini = new Point((int)vertices[i].x, (int)vertices[i].y);
                Point end = (i + 1 >= vertices.Length) ? new Point((int)vertices[0].x, (int)vertices[0].y) : new Point((int)vertices[i + 1].x, (int)vertices[i + 1].y);
                g.DrawLine(p, ini, end);
            }

                
        }

    }
}
