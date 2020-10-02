namespace UFN_CG
{
    public class Perspective
    {
        public int fov;
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

        public Perspective(int fov, float aspect, float zNear, float zFar)
        {
            this.fov = fov;
            this.aspect = aspect;
            this.zNear = zNear;
            this.zFar = zFar;
        }

        public Matrix4x4 ProjectionMatrix() => Matrix4x4.ProjectionMatrix(fov, aspect, zNear, zFar);

    }

    public class Ortographic
    {
        public int left;
        public int right;
        public int top;
        public int bottom;
        public int near;
        public int far;

        public Ortographic()
        {
            left = 0;
            right = 600;
            top = 0;
            bottom = 600;
            near = 1;
            far = 10;
        }

        public Ortographic(int left, int right, int top, int bottom, int near, int far)
        {
            this.left = left;
            this.right = right;
            this.top = top;
            this.bottom = bottom;
            this.near = near;
            this.far = far;
        }

        public Matrix4x4 ProjectionMatrix() => Matrix4x4.ProjectionMatrix(left, right, top, bottom, near, far);

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
            this.Position = Vector3.Zero;
            this.Rotation = Vector3.Zero;
            Perspective = new Perspective();
            Ortographic = new Ortographic();

            this.IsOrtographic = false;
        }

        public VirtualCamera(Vector3 position, Vector3 rotation, int left, int right, int top, int bottom, int near, int far)
        {
            this.Position = position;
            this.Rotation = rotation;
            Ortographic = new Ortographic(left, right, top, bottom, near, far);
            Perspective = new Perspective();
            
            this.IsOrtographic = true;
        }
        public VirtualCamera(int left, int right, int top, int bottom, int near, int far)
        {
            Position = new Vector3(0,0,2);
            Rotation = Vector3.Zero;
            Ortographic = new Ortographic(left, right, top, bottom, near, far);
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
            Position = new Vector3(0, 0, 2);
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
            Matrix4x4 TranslationMatrix = Matrix4x4.TranslationMatrix(-Position.x, -Position.y, -Position.z);
            Matrix4x4 RotationMatrix = Matrix4x4.RotationMatrix(-Rotation.x, -Rotation.y, -Rotation.z);
            Matrix4x4 ScaleMatrix = Matrix4x4.ScaleMatrix(1,1,1);

            return (TranslationMatrix * RotationMatrix) * ScaleMatrix;
        }


        public void translate(Vector3 translation) => Position += translation;

        public void translate(float x,float y,float z)
        {
            Position.x += x;
            Position.y += y;
            Position.z += z;
        }

        public void rotate(Vector3 rotation) => rotation += rotation;
        
        public void rotate(Vector3 Axis, float angle) => Rotation += Axis * angle;

        #endregion
        
    }

}
