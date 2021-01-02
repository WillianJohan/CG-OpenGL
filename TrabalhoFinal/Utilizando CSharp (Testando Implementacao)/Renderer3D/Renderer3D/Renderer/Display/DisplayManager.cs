using GLFW;
using static Renderer3D.OpenGL.GL;
using System.Numerics;
using System.Drawing;

namespace Renderer3D
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
            Glfw.Init();

            /*
            // informa qual versão do OpenGL está sendo utilizada
            Glfw.WindowHint(Hint.ContextVersionMajor, 3);
            Glfw.WindowHint(Hint.ContextVersionMinor, 3);
            Glfw.WindowHint(Hint.ContextVersionMajor, Profile.Core);
            */
            
            Glfw.WindowHint(Hint.Focused, true);
            Glfw.WindowHint(Hint.Resizable, false);
            


            
            //Criando de fato a window.
            window = Glfw.CreateWindow(width, height, title, Monitor.None, Window.None);

            // Verifica se a janela foi inicializada
            if (window == Window.None) 
                return;

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

        public static void CloseWindow() => Glfw.Terminate();

    }
}
