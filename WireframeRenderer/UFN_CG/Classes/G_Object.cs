namespace UFN_CG
{
    public class G_Object
    {
        public string Name = "GraphicObject";
        public Transform transform;
        public MeshFilter meshFilter;

        #region Getters and Setters

        public Mesh MeshWithTransformation { get => calculateMeshTransformation(); }

        #endregion

        #region Constructor

        public G_Object(string Name, Vector3 position, Vector3 rotation, Vector3 scale) 
        {
            this.Name = Name;
            meshFilter = new MeshFilter();

            transform = new Transform();
            transform.Position = position;
            transform.Rotation = rotation;
            transform.Scale = scale;
        }

        public G_Object(string Name, Transform transform)
        {
            this.Name = Name;
            meshFilter = new MeshFilter();
            this.transform = transform;
        }

        public G_Object(string Name, Transform transform, MeshFilter meshFilter)
        {
            this.Name = Name;
            this.meshFilter = meshFilter;
            this.transform = transform;
        }

        public G_Object(string Name, Vector3 position, Vector3 rotation, Vector3 scale, MeshFilter meshFilter)
        {
            this.Name = Name;
            this.meshFilter = meshFilter;

            transform = new Transform();
            transform.Position = position;
            transform.Rotation = rotation;
            transform.Scale = scale;
        }

        public G_Object(string Name, MeshFilter meshFilter)
        {
            this.Name = Name;
            this.meshFilter = meshFilter;
            transform = new Transform();
        }

        #endregion

        #region Methods

        Mesh calculateMeshTransformation() 
        {
            if (meshFilter.Mesh == null) return null;
            Vector4[] vertices = meshFilter.Mesh.Vertices;
            Matrix4x4 transformationMatrix = transform.TransformationMatrix;

            for (int i = 0; i < vertices.Length; i++)
                vertices[i] = vertices[i] * transformationMatrix;

            return new Mesh(vertices, meshFilter.Mesh.Triangles);
        }

        #endregion

    }
}
