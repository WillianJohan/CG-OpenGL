using System;
using System.Collections.Generic;
using System.Text;

namespace UFN_CG
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
            throw new NotImplementedException();
        }
    }
}
