using System;

namespace ConsoleAPP_ComputacaoGrafica
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector2 a = new Vector2(1,2);
            Vector2 b = new Vector2(2,3);

            Console.WriteLine(a+b);


            Vector3 aa = new Vector3(2,5,0);
            Vector3 bb = new Vector3(2,5,1);

            Console.WriteLine(aa + bb);
        }
    }
}
