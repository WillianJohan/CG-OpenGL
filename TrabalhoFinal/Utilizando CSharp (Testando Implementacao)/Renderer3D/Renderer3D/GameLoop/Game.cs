using GLFW;

namespace Renderer3D.GameLoop
{
    public abstract class Game
    {
        protected int InitialWindowWidth { get; set; }
        protected int InitialWindowHeight { get; set; }
        protected string InitialWindowTitle { get; set; }

        protected Game(int initialWindowWidth, int initialWindowHeight, string initialWindowTitle)
        {
            this.InitialWindowWidth = initialWindowWidth;
            this.InitialWindowHeight = initialWindowHeight;
            this.InitialWindowTitle = initialWindowTitle;
        }

        public void Run() 
        {
            Initialize();
            Renderer.Display.DisplayManager.CreateWindow(InitialWindowWidth, InitialWindowHeight, InitialWindowTitle);
            LoadContent();

            while (!Glfw.WindowShouldClose(Renderer.Display.DisplayManager.window))
            {
                GameTime.DeltaTime = (float)Glfw.Time - GameTime.TotalElapsedSeconds;
                GameTime.TotalElapsedSeconds = (float)Glfw.Time;

                Update();
                
                Glfw.PollEvents();
                
                Render();
            }

            Renderer.Display.DisplayManager.CloseWindow();
        }

        protected abstract void Initialize();
        protected abstract void LoadContent();


        protected abstract void Update();
        protected abstract void Render();
    }
}
