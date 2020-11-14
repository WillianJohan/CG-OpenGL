using System.Collections.Generic;

namespace UFN_CG.Curvas
{
    public static class Hermite
    {
        //Formula: 
        //  x = (2t³ -3t² +1)p1x + (t³ -2t² +t)m1x + (-2t³ +3t²)p2x + (t³ -t²)m2x
        //  y = (2t³ -3t² +1)p1y + (t³ -2t² +t)m1y + (-2t³ +3t²)p2y + (t³ -t²)m2y

        /// <summary>
        /// Retorna uma lista de pontos em sequencia que forma uma curva de Hermite.
        /// </summary>
        /// <param name="pInicial">Ponto inicial da curva</param>
        /// <param name="M1">Direção que a curva irá se dirigir ao inicializar a curva</param>
        /// <param name="M2">Direção que a curvá irá se dirigir ao atingir o ponto final da curva</param>
        /// <param name="pFinal">Ponto final da curva</param>
        /// <returns>Retorna uma lista de coordenadas (X,Y)</returns>
        public static List<Vector2> ListOfPoints(Vector2 pInicial, Vector2 pFinal, Vector2 M1, Vector2 M2)
        {
            List<Vector2> listOfPoints = new List<Vector2>();

            //Define variaveis de controle e auxiliares de calculo
            Vector2 point = new Vector2(0, 0);
            float t = 0;
            float a, b, c, d;

            while (t <= 1)
            {
                a = 2 * t * t * t - 3 * t * t + 1;
                b = t * t * t - 2 * t * t + t;
                c = -2 * t * t * t + 3 * t * t;
                d = t * t * t - t * t;

                point.x = (a * pInicial.x) + (b * M1.x) + (c * pFinal.x) + (d * M2.x);
                point.y = (a * pInicial.y) + (b * M1.y) + (c * pFinal.y) + (d * M2.y);

                listOfPoints.Add(point);
                t += 0.01f;
            }

            return listOfPoints;
        }
    }
}
