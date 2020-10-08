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

        public Vector2 getPoint() 
        {
            float x = (((W.xMax - W.xMin) * (V.xMax - V.xMin)) / (W.xMax - W.xMin)) + V.xMin;
            float y = (((W.yMax - W.yMin) * (V.yMin - V.yMax)) / (W.yMax - W.yMin)) + V.yMax;
            return new Vector2(x, y);
        }
    }
}
