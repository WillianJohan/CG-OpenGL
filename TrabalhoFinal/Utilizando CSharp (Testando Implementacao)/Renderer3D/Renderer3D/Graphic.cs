using static Renderer3D.OpenGL.GL;
using Renderer3D.Renderer;
using GLFW;
using System;
using System.Numerics;

namespace Renderer3D
{
    public abstract class Graphic
    {
        public Shader shader { get; set; }
        public float[] Vertices { get; set; }
        protected uint vao;
        protected uint vbo;

        public unsafe void Load()
        {
            // Verificar dps
            shader = new Shader("..\\..\\..\\Renderer\\Shader\\BasicShader2.shader");
            shader.Load();

            // Criando VAO e VBO
            vao = glGenVertexArray();
            vbo = glGenBuffer();

            glBindVertexArray(vao);
            glBindBuffer(GL_ARRAY_BUFFER, vbo);

            //====================================
            //Aqui havia a definição dos vertices
            //====================================

            fixed (float* v = &Vertices[0])
            {
                glBufferData(GL_ARRAY_BUFFER, sizeof(float) * Vertices.Length, v, GL_STATIC_DRAW);
            }

            glVertexAttribPointer(0, 2, GL_FLOAT, false, 5 * sizeof(float), (void*)0);
            glEnableVertexAttribArray(0);

            glVertexAttribPointer(1, 3, GL_FLOAT, false, 5 * sizeof(float), (void*)(2 * sizeof(float)));
            glEnableVertexAttribArray(1);

            glBindBuffer(GL_ARRAY_BUFFER, 0);
            glBindVertexArray(0);
        }

        public void Render() => Renderer();
        protected abstract void Renderer();
    }
}
