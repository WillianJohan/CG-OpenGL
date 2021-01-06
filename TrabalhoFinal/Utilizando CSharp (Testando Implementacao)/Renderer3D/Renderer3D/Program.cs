using System.Numerics;

namespace RendererEngine
{
    class Program
    {

        static void Main(string[] args)
        {
            //Iniciando o Game
            GameRuntimeStructure game = new Game(800, 600, "Teste", new Scene());
            game.Run();
        }

    }
}