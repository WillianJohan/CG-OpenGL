using GLFW;
using static RendererEngine.OpenGL.GL;
using System.Numerics;
using System.Drawing;

namespace RendererEngine
{
    public static class DisplayManager
    {
        public static Window window { get; set; }
        public static Vector2 WindowSize { get; set; }

        public static void CreateWindow(int width, int height, string title)
        {
            // Define o tamanho da window
            WindowSize = new Vector2(width, height);

            // Inicializa GLFW
            Debug.Log("Initializing Glfw");
            if (Glfw.Init())
                Debug.Log("Glfw Initialized");
            else
                Debug.ErrorLog("Failed to initialize Gflw");

            /*
            // informa qual versão do OpenGL está sendo utilizada
            Glfw.WindowHint(Hint.ContextVersionMajor, 3);
            Glfw.WindowHint(Hint.ContextVersionMinor, 3);
            Glfw.WindowHint(Hint.ContextVersionMajor, Profile.Core);
            */

            Glfw.WindowHint(Hint.Focused, true);
            Glfw.WindowHint(Hint.Resizable, false);

            //Criando de fato a window.
            Debug.Log("Creating a Window");
            window = Glfw.CreateWindow(width, height, title, Monitor.None, Window.None);
            
            // Verifica se a janela foi inicializada
            if (window == Window.None)
            {
                Debug.ErrorLog("Failed to create a Window\nClosing Application.");
                return;
            }
                            

            //Centraliza a janela no meio da tela
            Rectangle screen = Glfw.PrimaryMonitor.WorkArea;
            int x = (screen.Width - width) / 2;
            int y = (screen.Height - height) / 2;
            Glfw.SetWindowPosition(window, x, y);


            // Referencia o window criado para o contexto do Glfw
            Glfw.MakeContextCurrent(window);
            Import(Glfw.GetProcAddress); //GL Method

            glViewport(0, 0, width, height);
            Glfw.SwapInterval(0); // VSync off (1 para ativar)
        }

        public static void CloseWindow()
        {
            Debug.Log("Closing Window");
            Glfw.Terminate();
        }

    }
}
