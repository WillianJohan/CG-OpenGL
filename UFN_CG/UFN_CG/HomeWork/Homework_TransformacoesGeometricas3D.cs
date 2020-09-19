using System;

namespace UFN_CG.HomeWork
{

    /*
        ============================== Computação Gráfica 3D – Transformações Geométricas 3D ==========================================

                Desenvolva o mesmo programa da tarefa do dia Lista de exercícios - Computação Gráfica 2D - Transformações Geométricas 2D, mas agora para 3 dimensões, 
                considerando as transformações de translação, escala, rotação em x, rotação em y e rotaçao em z.
    
     */

    public class Homework_TransformacoesGeometricas3D : IHomework
    {
        public void start()
        {
            Console.Clear();

            //Matriz de transformação
            Transform transform = new Transform();

            Console.WriteLine("Gerando um Transform:");
            exibirTransformacao(transform.TransformationMatrix);

            //Criando pontos em um plano 2D
            Vector3[] pontos = new Vector3[]
            {
                new Vector3(0,0,0),
                new Vector3(1,0,0),
                new Vector3(0,1,0),
                new Vector3(1,1,0),
                new Vector3(1,0,1),
                new Vector3(0,1,1),
                new Vector3(1,1,1)
            };

            exibirMesh(pontos, transform.TransformationMatrix);


            while (true)
            {
                // usuario escolhe que tipo de transformacao ele ira fazer (rotacao, translacao, escala),
                ExibirMenuDeTransformacoes();

                // passando seus parâmetros(valores de translação tx e ty, ângulo de rotação e fatores de escala sx e sy) de acordo com a opção escolhida. 
                int userChoice = Input.getInt("Escolha uma Opção: ");
                Vector3 vetorDeTransformacao = Vector3.Zero;
                switch (userChoice)
                {
                    case 1:
                        vetorDeTransformacao = Input.getVector3("Digite a translação");
                        transform.translate(vetorDeTransformacao);
                        break;
                    case 2:
                        vetorDeTransformacao = Input.getVector3("Digite a rotação em graus para cada dimensão");
                        transform.rotate(vetorDeTransformacao);
                        break;
                    case 3:
                        vetorDeTransformacao = Input.getVector3("Digite a escala");
                        transform.Scale = vetorDeTransformacao;
                        break;
                    case 0:
                        Console.WriteLine("\n\n.......O programa será finalizado.......\n\n");
                        return;
                    default:
                        Console.WriteLine("Opção não reconhecida, programa contuará a execução....");
                        break;
                }

                //Após, apresente novamente matT na tela (agora com valores atualizados),
                exibirTransformacao(transform.TransformationMatrix);
                exibirMesh(pontos, transform.TransformationMatrix);

                //Mostrar Menu novamente
            }

        }

        void ExibirMenuDeTransformacoes()
        {
            Console.WriteLine("Escolha o tipo de transformação que deseja realizar:");
            Console.WriteLine("1 -> Translação");
            Console.WriteLine("2 -> Rotação");
            Console.WriteLine("3 -> Escala");
            Console.WriteLine("0 -> Sair do programa");
        }


        void exibirTransformacao(Matrix4x4 MatT)
        {
            Console.WriteLine("Matriz de Transformação:\n" + MatT);
        }

        void exibirMesh(Vector3[] pontos, Matrix4x4 MatT)
        {
            foreach (var p in pontos)
            {
                var vetor = new Vector4(p.x, p.y, p.z);
                Console.WriteLine("Ponto:\n" +  vetor * MatT);
            }
        }
    }
}
