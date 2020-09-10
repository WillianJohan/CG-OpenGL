using System;
using System.Collections.Generic;

namespace UFN_CG
{
    class Program
    {
        static void Main(string[] args)
        {
            Transform transform = new Transform();
            Mesh malha = new Mesh();
            
            transform.Position = new Vector3(1, 2, 0);
            transform.rotate(new Vector3(45, 0, 0));
            transform.Scale = new Vector3(1, 2, 1);
            
            Vector3[] shape = malha.getShape(transform.Position, transform.Rotation, transform.Scale);
            
            foreach(Vector3 ponto in shape)
                Console.WriteLine(ponto);
        }
    }
}
