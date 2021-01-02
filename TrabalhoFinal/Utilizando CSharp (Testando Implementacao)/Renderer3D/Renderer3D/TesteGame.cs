using static Renderer3D.OpenGL.GL;
using Renderer3D.Renderer;
using GLFW;
using System;
using System.Numerics;

namespace Renderer3D
{
    class TesteGame : GameLoop.Game
    {
        uint vao;
        uint vbo;
        Shader shader;
        VirtualCamera cam;
        public TesteGame(int initialWindowWidth, int initialWindowHeight, string initialWindowTitle) : base(initialWindowWidth, initialWindowHeight, initialWindowTitle)
        {
            this.InitialWindowWidth = initialWindowWidth;
            this.InitialWindowHeight = initialWindowHeight;
            this.InitialWindowTitle = initialWindowTitle;
        }

        protected override void Initialize()
        {
        }

        protected unsafe override void LoadContent()
        {
            
            shader = new Shader("E:\\6 - GitHub\\UFN_ComputacaoGrafica\\TrabalhoFinal\\Utilizando CSharp (Testando Implementacao)\\Renderer3D\\Renderer3D\\Renderer\\Shader\\BasicShader2.shader");
            shader.Load();

            // Criando VAO e VBO
            vao = glGenVertexArray();
            vbo = glGenBuffer();

            glBindVertexArray(vao);
            glBindBuffer(GL_ARRAY_BUFFER, vbo);


            float[] vertices =
            {
                -0.5f, 0.5f, 1f, 0f, 0f, // top left
                0.5f, 0.5f, 0f, 1f, 0f,// top right
                -0.5f, -0.5f, 0f, 0f, 1f, // bottom left

                0.5f, 0.5f, 0f, 1f, 0f,// top right
                0.5f, -0.5f, 0f, 1f, 1f, // bottom right
                -0.5f, -0.5f, 0f, 0f, 1f, // bottom left
            };

            fixed(float* v = &vertices[0])
            {
                glBufferData(GL_ARRAY_BUFFER, sizeof(float) * vertices.Length, v, GL_STATIC_DRAW);
            }

            glVertexAttribPointer(0, 2, GL_FLOAT, false, 5 * sizeof(float), (void*)0);
            glEnableVertexAttribArray(0);

            glVertexAttribPointer(1, 3, GL_FLOAT, false, 5 * sizeof(float), (void*)(2 * sizeof(float)));
            glEnableVertexAttribArray(1);

            glBindBuffer(GL_ARRAY_BUFFER, 0);
            glBindVertexArray(0);

            cam = new VirtualCamera();
            cam.IsOrtographic = true;
        }
       
        protected override void Update()
        {
        }

        protected override void Render()
        {
            glClearColor(0,0,0,0);
            glClear(GL_COLOR_BUFFER_BIT);

            // Transformacao do objeto // =========================================================
            Vector2 position = new Vector2(400, 300);
            Vector2 scale = new Vector2(150, 100);
            float rotation = MathF.Sin(GameLoop.GameTime.TotalElapsedSeconds) * MathF.PI * 1f;

            Matrix4x4 t = Matrix4x4.CreateTranslation(position.X, position.Y, 0);
            Matrix4x4 s = Matrix4x4.CreateScale(scale.X, scale.Y, 1);
            Matrix4x4 r = Matrix4x4.CreateRotationZ(rotation);

            shader.SetMatrix4x4("model", s * r * t);            

            shader.Use();
            shader.SetMatrix4x4("projection", cam.ProjectionMatrix);

            // ====================================================================================

            glBindVertexArray(vao);
            glDrawArrays(GL_TRIANGLES, 0, 6);

            Glfw.SwapBuffers(DisplayManager.window);
        }

    }
}
