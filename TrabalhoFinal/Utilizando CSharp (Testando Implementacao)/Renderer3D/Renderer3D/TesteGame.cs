using static Renderer3D.OpenGL.GL;
using GLFW;
using System;

namespace Renderer3D
{
    class TesteGame : GameLoop.Game
    {
        public TesteGame(int initialWindowWidth, int initialWindowHeight, string initialWindowTitle) : base(initialWindowWidth, initialWindowHeight, initialWindowTitle)
        {
            this.InitialWindowWidth = initialWindowWidth;
            this.InitialWindowHeight = initialWindowHeight;
            this.InitialWindowTitle = initialWindowTitle;
        }

        protected override void Initialize()
        {
        }

        protected override void LoadContent()
        {
        }
       
        protected override void Update()
        {
        }

        protected override void Render()
        {
            glClearColor(MathF.Sin(GameLoop.GameTime.TotalElapsedSeconds), 0, 0, 1);
            glClear(GL_COLOR_BUFFER_BIT);

            Glfw.SwapBuffers(Renderer.Display.DisplayManager.window);
        }

    }
}
