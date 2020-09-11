using System;
using System.Collections.Generic;

namespace UFN_CG
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix4x4 r = Matrix4x4.RotationMatrix(0,0,0);
            Matrix4x4 t = Matrix4x4.TranslationMatrix(45, 10, 10);
            Matrix4x4 s = Matrix4x4.ScaleMatrix(4, 2, 1);
                        
            Vector3[] pontos = new Vector3[]
            {
                new Vector3(0,0,0),
                new Vector3(0,0,1),
                new Vector3(1,0,0),
                new Vector3(1,0,1)
            };


        }

        public static void print(string texto)
        {
            Console.WriteLine(texto);
        }
    }
}
