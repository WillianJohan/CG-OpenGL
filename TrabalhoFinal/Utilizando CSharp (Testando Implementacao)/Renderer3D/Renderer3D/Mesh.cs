using static RendererEngine.OpenGL.GL;

namespace RendererEngine
{
    public class Mesh : System.IDisposable
    {
        public float[] Vertices { get; set; }
        public uint VAO { get; private set; }
        public uint VBO { get; private set; }




        // IDisposable interface
        public void Dispose()
        {
            glDeleteBuffer(VBO);
            glDeleteVertexArray(VAO);
        }
    }
}
