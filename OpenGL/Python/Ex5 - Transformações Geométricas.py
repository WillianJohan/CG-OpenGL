# Transformações geométricas

import glfw
from OpenGL.GL import *
import OpenGL.GL.shaders
import numpy as np

Window = None
Shader_programm = None
Vao = None
WIDTH = 800
HEIGHT = 600

# Valores para transformação do objeto
Tx = 0.0
Ty = 0.0
Sx = 1.0
Sy = 1.0
Angulo = 0

ShaderButtonReleased = True
ShaderSelection = 0

def redimensionaCallback(window, w, h):
    global WIDTH, HEIGHT
    WIDTH = w
    HEIGHT = h

def inicializaOpenGL():
    global Window, WIDTH, HEIGHT

    #Inicializa GLFW
    glfw.init()

    #Criação de uma janela
    Window = glfw.create_window(WIDTH, HEIGHT, "Exercício", None, None)
    if not Window:
        glfw.terminate()
        exit()

    glfw.set_window_size_callback(Window, redimensionaCallback)
    glfw.make_context_current(Window)

    print("Placa de vídeo: ",OpenGL.GL.glGetString(OpenGL.GL.GL_RENDERER))
    print("Versão do OpenGL: ",OpenGL.GL.glGetString(OpenGL.GL.GL_VERSION))

def inicializaObjetos():

    global Vao
    # Vao do quadrado
    Vao = glGenVertexArrays(1)
    glBindVertexArray(Vao)

    # VBO dos vértices do quadrado
    points = [
        # triângulo 1
		0.5, 0.5, 0.0, #vertice superior direito
		0.5, -0.5, 0.0, #vertice inferior direito
		-0.5, -0.5, 0.0, #vertice inferior esquerdo
		#triângulo 2
		-0.5, 0.5, 0.0, #vertice superior esquerdo
		0.5, 0.5, 0.0, #vertice superior direito
		-0.5, -0.5, 0.0 #vertice inferior esquerdo
	]
    points = np.array(points, dtype=np.float32)
    pvbo = glGenBuffers(1)
    glBindBuffer(GL_ARRAY_BUFFER, pvbo)
    glBufferData(GL_ARRAY_BUFFER, points, GL_STATIC_DRAW)
    glEnableVertexAttribArray(0)
    glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 0, None)

    # VBO das cores
    cores = [
		#triângulo 1
		1.0, 1.0, 0.0,#amarelo
		0.0, 1.0, 1.0,#ciano
		1.0, 0.0, 1.0,#magenta
		#triângulo 2
		0.0, 1.0, 1.0,#ciano
		1.0, 1.0, 0.0,#amarelo
		1.0, 0.0, 1.0,#magenta
	]
    cores = np.array(cores, dtype=np.float32)
    cvbo = glGenBuffers(1)
    glBindBuffer(GL_ARRAY_BUFFER, cvbo)
    glBufferData(GL_ARRAY_BUFFER, cores, GL_STATIC_DRAW)
    glEnableVertexAttribArray(1)
    glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, 0, None)

def inicializaShaders():
    global Shader_programm, ShaderSelection
    
    # Especificação do Vertex Shader:
    vertex_shader = None
    fragment_shader = None

    if(ShaderSelection == 0):
        print("Usando Shader 0")
        vertex_shader = """
            #version 400
            layout(location = 0) in vec3 vertex_posicao; //vem da modelagem de um objeto no python
            layout(location = 1) in vec3 vertex_cores; //vem da modelagem de um objeto no python
            uniform mat4 matriz; //matriz 4x4 vem do python, pois ela tem o modificador "uniform"
            out vec3 cores;
            void main () {
                cores = vertex_cores;
                gl_Position = matriz * vec4 (vertex_posicao.x*2, vertex_posicao.y*2, vertex_posicao.z, 1.0);
            }
        """

        fragment_shader = """
            #version 400
            in vec3 cores;
            out vec4 frag_colour;
            void main () {
                frag_colour = vec4 (cores, 1.0);
            }
        """
    elif(ShaderSelection == 1):
        print("Usando Shader 1")
        vertex_shader = """
            #version 400
            layout(location = 0) in vec3 vertex_posicao; //vem da modelagem de um objeto no python
            layout(location = 1) in vec3 vertex_cores; //vem da modelagem de um objeto no python
            uniform mat4 matriz; //matriz 4x4 vem do python, pois ela tem o modificador "uniform"
            out vec3 cores;
            void main () {
                cores = vertex_cores;
                gl_Position = matriz * vec4 (vertex_posicao, 1.0);
            }
        """
        fragment_shader = """
            #version 400
            in vec3 cores;
            out vec4 frag_colour;
            void main () {
                frag_colour = vec4 (1.0-cores.r, 1.0-cores.g, 1.0-cores.b, 1.0);
            }
        """

    # Vertex Shader
    vs = OpenGL.GL.shaders.compileShader(vertex_shader, GL_VERTEX_SHADER)
    if not glGetShaderiv(vs, GL_COMPILE_STATUS):
        infoLog = glGetShaderInfoLog(vs, 512, None)
        print("Erro no vertex shader:\n", infoLog)

    # Fragment Shader
    fs = OpenGL.GL.shaders.compileShader(fragment_shader, GL_FRAGMENT_SHADER)
    if not glGetShaderiv(fs, GL_COMPILE_STATUS):
        infoLog = glGetShaderInfoLog(fs, 512, None)
        print("Erro no fragment shader:\n", infoLog)

    # Especificação do Shader Programm:
    Shader_programm = OpenGL.GL.shaders.compileProgram(vs, fs)
    if not glGetProgramiv(Shader_programm, GL_LINK_STATUS):
        infoLog = glGetProgramInfoLog(Shader_programm, 512, None)
        print("Erro na linkagem do shader:\n", infoLog)

    glDeleteShader(vs)
    glDeleteShader(fs)

def transformaQuadrado():
    global Tx, Ty, Sx, Sy, Angulo
    
    #matriz de translação
    translacao = np.array([
        [1.0, 0.0, 0.0, Tx], #joga o objeto Tx unidades para a direita
        [0.0, 1.0, 0.0, Ty], #joga o objeto Ty unidades para baixo
        [0.0, 0.0, 1.0, 0.0], 
        [0.0, 0.0, 0.0, 1.0]], np.float32)

    #matriz de rotação de 30 graus em torno do eixo Z
    angulo = np.radians(Angulo)
    cos = np.cos(angulo)
    sen = np.sin(angulo)
    rotacao = np.array([
        [cos, -sen, 0.0, 0.0],
        [sen, cos, 0.0, 0.0],
        [0.0, 0.0, 1.0, 0.0],
        [0.0, 0.0, 0.0, 1.0]
    ])

    # Matriz de Escala
    escala = np.array([
        [Sx, 0.0, 0.0, 0.0],
        [0.0, Sy, 0.0, 0.0],
        [0.0, 0.0, 1.0, 0.0],
        [0.0, 0.0, 0.0, 1.0]
    ]) 

    #combinamos as transformacoes, multiplicando as matrizes
    transformacao = (translacao.dot(rotacao))    
    transformacao = (transformacao.dot(escala))
    
    
    #E passamos a matriz para o Vertex Shader.
    #descobre o endereço de memória (de vídeo) da variável matriz lá no shader
    transformLoc = glGetUniformLocation(Shader_programm, "matriz") 
    #passa os valores da matriz aqui do python para a memória de vídeo no endereço descoberto acima
    glUniformMatrix4fv(transformLoc, 1, GL_TRUE, transformacao)

def inicializaRenderizacao():
    global Window, Shader_programm, Vao, WIDTH, HEIGHT

    while not glfw.window_should_close(Window):
        glClear(GL_COLOR_BUFFER_BIT)
        glClearColor(0.2, 0.3, 0.3, 1.0)
        glViewport(0, 0, WIDTH, HEIGHT)

        glUseProgram(Shader_programm) #ativa o shader

        glBindVertexArray(Vao) #ativa o objeto a ser renderizado

        transformaQuadrado() #configura o valor da variavel "matriz" do shader, que corresponde a transformações geométricas

        glDrawArrays(GL_TRIANGLES, 0, 6) #renderiza o objeto

        glfw.poll_events()

        glfw.swap_buffers(Window)
        
        userInputEvents()

        if (glfw.PRESS == glfw.get_key(Window, glfw.KEY_ESCAPE)):
            glfw.set_window_should_close(Window, True)
    
    glfw.terminate()

def userInputEvents():
    global Tx, Ty, Sx, Sy, Angulo, ShaderSelection, ShaderButtonReleased

    # Translação
    if (glfw.PRESS == glfw.get_key(Window, glfw.KEY_UP)):
        Ty += 0.01
    if (glfw.PRESS == glfw.get_key(Window, glfw.KEY_DOWN)):
        Ty -= 0.01
    if (glfw.PRESS == glfw.get_key(Window, glfw.KEY_RIGHT)):
        Tx += 0.01
    if (glfw.PRESS == glfw.get_key(Window, glfw.KEY_LEFT)):
        Tx -= 0.01

    # Escala
    if (glfw.PRESS == glfw.get_key(Window, glfw.KEY_KP_8)):
        Sy += 0.01
    if (glfw.PRESS == glfw.get_key(Window, glfw.KEY_KP_2)):
        Sy -= 0.01
    if (glfw.PRESS == glfw.get_key(Window, glfw.KEY_KP_6)):
        Sx += 0.01
    if (glfw.PRESS == glfw.get_key(Window, glfw.KEY_KP_4)):
        Sx -= 0.01   
    if (glfw.PRESS == glfw.get_key(Window, glfw.KEY_KP_5)):
        Sy = 1.0
        Sx = 1.0        

    # Rotacao
    if (glfw.PRESS == glfw.get_key(Window, glfw.KEY_HOME)):
        Angulo += 0.01
    if (glfw.PRESS == glfw.get_key(Window, glfw.KEY_END)):
        Angulo -= 0.01                                    

    # Seleção do Shader    
    if (glfw.PRESS == glfw.get_key(Window, glfw.KEY_S) and ShaderButtonReleased == True):        
        ShaderSelection = (ShaderSelection + 1) % 2
        ShaderButtonReleased = False
        inicializaShaders()
    
    if(ShaderButtonReleased == False):
        if (glfw.PRESS != glfw.get_key(Window, glfw.KEY_S)):
            ShaderButtonReleased = True

# Função principal
def main():
    inicializaOpenGL()
    inicializaObjetos()
    inicializaShaders()
    inicializaRenderizacao()

if __name__ == "__main__":
    main()