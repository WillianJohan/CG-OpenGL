using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Renderer3D.Renderer.Cameras
{
    class Camera2D
    {
        public Vector2 FocusPosition { get; set; }
        public float Zoom { get; set; }

        public Camera2D(Vector2 focusPosition, float zoom) 
        {
            this.FocusPosition = focusPosition;
            this.Zoom = zoom;
        }

        public Matrix4x4 GetProjectionMatrix()
        {
            float left   = FocusPosition.X - Display.DisplayManager.WindowSize.X / 2f;
            float right  = FocusPosition.X + Display.DisplayManager.WindowSize.X / 2f;
            float top    = FocusPosition.Y - Display.DisplayManager.WindowSize.Y / 2f;
            float bottom = FocusPosition.Y + Display.DisplayManager.WindowSize.Y / 2f;

            Matrix4x4 orthographicMatrix = Matrix4x4.CreateOrthographicOffCenter(left, right, bottom, top, 0.01f, 100f);
            Matrix4x4 zoomMatrix = Matrix4x4.CreateScale(Zoom);

            return orthographicMatrix * zoomMatrix;
        }


    }
}
