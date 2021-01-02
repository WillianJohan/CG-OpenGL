namespace Renderer3D
{
    class Program
    {

        static void Main(string[] args)
        {
            Game game = new TesteGame(800, 600, "Teste");
            game.Run();
        }

    }
}