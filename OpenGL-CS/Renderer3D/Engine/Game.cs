using static RendererEngine.OpenGL.GL;
using GLFW;

namespace RendererEngine
{
    public class Game : Runtime
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
            // Render all content of specific scene
        }

        protected override void Update()
        {
        }

        protected override void Render()
        {
            glClearColor(0,0,0,0);
            glClear(GL_COLOR_BUFFER_BIT);

            // Render all content of specific scene

            Glfw.SwapBuffers(DisplayManager.window);
        }

    }
}
