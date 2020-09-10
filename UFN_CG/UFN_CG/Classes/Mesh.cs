using System;
using System.Collections.Generic;
using System.Text;

namespace UFN_CG
{
    public class Mesh
    {
        public Vector3[] vertices;
        int[] triangles;

        Vector3[] retas;

        public Mesh()
        {
            vertices = new Vector3[]
            {
                new Vector3(0,0,0),
                new Vector3(0,0,1),
                new Vector3(1,0,0),
                new Vector3(1,0,1)
            };

            triangles = new int[]
            {
                0,1,2,
                1,3,2
            };
        }

        public Vector3[] getShape(Vector3 Position, Vector3 Rotation, Vector3 Scale)
        {
            Vector3[] pontos = new Vector3[vertices.Length];
            Matrix4x4 MatT = Matrix4x4.TranslationMatrix(Position.x, Position.y, Position.z) *
                             Matrix4x4.RotationMatrix(Rotation.x, Rotation.y, Rotation.z) *
                             Matrix4x4.ScaleMatrix(Scale.x, Scale.y, Scale.z);
            Console.WriteLine(MatT);

            for(int i = 0; i < vertices.Length; i++)
            {
                pontos[i] = vertices[i] * MatT;
                Console.WriteLine(pontos[i]);
            }
            
            return pontos;
        }

        void CreateShape()
        {
            // Not Implemented Yet
        }

        void UpdateMesh()
        {
            // Not Implemented Yet
        }

        public override string ToString()
        {
            string allVertices = "";
            for (int i = 0; i < vertices.Length; i++)
                allVertices += $"vertice_{i}: {vertices[i]}\n";

            return allVertices;
        }
    }
}
