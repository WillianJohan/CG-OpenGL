using System;
using System.Collections.Generic;

namespace UFN_CG.Retas
{
    public static class DDA
    {
        public static List<Vector2Int> ListOfPoints(Vector2Int P0, Vector2Int P1)
        {
            List<Vector2Int> points = new List<Vector2Int>();

            Vector2Int delta = P1 - P0;

            if(delta.x == 0) // Se delta X for 0, é uma reta Vertical
            {
                for (int y = (int)P0.y; y <= P1.y; y++)
                    points.Add(new Vector2Int(P0.x, y));
                return points;
            }

            float m = delta.y / delta.x;
            Vector2 newPoints = new Vector2(P0.x, P0.y);

            if (m <= 1) // A reta está mais deitada, logo, o x cresce mais rápido que o y
                for (; newPoints.x <= P1.x; newPoints.x++, newPoints.y += m)
                    points.Add(new Vector2Int((int)newPoints.x, (int)Math.Round(newPoints.y)));
            else if(m > 1) // A reta está mais de pé, logo, o y cresce mais rápido que o x
                for (; newPoints.y <= P1.y; newPoints.x += (1/m), newPoints.y++)
                    points.Add(new Vector2Int((int)Math.Round(newPoints.x), (int)newPoints.y));

            return points;

        }
    }
}
