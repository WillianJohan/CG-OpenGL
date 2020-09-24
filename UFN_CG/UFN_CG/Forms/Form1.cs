using System.Drawing;
using System.Windows.Forms;

namespace UFN_CG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = canvas.CreateGraphics();
            Brush brush = new SolidBrush(Color.Red);
            Pen p = new Pen(brush, 2);
            g.DrawLine(p, 10, 10, 100, 100);
        }
    }
}
