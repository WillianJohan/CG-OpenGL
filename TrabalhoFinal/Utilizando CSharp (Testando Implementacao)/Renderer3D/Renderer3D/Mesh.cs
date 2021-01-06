using static RendererEngine.OpenGL.GL;

namespace RendererEngine
{
    public class Mesh : System.IDisposable
    {
        public float[] Vertices     { get; private set; }
        public float[] Normals      { get; private set; }
        public uint VAO             { get; private set; }
        public uint VBO_Vertices    { get; private set; }
        public uint VBO_Normals     { get; private set; }

        #region Constructors
        public Mesh()
        {
            Vertices = new float[0];
            Normals = new float[0];
        }

        public Mesh(float[] Vertices, float[] Normals)
        {
            this.Vertices = Vertices;
            this.Normals = Normals;
        }
        #endregion

        public unsafe void Load()
        {
            // Cria e dá um Bind no meu VAO =======================================
            VAO = glGenVertexArray();
            glBindVertexArray(VAO);


            // Cria o VBO dos Vertices ============================================
            VBO_Vertices = glGenBuffer();
            glBindBuffer(GL_ARRAY_BUFFER, VBO_Vertices); //Gera o buffer do ID especificado

            fixed (float* verticesPointer = &Vertices[0])
                glBufferData(GL_ARRAY_BUFFER, sizeof(float) * Vertices.Length, verticesPointer, GL_STATIC_DRAW);

            glEnableVertexAttribArray(0);
            glVertexAttribPointer(0, 3, GL_FLOAT, true, 0, (void*)0);


            // Cria o VBO das Normais ============================================
            VBO_Normals = glGenBuffer();
            glBindBuffer(GL_ARRAY_BUFFER, VBO_Normals); //Gera o buffer do ID especificado

            fixed (float* normalsPointer = &Normals[0])
                glBufferData(GL_ARRAY_BUFFER, sizeof(float) * Normals.Length, normalsPointer, GL_STATIC_DRAW);

            glEnableVertexAttribArray(1);
            glVertexAttribPointer(1, 3, GL_FLOAT, true, 0, (void*)0);
        }

        public void Render()
        {
            glBindVertexArray(VAO);
            glDrawArrays(GL_TRIANGLES, 0, Vertices.Length);
        }

        // IDisposable interface
        public void Dispose()
        {
            glDeleteBuffer(VBO_Vertices);
            glDeleteVertexArray(VAO);
        }
    }
}
