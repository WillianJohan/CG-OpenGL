using System;
using System.Collections.Generic;
using System.Text;

namespace UFN_CG
{
    public class Mesh
    {
        public Vector3[] vertices;

        public Mesh()
        {
            vertices = new Vector3[2];
        }

        public void addVertice()
        {
            //calculo aqui
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
