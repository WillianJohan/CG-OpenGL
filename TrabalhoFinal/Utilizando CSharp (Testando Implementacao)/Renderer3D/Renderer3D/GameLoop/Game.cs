using GLFW;

namespace Renderer3D
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
            DisplayManager.CreateWindow(InitialWindowWidth, InitialWindowHeight, InitialWindowTitle);
            LoadContent();

            while (!Glfw.WindowShouldClose(DisplayManager.window))
            {
                Time.DeltaTime = (float)Glfw.Time - Time.TotalElapsedSeconds;
                Time.TotalElapsedSeconds = (float)Glfw.Time;

                Update();

                //Glfw.SwapBuffers(DisplayManager.window);
                Glfw.PollEvents();
                
                Render();
            }

            DisplayManager.CloseWindow();
        }

        protected abstract void Initialize();
        protected abstract void LoadContent();


        protected abstract void Update();
        protected abstract void Render();
    }
}
