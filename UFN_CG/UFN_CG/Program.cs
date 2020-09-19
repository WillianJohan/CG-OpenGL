using System;

namespace UFN_CG
{
    class Program
    {
        static void Main(string[] args)
        {

            void exibirMesh(Transform2D transformation)
            {
                print("transform: \n" + transformation);
                print("transform.TransformationMatrix: \n" + transformation.TransformationMatrix);
                
                Vector2[] pontos = new Vector2[]
                {
                    new Vector2(0,0) + transformation.Position,
                    new Vector2(0,1) + transformation.Position,
                    new Vector2(1,1) + transformation.Position
                };
                foreach (var p in pontos)
                {
                    Console.WriteLine("Ponto:" + (Vector2)((Vector3)p * transformation.TransformationMatrix));
                }
                Console.WriteLine("\n");
            }

            Transform2D tranform = new Transform2D();
            exibirMesh(tranform);

            tranform.translate(Input.getVector2("Digite uma translação."));
            exibirMesh(tranform);

            tranform.Scale = Input.getVector2("Digite uma escala:");
            exibirMesh(tranform);

            tranform.rotate(Input.getFloat("Digite uma rotacao"));
            exibirMesh(tranform);

        }

        public static void print(string texto)
        {
            Console.WriteLine(texto);
        }
    }
}
