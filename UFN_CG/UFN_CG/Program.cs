using System;
using System.Collections.Generic;

namespace UFN_CG
{
    class Program
    {
        static void Main(string[] args)
        {
            //Curva de Bezier
            Console.WriteLine("Curva de Bezier");
            Vector2 pInicial = new Vector2(0, 0);
            Vector2 pFinal = new Vector2( 5, 0);
            
            Vector2 p1 = new Vector2(1, 8);
            Vector2 p2 = new Vector2(2, -10);
            
            List<Vector2> listaDePontos = Curvas.Bezier.ListOfPoints(pInicial,pFinal,p1,p2);
            
            foreach (Vector2 ponto in listaDePontos)
                Console.WriteLine(ponto);

            //Curva de Hermite
            Console.WriteLine("\n\nCurva de Hermite");
            pInicial = new Vector2(0, 0);
            pFinal = new Vector2(5, 0);

            p1 = new Vector2(1, 8);
            p2 = new Vector2(2, -10);

            listaDePontos = Curvas.Hermite.ListOfPoints(pInicial, pFinal, p1, p2);

            foreach (Vector2 ponto in listaDePontos)
                Console.WriteLine(ponto);

        }
    }
}
