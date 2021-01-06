using System.Numerics;

namespace RendererEngine
{
    class Program
    {

        static void Main(string[] args)
        {

			float[] objVertex = new float[]
			{
				//face frontal
				 0.5f,  0.5f, 0.5f,
				 0.5f, -0.5f, 0.5f,
				-0.5f, -0.5f, 0.5f,
				-0.5f,  0.5f, 0.5f,
				 0.5f,  0.5f, 0.5f,
				-0.5f, -0.5f, 0.5f,
				
				//face trazeira
				 0.5f,  0.5f, -0.5f,
				 0.5f, -0.5f, -0.5f,
				-0.5f, -0.5f, -0.5f,
				-0.5f,  0.5f, -0.5f,
				 0.5f,  0.5f, -0.5f,
				-0.5f, -0.5f, -0.5f,
				
				//face esquerda
				-0.5f, -0.5f,  0.5f,
				-0.5f,  0.5f,  0.5f,
				-0.5f, -0.5f, -0.5f,
				-0.5f, -0.5f, -0.5f,
				-0.5f,  0.5f, -0.5f,
				-0.5f,  0.5f,  0.5f,
				
				//face direita
				0.5f, -0.5f,  0.5f,
				0.5f,  0.5f,  0.5f,
				0.5f, -0.5f, -0.5f,
				0.5f, -0.5f, -0.5f,
				0.5f,  0.5f, -0.5f,
				0.5f,  0.5f,  0.5f,
				
				//face baixo
				-0.5f, -0.5f,  0.5f,
				 0.5f, -0.5f,  0.5f,
				 0.5f, -0.5f, -0.5f,
				 0.5f, -0.5f, -0.5f,
				-0.5f, -0.5f, -0.5f,
				-0.5f, -0.5f,  0.5f,
				
				//face cima
				-0.5f, 0.5f,  0.5f,
				 0.5f, 0.5f,  0.5f,
				 0.5f, 0.5f, -0.5f,
				 0.5f, 0.5f, -0.5f,
				-0.5f, 0.5f, -0.5f,
				-0.5f, 0.5f,  0.5f
			};
			float[] objNormals = new float[]
			{
				//face frontal
				0.0f, 0.0f, 1.0f,
				0.0f, 0.0f, 1.0f,
				0.0f, 0.0f, 1.0f,
				0.0f, 0.0f, 1.0f,
				0.0f, 0.0f, 1.0f,
				0.0f, 0.0f, 1.0f,
				//face trazeira
				0.0f, 0.0f, -1.0f,
				0.0f, 0.0f, -1.0f,
				0.0f, 0.0f, -1.0f,
				0.0f, 0.0f, -1.0f,
				0.0f, 0.0f, -1.0f,
				0.0f, 0.0f, -1.0f,
				//face esquerda
				-1.0f, 0.0f, 0.0f,
				-1.0f, 0.0f, 0.0f,
				-1.0f, 0.0f, 0.0f,
				-1.0f, 0.0f, 0.0f,
				-1.0f, 0.0f, 0.0f,
				-1.0f, 0.0f, 0.0f,          
				//face direita
				1.0f, 0.0f, 0.0f,
				1.0f, 0.0f, 0.0f,
				1.0f, 0.0f, 0.0f,
				1.0f, 0.0f, 0.0f,
				1.0f, 0.0f, 0.0f,
				1.0f, 0.0f, 0.0f,
				//face inferior
				0.0f, -1.0f, 0.0f,
				0.0f, -1.0f, 0.0f,
				0.0f, -1.0f, 0.0f,
				0.0f, -1.0f, 0.0f,
				0.0f, -1.0f, 0.0f,
				0.0f, -1.0f, 0.0f,
				//face superior
				0.0f, 1.0f, 0.0f,
				0.0f, 1.0f, 0.0f,
				0.0f, 1.0f, 0.0f,
				0.0f, 1.0f, 0.0f,
				0.0f, 1.0f, 0.0f,
				0.0f, 1.0f, 0.0f
			};
			GameObject simpleObject = new GameObject("Simple Object", new Transform(), new Mesh(objVertex, objNormals));

			Scene simpleScene = new Scene("SimpleScene");
			simpleScene.Objects.Add(simpleObject);
			simpleScene.spotLight.transform.Position.X = -2f;
			simpleScene.virtualCamera.Position.Z = 10f;

            Runtime game = new Game(800, 600, simpleScene.SceneName, simpleScene);
            game.Run();
        }

    }
}