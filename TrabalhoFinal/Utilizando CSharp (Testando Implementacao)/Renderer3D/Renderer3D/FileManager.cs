using System.Collections.Generic;
using System.Numerics;
using System.IO;


namespace Renderer3D
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
                if (line.StartsWith("v ")) // Vertices Values
                {
                    float x, y, z;
                    x = float.Parse(line.Split(' ')[1].Replace('.', ','));
                    y = float.Parse(line.Split(' ')[2].Replace('.', ','));
                    z = float.Parse(line.Split(' ')[3].Replace('.', ','));
                    list_VerticesArray.Add(new Vector4(x, y, z, 1));
                }
                else if (line.StartsWith("f ")) // Triangles Values
                {
                    int[] _triangle = new int[4];
                    try
                    {
                        _triangle[0] = int.Parse(line.Split(' ')[1]) - 1;
                        _triangle[1] = int.Parse(line.Split(' ')[2]) - 1;
                        _triangle[2] = int.Parse(line.Split(' ')[3]) - 1;
                        _triangle[3] = int.Parse(line.Split(' ')[4]) - 1;
                    }
                    catch
                    {
                        _triangle[0] = int.Parse(line.Split(' ')[1]) - 1;
                        _triangle[1] = int.Parse(line.Split(' ')[2]) - 1;
                        _triangle[2] = int.Parse(line.Split(' ')[3]) - 1;
                        _triangle[3] = int.Parse(line.Split(' ')[3]) - 1;
                    }

                    list_TrianglesArray.Add(_triangle);
                }
                else if (line.StartsWith("O "))
                {
                    ObjName = line.Substring(2);
                }
            }

            int[,] triangles = new int[list_TrianglesArray.Count, 4];
            for (int i = 0; i < list_TrianglesArray.Count; i++)
            {
                triangles[i, 0] = list_TrianglesArray[i][0];
                triangles[i, 1] = list_TrianglesArray[i][1];
                triangles[i, 2] = list_TrianglesArray[i][2];
                triangles[i, 3] = list_TrianglesArray[i][3];
            }

            MeshFilter meshFilter = new MeshFilter(list_VerticesArray.ToArray(), list_TrianglesArray);
            return new G_Object(ObjName, meshFilter);
        }

        static G_Object loadObj(string path)
        {
            string ObjName = "";
            List<Vector4> list_VerticesArray = new List<Vector4>();
            List<int[]> list_TrianglesArray = new List<int[]>();

            string[] Lines = File.ReadAllLines(path);

            foreach (var line in Lines)
            {
                if (line.StartsWith("v ")) // Vertices Values
                {
                    float x, y, z;
                    x = float.Parse(line.Split(' ')[1].Replace('.', ','));
                    y = float.Parse(line.Split(' ')[2].Replace('.', ','));
                    z = float.Parse(line.Split(' ')[3].Replace('.', ','));
                    list_VerticesArray.Add(new Vector4(x, y, z, 1));
                }
                else if (line.StartsWith("f ")) // Triangles Values
                {
                    int[] _triangle = new int[4];
                    try
                    {
                        _triangle[0] = int.Parse(line.Split(' ')[1]) - 1;
                        _triangle[1] = int.Parse(line.Split(' ')[2]) - 1;
                        _triangle[2] = int.Parse(line.Split(' ')[3]) - 1;
                        _triangle[3] = int.Parse(line.Split(' ')[4]) - 1;
                    }
                    catch
                    {
                        _triangle[0] = int.Parse(line.Split(' ')[1]) - 1;
                        _triangle[1] = int.Parse(line.Split(' ')[2]) - 1;
                        _triangle[2] = int.Parse(line.Split(' ')[3]) - 1;
                        _triangle[3] = int.Parse(line.Split(' ')[3]) - 1;
                    }

                    list_TrianglesArray.Add(_triangle);
                }
                else if (line.StartsWith("O "))
                {
                    ObjName = line.Substring(2);
                }
            }

            int[,] triangles = new int[list_TrianglesArray.Count, 4];
            for (int i = 0; i < list_TrianglesArray.Count; i++)
            {
                triangles[i, 0] = list_TrianglesArray[i][0];
                triangles[i, 1] = list_TrianglesArray[i][1];
                triangles[i, 2] = list_TrianglesArray[i][2];
                triangles[i, 3] = list_TrianglesArray[i][3];
            }

            MeshFilter meshFilter = new MeshFilter(list_VerticesArray.ToArray(), list_TrianglesArray);
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

        public static G_Object importObject(string path)
        {
            return loadObj(path);
        }
    }
}