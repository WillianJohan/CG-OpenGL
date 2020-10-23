using System.Drawing;

namespace UFN_CG
{
    public class WorldToScreenPoint
    {
        public struct Window 
        {
            public int xMin, xMax, yMin, yMax;

            public Window(int xMin, int yMin, int xMax, int yMax)
            {
                this.xMin = xMin;
                this.xMax = xMax;
                this.yMin = yMin;
                this.yMax = yMax;
            }
        }

        public struct Viewport
        {
            public int xMin, xMax, yMin, yMax;

            public Viewport(int xMin, int yMin, int xMax, int yMax)
            {
                this.xMin = xMin;
                this.xMax = xMax;
                this.yMin = yMin;
                this.yMax = yMax;
            }
        }

        Window W;
        Viewport V;

        public WorldToScreenPoint(Window w, Viewport v)
        {
            W = w;
            V = v;
        }

        public WorldToScreenPoint(Viewport v)
        {
            W = new Window(-1, -1, 1, 1);
            V = v;
        }

        public Point getPoint(float x, float y)
        {
            return new Point(
                ((((int)x - W.xMin) * (V.xMax - V.xMin)) / (W.xMax - W.xMin)) + V.xMin,
                ((((int)y - W.yMin) * (V.yMin - V.yMax)) / (W.yMax - W.yMin)) + V.yMax);
        }

        public Point getPoint(int x, int y)
        {
            return new Point(
                (((x - W.xMin) * (V.xMax - V.xMin)) / (W.xMax - W.xMin)) + V.xMin,
                (((y - W.yMin) * (V.yMin - V.yMax)) / (W.yMax - W.yMin)) + V.yMax);
        }
    }
}
