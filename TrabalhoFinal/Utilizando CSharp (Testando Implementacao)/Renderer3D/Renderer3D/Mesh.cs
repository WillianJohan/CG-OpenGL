using static RendererEngine.OpenGL.GL;

namespace RendererEngine
{
    public class Mesh : System.IDisposable
    {
        public float[] Vertices     { get; private set; }
        public uint VAO             { get; private set; }
        public uint VBO             { get; private set; }

        #region Constructors
        public Mesh()
        {
            Vertices = new float[0];
        }

        public Mesh(float[] Vertices)
        {
            this.Vertices = Vertices;
        }
        #endregion

        public unsafe void Load()
        {
            // Cria e dá um Bind no meu VAO =======================================
            VAO = glGenVertexArray();
            glBindVertexArray(VAO);


            // Cria o VBO =========================================================
            VBO = glGenBuffer();
            glBindBuffer(GL_ARRAY_BUFFER, VBO); //Gera o buffer do ID especificado

            fixed (float* verticesPointer = &Vertices[0])
                glBufferData(GL_ARRAY_BUFFER, sizeof(float) * Vertices.Length, verticesPointer, GL_STATIC_DRAW);

            glVertexAttribPointer(0, 3, GL_FLOAT, true, 0, (void*)0);
            glEnableVertexAttribArray(0);

        }

        public void Render()
        {
            glBindVertexArray(VAO);
            glDrawArrays(GL_TRIANGLES, 0, Vertices.Length);
        }

        // IDisposable interface
        public void Dispose()
        {
            glDeleteBuffer(VBO);
            glDeleteVertexArray(VAO);
        }
    }
}
