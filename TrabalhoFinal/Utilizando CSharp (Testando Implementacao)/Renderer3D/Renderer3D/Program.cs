using System.Numerics;

namespace RendererEngine
{
    class Program
    {

        static void Main(string[] args)
        {
            //Criando um Objeto 3D
            GraphicObject objQueGira = new GraphicObject("Objeto Simples");
            objQueGira.transform.Position = new Vector3(400, 300, -10);
            objQueGira.transform.Scale = new Vector3(150, 100, 1);
            objQueGira.Vertices = new float[]
            {
                -0.5f, 0.5f, 1f, 0f, 0f, // top left
                0.5f, 0.5f, 0f, 1f, 0f,// top right
                -0.5f, -0.5f, 0f, 0f, 1f, // bottom left

                0.5f, 0.5f, 0f, 1f, 0f,// top right
                0.5f, -0.5f, 0f, 1f, 1f, // bottom right
                -0.5f, -0.5f, 0f, 0f, 1f, // bottom left
            };

            //Criando a cena
            Scene cenaTeste = new Scene("Cena Teste");
            Scene.virtualCamera.IsOrtographic = true;
            cenaTeste.Objects.Add(objQueGira);

            //Iniciando o Game
            GameRuntimeStructure game = new Game(800, 600, "Teste", cenaTeste);
            game.Run();
        }

    }
}