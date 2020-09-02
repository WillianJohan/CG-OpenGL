using System;

namespace UFN_CG
{
    class Program
    {
        static void Main(string[] args)
        {
            IHomework homework = new Homework_TransformacoesGeometricas2D();
            homework.start();
        }
    }
}
