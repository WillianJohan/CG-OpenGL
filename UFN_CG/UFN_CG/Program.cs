using System;

namespace UFN_CG
{
    class Program
    {
        static void Main(string[] args)
        {
            HomeWork.IHomework hw = new HomeWork.TransformacoesGeometricas2D();
            hw.start();
        }

        public static void print(string texto)
        {
            Console.WriteLine(texto);
        }
    }
}
