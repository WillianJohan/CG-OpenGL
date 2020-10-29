# Este exemplo apresenta uma aplicação completa de OpenGL, que renderiza um triângulo na tela.
import glfw
from OpenGL.GL import *
import OpenGL.GL.shaders
import numpy as np

Window = None
Shader_programm = None
Vao = None
WIDTH = 800
HEIGHT = 600

#Função callback que é executada sempre que a janela for redimensionada
#Sempre que a tela for redimensionada, salvamos sua nova largura e altura nas variáveis globais acima
def redimensionaCallback(window, w, h):
    global WIDTH, HEIGHT
    WIDTH = w
    HEIGHT = h

def inicializaOpenGL():
    global Window, WIDTH, HEIGHT

    #Inicializa GLFW
    glfw.init()

    #Criação de uma janela
    Window = glfw.create_window(WIDTH, HEIGHT, "Exemplo - renderização de um triângulo", None, None)
    #Caso não seja possível criar a janela, a GLFW e a aplicação são terminadas
    if not Window:
        glfw.terminate()
        exit()

    #Registramos a função "redimensionaCallback" como sendo a função de redimensionamento
	#Isso significa que a função "redimensionaCallback" será chamada sempre que a janela for redimensionada,
	#seja pelo sistema ou pelo usuário
    glfw.set_window_size_callback(Window, redimensionaCallback)

    #Define o contexto atual do GLFW como sendo a janela criada acima. O contexto define
	#em qual janela o OpenGL irá funcionar, o que é essencial para que o programa funcione
    glfw.make_context_current(Window)

    #Buscamos informações a respeito do hardware (placa de vídeo) e a versão do OpenGL que a mesma da suporte
    print("Placa de vídeo: ",OpenGL.GL.glGetString(OpenGL.GL.GL_RENDERER))
    print("Versão do OpenGL: ",OpenGL.GL.glGetString(OpenGL.GL.GL_VERSION))

def inicializaObjetos():

    global Vao
    # Devido ao fato de que cada objeto que modelarmos possuir, geralmente, uma coleção
	# de buffers de informaçõees referentes aos seus vértices (tais como coordenadas dos vértices,
	# coordenadas de texturas, normais, cores, etc), utilizamos um objeto do tipo Vertex Attribute Object (VAO)
	# que "une" e "representa" todos os buffers do objeto em um único identificador.

	# Nós devemos especificar um VAO para cada objeto que estamos modelando.
	# No caso deste exemplo, vamos renderizar somente 1 triângulo, logo, precisamos somente de
	# 1 VAO para representá-lo.

	# Geramos o VAO, definindo um identificador para ele através glGenVertexArrays
    Vao = glGenVertexArrays(1)
    # Damos um bind no VAO, setando ele como VAO atual e colocando o mesmo no topo da máquina de estados do OpenGL
    glBindVertexArray(Vao)

    # Definição de um VBO para os vértices do triângulo
	# - Primeiramente, definimos em um vetor de float os vértices do triângulo;
	# - Em seguida, criamos uma cópia desses dados na placa gráfica através deu ma unidade denominada Vertex Buffer Object (VBO).
	# Para isso, nós geramos primeiramente um buffer vazio, através da função glGenBuffers, e então setamos esse buffer como buffer 
	# atual na máquina de estados do OpenGL através de glBindBuffer,e por fim copiamos os pontos para esse buffer através do glBufferData.
    points = [
		0.0, 0.5, 0.0, #cima
		0.5, -0.5, 0.0, #direita
		-0.5, -0.5, 0.0 #/esquerda
	]

    # Convertemos o array do Python para um array da biblioteca NumPy, pois é o tipo de array que o OpenGL trabalha
    points = np.array(points, dtype=np.float32)

    pvbo = glGenBuffers(1)
    glBindBuffer(GL_ARRAY_BUFFER, pvbo)
    glBufferData(GL_ARRAY_BUFFER, points, GL_STATIC_DRAW)
    # Ativamos o primeiro atributo do VAO (�ndice 0), que é o atributo referente ao buffer das posições dos vértices.
    glEnableVertexAttribArray(0)
    # E então definimos o layout do buffer de vértices:
	# - o primeiro parâmetro (0) significa que estamos definido o layout do atributo 0 (buffer de vértices)
	# - o segundo parâmetro (3) significa que esse buffer é formado por 3 variáveis (x,y, e z),
	# - o terceiro parâmetro, indica que as variáveis são do tipo float
	# - o quarto parâmetro indica que nóo desejamos normalizar os valores
    # - o quinto parâmetro é o byte offset entre os atributos, caso tenha sido especificado um único VBO para mais de um tipo de informação
    # - o sexto parâmetro é o offset do primeiro elemento, que no nosso caso, é 0, pois queremos todos os elementos do array
    #   -- Devido a um bug da biblioteca, precisamos passar None ao invés de 0
    glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 0, None)


    # Definição de um VBO para as cores do triângulo. Observe que passamos como parâmetro o valor 1
	# na chamada ao "glEnableVertexAttribArray", pois estamos ativando o segundo atributo deste VAO,
	# que são as cores dos vértices. Além disso, também passamos o parâmetro 1 na chamada ao "glVertexAttribPointer", 
	# pois estamos definindo o layout do segundo atributo.
    cores = [
		1.0, 0.0, 0.0, #vermelho
		0.0, 1.0, 0.0, #verde
		0.0, 0.0, 1.0  #azul
	]
    cores = np.array(cores, dtype=np.float32)
    cvbo = glGenBuffers(1)
    glBindBuffer(GL_ARRAY_BUFFER, cvbo)
    glBufferData(GL_ARRAY_BUFFER, cores, GL_STATIC_DRAW)
    glEnableVertexAttribArray(1)
    glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, 0, None)

def inicializaShaders():
    global Shader_programm
    # Especificação do Vertex Shader:
	# - O Vertex Shader é responsável por determinar a posição final de cada vértice do objeto
	# - a primeira linha especifica a versão da GLSL que estamos utilizando, no caso, 4.0.0
	# - em seguida definimos uma variável de entrada (in) do tipo vec3 (3 valores) chamada vp,
	# que receberá os valores dos vértices do triangulo no VAO especificado no Python
	# - a posição final do vértice é definida na variável gl_Position, que neste caso será o mesmo
	# valor de entrada (vp)
	# - a saída gl_Position deve ser um dado do tipo vec4 (4 valores), por isso adicionamos 1.0 no final
	# para o valor de w, indicando que o mesmo representa um ponto no espa�o
    vertex_shader = """
        #version 400
        layout(location = 0) in vec3 vertex_posicao;
        layout(location = 1) in vec3 vertex_cores;
        out vec3 cores;
        void main () {
            cores = vertex_cores;
            gl_Position = vec4 (vertex_posicao, 1.0);
        }
    """
    # Como os shaders são um programa "a parte", precisamos compilá-lo e verificar se não houve nenhum erro de compilação
    vs = OpenGL.GL.shaders.compileShader(vertex_shader, GL_VERTEX_SHADER)
    if not glGetShaderiv(vs, GL_COMPILE_STATUS):
        infoLog = glGetShaderInfoLog(vs, 512, None)
        print("Erro no vertex shader:\n", infoLog)

    # Especificação do Fragment Shader:
	# - o Fragment Shader é responsável por determinar a cor de cada fragmento da superfície do objeto
	# - a primeira linha especifica a versão da GLSL que estamos utilizando, no caso, 4.0.0
	# - a cor final é determinada pela variável frag_colour, que neste caso é fixa em um valor RGBA
	# de (0.5, 0.0, 0.5, 1.0), ou seja, magenta e sem transparencia.
    fragment_shader = """
        #version 400
        in vec3 cores;
		out vec4 frag_colour;
		void main () {
		    frag_colour = vec4 (cores, 1.0);
		}
    """
    # Do mesmo modo que o vertex shader, precisamos compilar o fragment shader e verificar se não houve nenhum erro de compilação
    fs = OpenGL.GL.shaders.compileShader(fragment_shader, GL_FRAGMENT_SHADER)
    if not glGetShaderiv(fs, GL_COMPILE_STATUS):
        infoLog = glGetShaderInfoLog(fs, 512, None)
        print("Erro no fragment shader:\n", infoLog)

    # Especificação do Shader Programm:
	# Após compilarmos os shaders, precisamos combiná-los em um único programa, denominado GPU Shader Program.
	# Para isso, chamamos a função compileProgram passando os dois shaders que irão formar o nosso shader program
    # e testamos se não houve nenhum erro de linkagem
    Shader_programm = OpenGL.GL.shaders.compileProgram(vs, fs)
    if not glGetProgramiv(Shader_programm, GL_LINK_STATUS):
        infoLog = glGetProgramInfoLog(Shader_programm, 512, None)
        print("Erro na linkagem do shader:\n", infoLog)

    glDeleteShader(vs)
    glDeleteShader(fs)

def inicializaRenderizacao():
    global Window, Shader_programm, Vao, WIDTH, HEIGHT

	# O triangulo é redesenhado o tempo todo, dentro de um laço de repetição
	# que é executado enquanto a janela não for fechada
    while not glfw.window_should_close(Window):
        # Limpamos o buffer de cores da tela
        glClear(GL_COLOR_BUFFER_BIT)
        glClearColor(0.2, 0.3, 0.3, 1.0)

        # Redefinimos o tamanho da viewport para o tamanho atual da janela, a cada frame, de modo que
		# o desenho se ajuste de acordo com o tamanho da tela
        glViewport(0, 0, WIDTH, HEIGHT)

        # Especificamos qual Shader Programm vamos utilizar
        glUseProgram(Shader_programm)

        # Setamos o objeto Vao como sendo o VAO atual na máquina de estados do OpenGL
        glBindVertexArray(Vao)

        # Desenhamos o triângulo especificado no vao
        glDrawArrays(GL_TRIANGLES, 0, 3)

        # Atualiamos outros eventos, tais como entradas pelo teclado, mouse, etc, caso ocorram
        glfw.poll_events()

        # Renderizamos na tela tudo aquilo que foi desenhado logo acima
        glfw.swap_buffers(Window)

        # Verificamos se a tecla ESC foi pressionada. Caso positivo, definimos que a tela deve ser
		# fechada na próxima volta do laço.
		# Para testar se outras teclas foram pressionadas, verifique o seguinte link:
		# http://www.glfw.org/docs/latest/group__input.html
        if (glfw.PRESS == glfw.get_key(Window, glfw.KEY_ESCAPE)):
            glfw.set_window_should_close(Window, True)
    
    glfw.terminate()

# Função principal
def main():
    inicializaOpenGL()
    inicializaObjetos()
    inicializaShaders()
    inicializaRenderizacao()

if __name__ == "__main__":
    main()