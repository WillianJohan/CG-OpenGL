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
            float playerVel = 100 * Time.DeltaTime;

            //scene.virtualCamera.rotate(Vector3.UnitZ , 1 * Time.DeltaTime);
            if (Input.GetKeyDown(Keys.W))
                scene.virtualCamera.Position.Z += playerVel;
            if (Input.GetKeyDown(Keys.S))
                scene.virtualCamera.Position.Z -= playerVel;
            if (Input.GetKeyDown(Keys.A))
                scene.virtualCamera.Position.X -= playerVel;
            if (Input.GetKeyDown(Keys.D))
                scene.virtualCamera.Position.X += playerVel;
            if (Input.GetKeyDown(Keys.Space))
                scene.virtualCamera.Position.Y += playerVel;
            if (Input.GetKeyDown(Keys.LeftShift))
                scene.virtualCamera.Position.Y -= playerVel;
            foreach (GameObject obj in scene.Objects)
            {
                //obj.transform.rotate(Vector3.UnitY, 2 * Time.DeltaTime);
            }
        }

        protected override void Render()
        {
            glClearColor(0.2f, 0.3f, 0.5f, 1.0f);
            glClear(GL_COLOR_BUFFER_BIT);
            glClear(GL_DEPTH_BUFFER_BIT);

            // configura a viewport para pegar toda a janela
            glViewport(0, 0, (int)DisplayManager.WindowSize.X, (int)DisplayManager.WindowSize.Y);

            scene.DrawObjects();

            Glfw.SwapBuffers(DisplayManager.window);
        }

    }
}
