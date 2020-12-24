namespace Renderer3D
{
    class Program
    {

        static void Main(string[] args)
        {
            GameLoop.Game game = new TesteGame(800, 600, "Teste");
            game.Run();
        }

    }
}