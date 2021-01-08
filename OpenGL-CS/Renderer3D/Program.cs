using System.Numerics;

namespace RendererEngine
{
    class Program
    {

        static void Main(string[] args)
        {
			// CRIA DO GAMEOBJECT =========================================================
			
			#region Vertices and Normals
			
			float[] v = new float[]
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
			float[] n = new float[]
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
			
			#endregion
            
			Mesh objMesh = new Mesh(v, n);
			
			GameObject obj = new GameObject("Simple Object", new Transform(), objMesh);
			obj.transform.Scale *= 50;

			// SCENE ======================================================================
			Scene scene = new Scene("SimpleScene");
			
			scene.Objects.Add(obj);
			scene.spotLight.transform.Position.Z = 1;

			scene.virtualCamera.Position.X = -150f;
			scene.virtualCamera.Position.Y = -100f;
			scene.virtualCamera.Position.Z = 5f;
			scene.virtualCamera.Perspective.zFar = 10000;

			// INIT GAME WINDOW ===========================================================
			Runtime game = new Game(800, 600, scene.SceneName, scene);
            game.Run();
        }

    }
}