using System;
using System.Collections.Generic;
using System.Text;

namespace UFN_CG.Retas
{
    public static class Bresenham
    {
        public static List<Vector2Int> ListOfPoints(Vector2Int P0, Vector2Int P1)
        {
            List<Vector2Int> points = new List<Vector2Int>();

            Vector2Int D = P1 - P0;

            if (D.x == 0) // Se delta X for 0, é uma reta Vertical
            {
                for (int y = P0.y; y <= P1.y; y++)
                    points.Add(new Vector2Int(P0.x, y));
                return points;
            }

            float m = D.y / D.x;
            int ajuste = 1;
            int offset = 0;

            if (m <= 1) // A reta está mais deitada, logo, o x cresce mais rápido que o y
            {
                int delta = D.y * 2;
                int limiar = D.x;
                int limiarInc = D.x * 2;
                int y = P0.y;

                for(int x = P0.x; x <= P1.x; x++) 
                {
                    points.Add(new Vector2Int(x, y));
                    offset += delta;
                    if(offset >= limiar)
                    {
                        y += ajuste;
                        limiar += limiarInc;
                    }
                }

            }  
            else if(m > 1)
            {
                int delta = D.x * 2;
                int limiar = D.y;
                int limiarInc = D.y * 2;
                int x = P0.x;

                for (int y = P0.y; y <= P1.y; y++)
                {
                    points.Add(new Vector2Int(x, y));
                    offset += delta;
                    if (offset >= limiar)
                    {
                        x += ajuste;
                        limiar += limiarInc;
                    }
                }
            }
            

            return points;

        }
    }
}
