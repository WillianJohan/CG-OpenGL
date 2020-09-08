using System;

namespace UFN_CG.HomeWork
{

    /*
        ============================== Computação Gráfica 2D – Transformações Geométricas 2D - Lista de exercícios ==========================================

    Desenvolva uma aplicação que inicialize uma matriz de transformações (matT), 
    inicialmente com valores de modo que ela seja uma matriz identidade. 
    
    Em seguida, 
    apresente ao usuário um menu para que ele escolha que transformação 
    ele deseja aplicar sobre o objeto (translação, rotação ou escala), 
    passando seus parâmetros (valores de translação tx e ty, ângulo de rotação e fatores de escala
    sx e sy) de acordo com a opção escolhida. 
    
    Então, 
    monte a matriz referente a transformação escolhida, 
    multiplique ela pela matriz de transformações (matT), e então 
    substitua os valores de matT pelo resultado. 
    
    Após, apresente novamente matT na tela (agora com valores atualizados), seguida do menu. 
    
    A ideia é ir acumulando as várias transformações em matT, conforme o desejo do usuário. 
        
    Quando o usuário terminar de inserir a sequência de transformações e escolher 
    ir para o próximo passo, a aplicação deve então passar a ler os valores de um 
    ponto (x,y) e então aplicar sobre ele matT, mostrando o resultado da transformação 
    aplicada sobre o ponto na tela.

    
    
    Utilize matrizes homogêneas e multiplicação de matrizes para a realização das transformações. 
    Não utilize equações algébricas.
    
     */

    public class Homework_TransformacoesGeometricas2D : IHomework
    {
        public void start()
        {
            Console.Clear();

            //Iniciando uma matriz 4x4 identidade
            Transform2D transform = new Transform2D();
            
            Console.WriteLine("Gerando um Transform:");
            exibirTransformacao(transform);
            exibirMesh(transform.Mesh);


            while (true)
            {
                // usuario escolhe que tipo de transformacao ele ira fazer (rotacao, translacao, escala),
                ExibirMenuDeTransformacoes();

                // passando seus parâmetros(valores de translação tx e ty, ângulo de rotação e fatores de escala sx e sy) de acordo com a opção escolhida. 
                int userChoice = Input.getInt("Escolha uma Opção: ");
                Vector2 vetorDeTransformacao = Vector2.Zero;
                switch (userChoice)
                {
                    case 1:
                        vetorDeTransformacao = Input.getVector2("Digite a translação");
                        transform.translate(vetorDeTransformacao);
                        break;
                    case 2:
                        vetorDeTransformacao = Input.getVector2("Digite a rotação em graus");
                        transform.rotate(vetorDeTransformacao);
                        break;
                    case 3:
                        vetorDeTransformacao = Input.getVector2("Digite a escala");
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
                exibirTransformacao(transform);
                exibirMesh(transform.Mesh);

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


        void exibirTransformacao(Transform2D transform)
        {
            Console.WriteLine("Transform\n" + transform);
        }
        
        void exibirMesh(Mesh mesh)
        {
            Console.WriteLine("Mesh\n" + mesh);
        }

    }
}
