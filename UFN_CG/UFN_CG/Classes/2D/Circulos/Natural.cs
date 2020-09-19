using System;
using System.Collections.Generic;
using System.Text;

namespace UFN_CG.Circulos
{
    public class Natural
    {
        /// <summary>
        /// Retorna uma lista de pontos que formam um circulo a partir de um raio.
        /// </summary>
        /// <param name="raio">Raio do circulo</param>
        /// <returns>Retorna uma lista de coordenadas (X,Y)</returns>
        public static List<Vector2> ListOfPoints(int raio)
        {
            List<Vector2> listOfPoints = new List<Vector2>();

            float x = 0;
            double yAux = 0;

            double limite = raio * Math.Cos(Math.PI * 45 / 180);

            while (x <= limite) 
            {
                yAux = Math.Sqrt(raio * raio - x * x);
                float y = (int)Math.Round(yAux);

                listOfPoints.Add(new Vector2(x, y));
                listOfPoints.Add(new Vector2(y, x));
                listOfPoints.Add(new Vector2(y, -x));
                listOfPoints.Add(new Vector2(x, -y));
                listOfPoints.Add(new Vector2(-x, -y));
                listOfPoints.Add(new Vector2(-y, -x));
                listOfPoints.Add(new Vector2(-y, x));
                listOfPoints.Add(new Vector2(-x, y));

                x++;
            }


            return listOfPoints;
        }
    }
}

