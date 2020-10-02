namespace UFN_CG
{
    public class Mesh
    {
        Vector4[] vertices;
        int[] triangles;

        public Vector4[] Vertices { get => vertices; }
        public int[] Triangles { get => triangles; }

        public Mesh(Vector4[] vertices, int[] triangles)
        {
            this.vertices = vertices;
            this.triangles = triangles;
        }
    }
}