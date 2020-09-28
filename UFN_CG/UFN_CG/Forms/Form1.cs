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

            updateTransformValues();
            paintLines();
        }

        

        void paintLines()
        {
            Graphics graphic = canvas.CreateGraphics();
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

        #region Button Commands

        private void btn_Translate_Click(object sender, System.EventArgs e)
        {
            float _Tx = (float)Value_Tx.Value;
            float _TY = (float)Value_Ty.Value;
            float _Tz = (float)Value_Tz.Value;
            
            //transform.translate(_Tx, _TY, _Tz);   // 3D Orientation
            transform.translate(_Tx, _TY);          // 2D Orientation

            updateTransformValues();
            paintLines();
        }

        private void btn_Rotate_Click(object sender, EventArgs e)
        {
            //float _Rx    = (float)Value_Rx.Value;  // 3D Orientation
            //float _RY    = (float)Value_Ry.Value;  // 3D Orientation
            //float _Rz    = (float)Value_Rz.Value;  // 3D Orientation
            float _Angle = (float)Value_Ar.Value;
            
            //transform.translate(_Rx, _RY, _Rz);   // 3D Orientation
            transform.rotate(_Angle);                // 2D Orientation

            updateTransformValues();
            paintLines();
        }

        private void updateTransformValues()
        {
            Px.Value = (decimal)transform.Position.x;
            Py.Value = (decimal)transform.Position.y;
            //Pz.Value = (decimal)transform.Position.z;

            //Rx.Value = (decimal)transform.Rotation.x;     //3D Value
            //Ry.Value = (decimal)transform.Rotation.y;     //3D Value
            //Rz.Value = (decimal)transform.Rotation.z;     //3D Value
            
            Rz.Value = (decimal)transform.Rotation;         //2D Value

            Sx.Value = (decimal)transform.Scale.x;
            Sy.Value = (decimal)transform.Scale.y;
            //Sz.Value = (decimal)transform.Scale.z;
        }

        #endregion

        #region Object Transform Values Changed

        #region Position Values
        
        private void Px_ValueChanged(object sender, EventArgs e) => OnPositionChanged((float)Px.Value, transform.Position.y);
        private void Py_ValueChanged(object sender, EventArgs e) => OnPositionChanged(transform.Position.x, (float)Py.Value);
        private void Pz_ValueChanged(object sender, EventArgs e) => OnPositionChanged(transform.Position.x, transform.Position.y);

        void OnPositionChanged(float x, float y)
        {
            transform.Position = new Vector2(x, y);
            paintLines();
        }

        #endregion

        #region Rotation Values
        
        private void Rx_ValueChanged(object sender, EventArgs e) { } //=> transform.Rotation = new Vector3((float)Rx.Value, transform.Rotation.y , transform.Rotation.z);
        private void Ry_ValueChanged(object sender, EventArgs e) { } //=> transform.Rotation = new Vector3(transform.Rotation.x, (float)Ry.Value, transform.Rotation.z);
        //private void Rz_ValueChanged(object sender, EventArgs e) { } //=> transform.Rotation = new Vector3(transform.Rotation.x, transform.Rotation.y, (float)Rz.Value);
        private void Rz_ValueChanged(object sender, EventArgs e) => OnRotationChanged(0, 0, (float)Rz.Value);

        void OnRotationChanged(float x, float y, float z)
        {
            //2D:
            transform.Rotation = (float)z;

            //3D:
            //transform.Rotation = new Vector3(x, y, z);

            paintLines();
        }

        #endregion

        #region Scale Values

        private void Sx_ValueChanged(object sender, EventArgs e) => OnScaleChanged((float)Sx.Value, transform.Scale.y, 0);
        private void Sy_ValueChanged(object sender, EventArgs e) => OnScaleChanged(transform.Scale.x, (float)Sy.Value, 0);
        private void Sz_ValueChanged(object sender, EventArgs e) => OnScaleChanged(transform.Scale.x, transform.Scale.y, (float)Sz.Value);

        void OnScaleChanged(float x, float y, float z)
        {
            transform.Scale = new Vector2(x,y);
            paintLines();
        }

        #endregion

        #endregion
    }
}
