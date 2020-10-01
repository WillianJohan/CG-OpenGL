namespace UFN_CG
{
    public class VirtualCamera
    {

        #region Variables

        Vector3 position;
        Vector3 rotation;
        Matrix4x4 visualizationMatrix;

        // 3D Components
        int fov;
        float aspect;
        float zNear;
        float zFear;

        //2D Components
        int left;
        int right;
        int top;
        int bottom;
        int near;
        int far;

        bool isOrtographic;

        #endregion

        #region Getters and Setters

        public bool IsOrtographic {get=> isOrtographic;}
        public Matrix4x4 VisualizationMatrix { get => visualizationMatrix; }

        #endregion


        #region Constructors

        public VirtualCamera() 
        {
            this.position = Vector3.Zero;
            this.rotation = Vector3.Zero;
            this.fov = 60;
            this.aspect = 1;
            this.zNear = 0.1f;
            this.zFear = 100f;
            this.isOrtographic = false;
            this.visualizationMatrix = CalculateVisualizationMatrix();
        }

        public VirtualCamera(Vector3 position, Vector3 rotation, int left, int right, int top, int bottom, int near, int far)
        {
            this.position = position;
            this.rotation = rotation;
            this.left = left;
            this.right = right;
            this.top = top;
            this.bottom = bottom;
            this.near = near;
            this.far = far;
            this.isOrtographic = true;
            this.visualizationMatrix = CalculateVisualizationMatrix();
        }

        public VirtualCamera(Vector3 position, Vector3 rotation, int fov, float aspect, float zNear, float zFear)
        {
            this.position = position;
            this.rotation = rotation;
            this.fov = fov;
            this.aspect = aspect;
            this.zNear = zNear;
            this.zFear = zFear;
            this.isOrtographic = false;
            this.visualizationMatrix = CalculateVisualizationMatrix();
        }

        #endregion

        Matrix4x4 CalculateVisualizationMatrix() => (isOrtographic) ? 
            Matrix4x4.ProjectionMatrix(fov, aspect, zNear, zFear): 
            Matrix4x4.ProjectionMatrix(left, right, top, bottom, near, far);

    }
}
