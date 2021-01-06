using static RendererEngine.OpenGL.GL;
using System.Numerics;
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
            scene.LoadContent();
            
        }

        protected override void Update()
        {
            scene.virtualCamera.rotate(Vector3.UnitX , 45 * Time.DeltaTime);
            foreach (GameObject obj in scene.Objects)
            {
                obj.transform.translate(new Vector3(1, 0, 0) * Time.DeltaTime * 5);
                Debug.Log(obj.transform.Position.ToString());
            }
        }

        protected override void Render()
        {
            glClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

            // configura a viewport para pegar toda a janela
            glViewport(0, 0, (int)DisplayManager.WindowSize.X, (int)DisplayManager.WindowSize.Y);

            scene.DrawObjects();

            Glfw.SwapBuffers(DisplayManager.window);
        }

    }
}
