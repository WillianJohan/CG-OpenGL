﻿using System.Collections.Generic;
using System.IO;

namespace UFN_CG
{
    public static class FileManager
    {

        static string selectedPathFileName(string filter)
        {
            //Open File Dialog
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = filter;
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                return openFileDialog.FileName;
            return null;
        }

        static G_Object loadObj() 
        {
            string ObjName = "";
            List<Vector4> list_VerticesArray = new List<Vector4>();
            List<int[]> list_TrianglesArray = new List<int[]>();

            string[] Lines = File.ReadAllLines(selectedPathFileName("Wavefront File(*.obj)| *.obj"));
            foreach (var line in Lines)
            {
                if (line.StartsWith("v "))
                {
                    float x, y, z;
                    x = float.Parse(line.Split(' ')[1].Replace('.', ','));
                    y = float.Parse(line.Split(' ')[2].Replace('.', ','));
                    z = float.Parse(line.Split(' ')[3].Replace('.', ','));
                    list_VerticesArray.Add(new Vector4(x, y, z, 1));
                }
                else if (line.StartsWith("f "))
                {
                    int[] _triangle0 = new int[3];
                    int[] _triangle1 = new int[3];
                    int[] _triangle2 = new int[3];
                    int[] _triangle3 = new int[3];

                    _triangle0[0] = int.Parse(line.Split(' ')[1].Split('/')[0]);
                    _triangle0[1] = int.Parse(line.Split(' ')[1].Split('/')[1]);
                    _triangle0[2] = int.Parse(line.Split(' ')[1].Split('/')[2]);

                    _triangle1[0] = int.Parse(line.Split(' ')[2].Split('/')[0]);
                    _triangle1[1] = int.Parse(line.Split(' ')[2].Split('/')[1]);
                    _triangle1[2] = int.Parse(line.Split(' ')[2].Split('/')[2]);


                    _triangle2[0] = int.Parse(line.Split(' ')[3].Split('/')[0]);
                    _triangle2[1] = int.Parse(line.Split(' ')[3].Split('/')[1]);
                    _triangle2[2] = int.Parse(line.Split(' ')[3].Split('/')[2]);

                    _triangle3[0] = int.Parse(line.Split(' ')[4].Split('/')[0]);
                    _triangle3[1] = int.Parse(line.Split(' ')[4].Split('/')[1]);
                    _triangle3[2] = int.Parse(line.Split(' ')[4].Split('/')[2]);

                    list_TrianglesArray.Add(_triangle0);
                    list_TrianglesArray.Add(_triangle1);
                    list_TrianglesArray.Add(_triangle2);
                    list_TrianglesArray.Add(_triangle3);
                }
                else if(line.StartsWith("O "))
                {
                    ObjName = line.Substring(2);
                }
            }

            int[,] triangles = new int[list_TrianglesArray.Count, 3];
            for (int i = 0; i < list_TrianglesArray.Count; i++)
            {
                triangles[i, 0] = list_TrianglesArray[0][0];
                triangles[i, 1] = list_TrianglesArray[0][1];
                triangles[i, 2] = list_TrianglesArray[0][2];
            }

            MeshFilter meshFilter = new MeshFilter(new Mesh(list_VerticesArray.ToArray(), triangles));
            return new G_Object(ObjName, meshFilter);
        }

        public static Mesh importMesh()
        {
            return loadObj().meshFilter.Mesh;
        }

        public static G_Object importObject() 
        {
            return loadObj();
        }

    }
}