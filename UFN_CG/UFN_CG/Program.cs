using System;
using System.Collections.Generic;

namespace UFN_CG
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix4x4 m1 = Matrix4x4.Identity();
            Matrix4x4 m2 = Matrix4x4.Identity();
            Console.WriteLine(m1==m2);
        }
    }
}
