using System;
using System.Collections.Generic;

namespace UFN_CG
{
    class Program
    {
        static void Main(string[] args)
        {
            HomeWork.IHomework trabalho = new HomeWork.Homework_TransformacoesGeometricas2D();
            trabalho.start();
        }

        public static void print(string texto)
        {
            Console.WriteLine(texto);
        }
    }
}
