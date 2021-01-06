using GLFW;
using static RendererEngine.OpenGL.GL;
using System.Numerics;
using System.Drawing;

namespace RendererEngine
{
    public static class DisplayManager
    {
        public static Window window         { get; set; }
        public static Vector2 WindowSize    { get; set; }

        public static void CreateWindow(int width, int height, string title)
        {
            // Define Window Size =============================================
            WindowSize = new Vector2(width, height);

            // Initialize GLFW ================================================
            Debug.Log("Initializing Glfw");
            if (Glfw.Init())
                Debug.Log("Glfw Initialized");
            else
                Debug.ErrorLog("Failed to initialize Gflw");

            Glfw.WindowHint(Hint.Focused, true);
            Glfw.WindowHint(Hint.Resizable, false);


            // Creating the Window =============================================
            Debug.Log("Creating a Window");
            window = Glfw.CreateWindow(width, height, title, Monitor.None, Window.None);

            // Checks if created
            if (window == Window.None)
            {
                Debug.ErrorLog("Failed to create a Window\nClosing Application.");
                return;
            }

            // Center the window in the middle of the screen
            Rectangle screen = Glfw.PrimaryMonitor.WorkArea;
            int x = (screen.Width - width) / 2;
            int y = (screen.Height - height) / 2;
            Glfw.SetWindowPosition(window, x, y);

            // References the window created for the Glfw context
            Glfw.MakeContextCurrent(window);
            Import(Glfw.GetProcAddress); //GL Method



            glViewport(0, 0, width, height);
            Glfw.SwapInterval(0); // VSync off (1 to Turn ON)
        }

        public static void CloseWindow()
        {
            Debug.Log("Closing Window");
            Glfw.Terminate();
        }

    }
}
