using System;
using System.Collections.Generic;
using System.Text;

namespace UFN_CG.Circulos
{
    public class PontoMedio
    {
        /// <summary>
        /// Retorna uma lista de pontos que formam um circulo a partir de um raio.
        /// </summary>
        /// <param name="raio">Raio do circulo</param>
        /// <returns>Retorna uma lista de coordenadas (X,Y)</returns>
        public static List<Vector2> ListOfPoints(int raio)
        {
            List<Vector2> listOfPoints = new List<Vector2>();

            int p = 1 - raio;
            int x = 0;
            int y = raio;

            listOfPoints.AddRange(packOfPoints(x, y));

            while (true)
            {
                if(p < 0)       // x incrementa, e o próximo y não decrementa
                {
                    x++;
                    p += 2 * x + 1;
                }
                else if(p>=0)   // x incrementa e o próximo y decrementa
                {
                    x++;
                    y--;
                    p += 2 * x - 2 * y + 1;
                }
                if (x >= y) break;

                listOfPoints.AddRange(packOfPoints(x, y));
            }

            return listOfPoints;
        }

        static List<Vector2> packOfPoints(int x, int y)
        {
            List<Vector2> listOfPoints = new List<Vector2>();
            listOfPoints.Add(new Vector2(x, y));
            listOfPoints.Add(new Vector2(y, x));
            listOfPoints.Add(new Vector2(y, -x));
            listOfPoints.Add(new Vector2(x, -y));
            listOfPoints.Add(new Vector2(-x, -y));
            listOfPoints.Add(new Vector2(-y, -x));
            listOfPoints.Add(new Vector2(-y, x));
            listOfPoints.Add(new Vector2(-x, y));
            return listOfPoints;
        }

    }
}
