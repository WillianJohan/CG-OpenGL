using static RendererEngine.OpenGL.GL;
using GLFW;
using System;
using System.Numerics;

namespace RendererEngine
{
    public class Game : GameRuntimeStructure
    {
        
        protected Scene scene { get; set; }
        
        public Game(int initialWindowWidth, int initialWindowHeight, string initialWindowTitle, Scene scene) : base(initialWindowWidth, initialWindowHeight, initialWindowTitle)
        {
            this.scene = scene;
        }

        protected override void Initialize()
        {
        }

        protected unsafe override void LoadContent()
        {
            foreach(GameObject obj in scene.Objects)
                obj.Load();
        }
       
        protected override void Update()
        {
        }

        protected override void Render()
        {
            glClearColor(0,0,0,0);
            glClear(GL_COLOR_BUFFER_BIT);

            foreach (GameObject obj in scene.Objects)
                obj.Render();

            Glfw.SwapBuffers(DisplayManager.window);
        }

    }
}
