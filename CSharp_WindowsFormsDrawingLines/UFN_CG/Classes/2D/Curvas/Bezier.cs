using System.Collections.Generic;

namespace UFN_CG.Curvas
{
    public static class Bezier
    {
        //Formula: 
        //  x = (1-t)³*p0x + 3*(1-t)²*t*p1x + 3*(1-t)*t²*p2x + t³*p3x
        //  y = (1-t)³*p0y + 3*(1-t)²*t*p1y + 3*(1-t)*t²*p2y + t³*p3y


        /// <summary>
        /// Retorna uma lista de pontos em sequencia que forma uma curva de Bezier.
        /// </summary>
        /// <param name="pInicial">Ponto inicial da curva</param>
        /// <param name="P1">Ponto de distorção inicial</param>
        /// <param name="P2">Segundo ponto de distorção</param>
        /// <param name="pFinal">Ponto final da curva</param>
        /// <returns>Retorna uma lista de coordenadas (X,Y)</returns>
        public static List<Vector2> ListOfPoints(Vector2 pInicial,Vector2 pFinal, Vector2 P1, Vector2 P2)
        {
            List<Vector2> listOfPoints = new List<Vector2>();
            
            //Define variaveis de controle e auxiliares de calculo
            Vector2 point = new Vector2(0,0);
            float t = 0;
            float a, b, c, d;

            while (t <= 1) {
                a = (1 - t) * (1 - t) * (1 - t);
                b = 3 * (1 - t) * (1 - t) * t;
                c = 3 * (1 - t) * t * t;
                d = t * t * t;

                point.x = (a * pInicial.x) + (b * P1.x) + (c * P2.x) + (d * pFinal.x);
                point.y = (a * pInicial.y) + (b * P1.y) + (c * P2.y) + (d * pFinal.y);

                listOfPoints.Add(point);
                t += 0.01f;
            }

            return listOfPoints;
        }
    }
}
