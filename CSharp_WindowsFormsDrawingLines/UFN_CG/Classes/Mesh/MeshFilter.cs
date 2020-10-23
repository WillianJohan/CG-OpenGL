using System.Collections.Generic;

namespace UFN_CG
{
    public class MeshFilter
    {
        Mesh mesh;

        public Mesh Mesh{ get => mesh; set=> mesh = value; }

        #region Constructors

        public MeshFilter() => Mesh = null;

        public MeshFilter(Mesh mesh) => this.mesh = mesh;

        public MeshFilter(Vector4[] Vertices, List<int[]> Triangles) 
        {
            int verticesCount = Vertices.Length;
         
            List<int[]> filteredTriangles = new List<int[]>();
            for (int i = 0; i < Triangles.Count; i++)
                if (Triangles[i][0] <= verticesCount || Triangles[i][1] <= verticesCount || Triangles[i][2] <= verticesCount)
                    filteredTriangles.Add(Triangles[i]);

            int[,] triangles = new int[filteredTriangles.Count, 4];
            for (int i = 0; i < filteredTriangles.Count; i++)
            {
                triangles[i, 0] = filteredTriangles[i][0];
                triangles[i, 1] = filteredTriangles[i][1];
                triangles[i, 2] = filteredTriangles[i][2];
                triangles[i, 3] = filteredTriangles[i][3];
            }

            mesh = new Mesh(Vertices, triangles);
        }

        #endregion
    }
}
