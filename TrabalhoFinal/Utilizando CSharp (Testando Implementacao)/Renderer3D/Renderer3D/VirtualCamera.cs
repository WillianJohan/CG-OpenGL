using System.Numerics;

namespace Renderer3D
{
    public class Perspective
    {
        public float fov;
        public float aspect;
        public float zNear;
        public float zFar;

        public Perspective()
        {
            fov = 60;
            aspect = 1;
            zNear = 0.1f;
            zFar = 100f;
        }

        public Perspective(float fov, float aspect, float zNear, float zFar)
        {
            this.fov = fov;
            this.aspect = aspect;
            this.zNear = zNear;
            this.zFar = zFar;
        }

        public Matrix4x4 ProjectionMatrix() => Matrix4x4.CreatePerspectiveFieldOfView(fov, aspect, zNear, zFar);

    }

    public class Ortographic
    {
        public float left;
        public float right;
        public float top;
        public float bottom;
        public float near;
        public float far;

        public Ortographic()
        {
            this.left   = (DisplayManager.WindowSize.X - DisplayManager.WindowSize.X) / 2f;
            this.right  = (DisplayManager.WindowSize.X + DisplayManager.WindowSize.X) / 2f;
            this.top    = (DisplayManager.WindowSize.Y - DisplayManager.WindowSize.Y) / 2f;
            this.bottom = (DisplayManager.WindowSize.Y + DisplayManager.WindowSize.Y) / 2f;

            this.near   = 0.01f;
            this.far    = 1000f;
        }

        public Ortographic(int near, int far)
        {
            this.left   = (DisplayManager.WindowSize.X - DisplayManager.WindowSize.X) / 2f;
            this.right  = (DisplayManager.WindowSize.X + DisplayManager.WindowSize.X) / 2f;
            this.top    = (DisplayManager.WindowSize.Y - DisplayManager.WindowSize.Y) / 2f;
            this.bottom = (DisplayManager.WindowSize.Y + DisplayManager.WindowSize.Y) / 2f;

            this.near   = near;
            this.far    = far;
        }

        public Matrix4x4 ProjectionMatrix() => Matrix4x4.CreateOrthographicOffCenter(left, right, bottom, top, near, far);

    }

    public class VirtualCamera
    {

        public Vector3 Position;
        public Vector3 Rotation;

        public Perspective Perspective;
        public Ortographic Ortographic;
        public bool IsOrtographic = false;

        #region Getters and Setters

        public Matrix4x4 VisualizationMatrix { get => visualizationMatrix(); }
        public Matrix4x4 ProjectionMatrix { get => (IsOrtographic) ? Ortographic.ProjectionMatrix() : Perspective.ProjectionMatrix(); }

        #endregion

        #region Constructors

        public VirtualCamera()
        {
            this.Position = new Vector3(0, 0, 0);
            this.Rotation = Vector3.Zero;
            Perspective = new Perspective();
            Ortographic = new Ortographic();

            this.IsOrtographic = false;
        }

        public VirtualCamera(Vector3 position, Vector3 rotation, int near, int far)
        {
            this.Position = position;
            this.Rotation = rotation;
            Ortographic = new Ortographic(near, far);
            Perspective = new Perspective();

            this.IsOrtographic = true;
        }
        public VirtualCamera(int near, int far)
        {
            Position = new Vector3(0, 0, 0);
            Rotation = Vector3.Zero;
            Ortographic = new Ortographic(near, far);
            Perspective = new Perspective();

            this.IsOrtographic = true;
        }

        public VirtualCamera(Vector3 position, Vector3 rotation, int fov, float aspect, float zNear, float zFar)
        {
            this.Position = position;
            this.Rotation = rotation;
            Perspective = new Perspective(fov, aspect, zNear, zFar);
            Ortographic = new Ortographic();

            this.IsOrtographic = false;
        }
        public VirtualCamera(int fov, float aspect, float zNear, float zFar)
        {
            Position = new Vector3(0, 0, 0);
            Rotation = Vector3.Zero;
            Perspective = new Perspective(fov, aspect, zNear, zFar);
            Ortographic = new Ortographic();

            this.IsOrtographic = false;
        }

        #endregion

        #region Methods

        private Matrix4x4 visualizationMatrix()
        {
            // Passa os valores invertidos por argumento pois a matriz resultante será multiplicada pelo ponto do universo
            Matrix4x4 TranslationMatrix = Matrix4x4.CreateTranslation(-Position);
            Matrix4x4 RotationMatrix = Matrix4x4.CreateFromQuaternion(Quaternion.CreateFromYawPitchRoll(Rotation.Y, Rotation.X, Rotation.Z));

            return (TranslationMatrix * RotationMatrix);
        }


        public void translate(Vector3 translation) => Position += translation;

        public void translate(float x, float y, float z)
        {
            Position.X += x;
            Position.Y += y;
            Position.Z += z;
        }

        public void rotate(Vector3 rotation) => rotation += rotation;

        public void rotate(Vector3 Axis, float angle) => Rotation += Axis * angle;

        #endregion

    }

}
