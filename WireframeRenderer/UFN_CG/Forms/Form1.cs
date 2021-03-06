﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace UFN_CG
{
    public partial class MainForm : Form
    {
        WorldToScreenPoint worldToScreenPoint;
        VirtualCamera _VirtualCamera;
        G_Object _GraphicObject;

        public MainForm()
        {
            InitializeComponent();

            _VirtualCamera = new VirtualCamera();
            _VirtualCamera.Position = new Vector3(0, 0, 3);

            _GraphicObject = FileManager.importObject("..\\..\\3DModels\\Thompson.obj");
            _GraphicObject.transform.Position = new Vector3(1000, 500, 0);
            _GraphicObject.transform.Scale = new Vector3(100f, 100f, .3f);
            

            worldToScreenPoint = new WorldToScreenPoint(new WorldToScreenPoint.Window(0, 0, canvas.Size.Width, canvas.Size.Height), new WorldToScreenPoint.Viewport(-1, -1, 1, 1));

            updateCameraTransformValues();
            updateGraphicTransformValues();

            updateScreen();
        }

        #region Render Methods

        void updateScreen()
        {
            Graphics screenRenderer = canvas.CreateGraphics();
            screenRenderer.Clear(Color.White);

            Brush brush = new SolidBrush(Color.Red);
            Pen p = new Pen(brush, 1);

            Matrix4x4 VC_projectionMatrix = _VirtualCamera.ProjectionMatrix;
            Matrix4x4 VC_visualizationMatrix = _VirtualCamera.VisualizationMatrix;
            Matrix4x4 graphicObject_TransformationMatrix = _GraphicObject.transform.TransformationMatrix;

            List<Point> point = new List<Point>(); // Lista que irá conter toda lista de pontos

            for (int i = 0; i < _GraphicObject.meshFilter.Mesh.Vertices.Length; i++)
            {
                Vector4 novoPontoV4 = _GraphicObject.meshFilter.Mesh.Vertices[i] * graphicObject_TransformationMatrix * VC_visualizationMatrix * VC_projectionMatrix ;
                novoPontoV4 /= novoPontoV4.w;
                point.Add(new Point((int)novoPontoV4.x, (int)novoPontoV4.y));
            }

            for (int i = 0; i < _GraphicObject.meshFilter.Mesh.Triangles.GetLength(0); i++)
            {
                int p1 = _GraphicObject.meshFilter.Mesh.Triangles[i, 0];
                int p2 = _GraphicObject.meshFilter.Mesh.Triangles[i, 1];
                int p3 = _GraphicObject.meshFilter.Mesh.Triangles[i, 2];
                int p4 = _GraphicObject.meshFilter.Mesh.Triangles[i, 3];

                screenRenderer.DrawLine(p, point[p1], point[p2]);
                screenRenderer.DrawLine(p, point[p2], point[p3]);
                screenRenderer.DrawLine(p, point[p3], point[p4]);
            }
        }

        #endregion

        #region Button Commands

        private void btn_Import3DModel_Click(object sender, EventArgs e)
        {
            _GraphicObject = FileManager.importObject();
            updateGraphicTransformValues();
            updateScreen();
        }

        private void btn_Translate_Click(object sender, System.EventArgs e)
        {
            float _Tx = (float)_ObjectCommandsTranslate_X.Value;
            float _TY = (float)_ObjectCommandsTranslate_Y.Value;
            float _Tz = (float)_ObjectCommandsTranslate_Z.Value;

            _GraphicObject.transform.translate(_Tx, _TY, _Tz);

            updateGraphicTransformValues();
            updateScreen();
        }

        private void btn_Rotate_Click(object sender, EventArgs e)
        {
            float _Rx = (float)_ObjectCommandsRotate_X.Value;
            float _RY = (float)_ObjectCommandsRotate_Y.Value;
            float _Rz = (float)_ObjectCommandsRotate_Z.Value;

            _GraphicObject.transform.rotate(_Rx, _RY, _Rz);

            updateGraphicTransformValues();
            updateScreen();
        }

        private void updateGraphicTransformValues()
        {
            // -- Graphic Object Values in canvas ------------------------------------------
            _ObjectTransformPosition_X.Value = (decimal)_GraphicObject.transform.Position.x;
            _ObjectTransformPosition_Y.Value = (decimal)_GraphicObject.transform.Position.y;
            _ObjectTransformPosition_Z.Value = (decimal)_GraphicObject.transform.Position.z;

            _ObjectTransformRotation_X.Value = (decimal)_GraphicObject.transform.Rotation.x;
            _ObjectTransformRotation_Y.Value = (decimal)_GraphicObject.transform.Rotation.y;
            _ObjectTransformRotation_Z.Value = (decimal)_GraphicObject.transform.Rotation.z;

            _ObjectTransformScale_X.Value = (decimal)_GraphicObject.transform.Scale.x;
            _ObjectTransformScale_Y.Value = (decimal)_GraphicObject.transform.Scale.y;
            _ObjectTransformScale_Z.Value = (decimal)_GraphicObject.transform.Scale.z;
        }

        #endregion

        #region Object Transform Values Changed

        #region Position Values

        private void GraphicObject_PositionX_ValueChanged(object sender, EventArgs e) => OnGraphicObjectPositionChanged((float)_ObjectTransformPosition_X.Value, _GraphicObject.transform.Position.y, _GraphicObject.transform.Position.z);
        private void GraphicObject_PositionY_ValueChanged(object sender, EventArgs e) => OnGraphicObjectPositionChanged(_GraphicObject.transform.Position.x, (float)_ObjectTransformPosition_Y.Value, _GraphicObject.transform.Position.z);
        private void GraphicObject_PositionZ_ValueChanged(object sender, EventArgs e) => OnGraphicObjectPositionChanged(_GraphicObject.transform.Position.x, _GraphicObject.transform.Position.y, (float)_ObjectTransformPosition_Z.Value);

        void OnGraphicObjectPositionChanged(float x, float y, float z)
        {
            _GraphicObject.transform.Position = new Vector3(x, y, z);
            updateScreen();
        }

        #endregion

        #region Rotation Values

        private void GraphicObject_RotationX_ValueChanged(object sender, EventArgs e) => OnGraphicObjectRotationChanged((float)_ObjectTransformRotation_X.Value, _GraphicObject.transform.Rotation.y, _GraphicObject.transform.Rotation.z);
        private void GraphicObject_RotationY_ValueChanged(object sender, EventArgs e) => OnGraphicObjectRotationChanged(_GraphicObject.transform.Rotation.x, (float)_ObjectTransformRotation_Y.Value, _GraphicObject.transform.Rotation.z);
        private void GraphicObject_RotationZ_ValueChanged(object sender, EventArgs e) => OnGraphicObjectRotationChanged(_GraphicObject.transform.Rotation.x, _GraphicObject.transform.Rotation.y, (float)_ObjectTransformRotation_Z.Value);

        void OnGraphicObjectRotationChanged(float x, float y, float z)
        {
            _GraphicObject.transform.Rotation = new Vector3(x, y, z);
            updateScreen();
        }

        #endregion

        #region Scale Values

        private void Sx_ValueChanged(object sender, EventArgs e) => OnGraphicObjectScaleChanged((float)_ObjectTransformScale_X.Value, _GraphicObject.transform.Scale.y, _GraphicObject.transform.Scale.z);
        private void Sy_ValueChanged(object sender, EventArgs e) => OnGraphicObjectScaleChanged(_GraphicObject.transform.Scale.x, (float)_ObjectTransformScale_Y.Value, _GraphicObject.transform.Scale.z);
        private void Sz_ValueChanged(object sender, EventArgs e) => OnGraphicObjectScaleChanged(_GraphicObject.transform.Scale.x, _GraphicObject.transform.Scale.y, (float)_ObjectTransformScale_Z.Value);

        void OnGraphicObjectScaleChanged(float x, float y, float z)
        {
            _GraphicObject.transform.Scale = new Vector3(x, y, z);
            updateScreen();
        }

        #endregion

        #endregion

        #region Virtual Camera Values Changed

        private void _VirtualCameraPosition_X_ValueChanged(object sender, EventArgs e) => OnVirtualCameraPositionChanged((float)_VirtualCameraPosition_X.Value, _VirtualCamera.Position.y, _VirtualCamera.Position.z);
        private void _VirtualCameraPosition_Y_ValueChanged(object sender, EventArgs e) => OnVirtualCameraPositionChanged(_VirtualCamera.Position.x, (float)_VirtualCameraPosition_Y.Value, _VirtualCamera.Position.z);
        private void _VirtualCameraPosition_Z_ValueChanged(object sender, EventArgs e) => OnVirtualCameraPositionChanged(_VirtualCamera.Position.x, _VirtualCamera.Position.y, (float)_VirtualCameraPosition_Z.Value);

        private void _VirtualCameraRotation_X_ValueChanged(object sender, EventArgs e) => OnVirtualCameraRotationChanged((float)_VirtualCameraRotation_X.Value, _VirtualCamera.Rotation.y, _VirtualCamera.Rotation.z);
        private void _VirtualCameraRotation_Y_ValueChanged(object sender, EventArgs e) => OnVirtualCameraRotationChanged(_VirtualCamera.Rotation.x, (float)_VirtualCameraRotation_Y.Value, _VirtualCamera.Rotation.z);
        private void _VirtualCameraRotation_Z_ValueChanged(object sender, EventArgs e) => OnVirtualCameraRotationChanged(_VirtualCamera.Rotation.x, _VirtualCamera.Rotation.y, (float)_VirtualCameraRotation_Z.Value);


        void OnVirtualCameraPositionChanged(float x, float y, float z)
        {
            _VirtualCamera.Position = new Vector3(x, y, z);
            updateScreen();
        }

        void OnVirtualCameraRotationChanged(float x, float y, float z)
        {
            _VirtualCamera.Rotation = new Vector3(x, y, z);
            updateScreen();
        }

        private void updateCameraTransformValues()
        {
            // -- Virtual Camera Values in canvas ------------------------------------------
            _VirtualCameraPosition_X.Value = (decimal)_VirtualCamera.Position.x;
            _VirtualCameraPosition_Y.Value = (decimal)_VirtualCamera.Position.y;
            _VirtualCameraPosition_Z.Value = (decimal)_VirtualCamera.Position.z;

            _VirtualCameraRotation_X.Value = (decimal)_VirtualCamera.Rotation.x;
            _VirtualCameraRotation_Y.Value = (decimal)_VirtualCamera.Rotation.y;
            _VirtualCameraRotation_Z.Value = (decimal)_VirtualCamera.Rotation.z;
        }

        #endregion

        #region Form

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            worldToScreenPoint = new WorldToScreenPoint(new WorldToScreenPoint.Viewport(0, 0, canvas.Size.Width, canvas.Size.Height));
            _VirtualCamera.Perspective.aspect = canvas.Size.Width / canvas.Size.Height;
            updateScreen();
        }

        #endregion

    }
}
