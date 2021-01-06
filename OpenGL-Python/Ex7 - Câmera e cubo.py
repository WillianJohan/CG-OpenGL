# Câmera

# Neste exemplo, especificamos uma câmera virtual através da aplicação de transformações de projeção
import glfw
from OpenGL.GL import *
import OpenGL.GL.shaders
import numpy as np

Window = None
Shader_programm = None
Vao = None
WIDTH = 800
HEIGHT = 600

Tempo_entre_frames = 0 #variavel utilizada para movimentar a camera

#Variáveis referentes a câmera virtual e sua projeção

Cam_speed = 2.0 #velocidade da camera, 1 unidade por segundo
Cam_yaw_speed = 30.0 #velocidade de rotação da câmera em y, 10 graus por segundo
Cam_pos = np.array([0.0, 0.0, 2.0]) #posicao inicial da câmera
Cam_yaw = 0.0 #ângulo de rotação da câmera em y

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
    if not Window:
        glfw.terminate()
        exit()

    glfw.set_window_size_callback(Window, redimensionaCallback)
    glfw.make_context_current(Window)

    print("Placa de vídeo: ",OpenGL.GL.glGetString(OpenGL.GL.GL_RENDERER))
    print("Versão do OpenGL: ",OpenGL.GL.glGetString(OpenGL.GL.GL_VERSION))

def inicializaObjetos():

    global Vao
    # Vao do cubo
    Vao = glGenVertexArrays(1)
    glBindVertexArray(Vao)

    # VBO dos vértices do quadrado
    points = [
		#face frontal
		0.5, 0.5, 0.5,#0
		0.5, -0.5, 0.5,#1
		-0.5, -0.5, 0.5,#2
		-0.5, 0.5, 0.5,#3
		0.5, 0.5, 0.5,
		-0.5, -0.5, 0.5,
		#face trazeira
		0.5, 0.5, -0.5,#4
		0.5, -0.5, -0.5,#5
		-0.5, -0.5, -0.5,#6
		-0.5, 0.5, -0.5,#7
		0.5, 0.5, -0.5,
		-0.5, -0.5, -0.5,
		#face esquerda
		-0.5, -0.5, 0.5,
		-0.5, 0.5, 0.5,
		-0.5, -0.5, -0.5,
		-0.5, -0.5, -0.5,
		-0.5, 0.5, -0.5,
		-0.5, 0.5, 0.5,
		#face direita
		0.5, -0.5, 0.5,
		0.5, 0.5, 0.5,
		0.5, -0.5, -0.5,
		0.5, -0.5, -0.5,
		0.5, 0.5, -0.5,
		0.5, 0.5, 0.5,
		#face baixo
		-0.5, -0.5, 0.5,
		0.5, -0.5, 0.5,
		0.5, -0.5, -0.5,
		0.5, -0.5, -0.5,
		-0.5, -0.5, -0.5,
		-0.5, -0.5, 0.5,
		#face cima
		-0.5, 0.5, 0.5,
		0.5, 0.5, 0.5,
		0.5, 0.5, -0.5,
		0.5, 0.5, -0.5,
		-0.5, 0.5, -0.5,
		-0.5, 0.5, 0.5,
	]
    points = np.array(points, dtype=np.float32)
    pvbo = glGenBuffers(1)
    glBindBuffer(GL_ARRAY_BUFFER, pvbo)
    glBufferData(GL_ARRAY_BUFFER, points, GL_STATIC_DRAW)
    glEnableVertexAttribArray(0)
    glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 0, None)


    # VBO das cores
    cores = [
		#face frontal - vermelha
		1.0, 0.0, 0.0,
		1.0, 0.0, 0.0,
		1.0, 0.0, 0.0,
		1.0, 0.0, 0.0,
		1.0, 0.0, 0.0,
		1.0, 0.0, 0.0,
		#face trazeira - verde
		0.0, 1.0, 0.0,
		0.0, 1.0, 0.0,
		0.0, 1.0, 0.0,
		0.0, 1.0, 0.0,
		0.0, 1.0, 0.0,
		0.0, 1.0, 0.0,
		#face esquerda - azul
		0.0, 0.0, 1.0,
		0.0, 0.0, 1.0,
		0.0, 0.0, 1.0,
		0.0, 0.0, 1.0,
		0.0, 0.0, 1.0,
		0.0, 0.0, 1.0,
		#face direita - ciano
		0.0, 1.0, 1.0,
		0.0, 1.0, 1.0,
		0.0, 1.0, 1.0,
		0.0, 1.0, 1.0,
		0.0, 1.0, 1.0,
		0.0, 1.0, 1.0,
		#face baixo - magenta
		1.0, 0.0, 1.0,
		1.0, 0.0, 1.0,
		1.0, 0.0, 1.0,
		1.0, 0.0, 1.0,
		1.0, 0.0, 1.0,
		1.0, 0.0, 1.0,
		#face cima - amarelo
		1.0, 1.0, 0.0,
		1.0, 1.0, 0.0,
		1.0, 1.0, 0.0,
		1.0, 1.0, 0.0,
		1.0, 1.0, 0.0,
		1.0, 1.0, 0.0,
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
    vertex_shader = """
        #version 400
        layout(location = 0) in vec3 vertex_posicao;
        layout(location = 1) in vec3 vertex_cores;
        uniform mat4 matriz, view, proj;
        out vec3 cores;
        void main () {
            cores = vertex_cores;
            gl_Position = proj*view*matriz*vec4 (vertex_posicao, 1.0);
        }
    """
    vs = OpenGL.GL.shaders.compileShader(vertex_shader, GL_VERTEX_SHADER)
    if not glGetShaderiv(vs, GL_COMPILE_STATUS):
        infoLog = glGetShaderInfoLog(vs, 512, None)
        print("Erro no vertex shader:\n", infoLog)

    # Especificação do Fragment Shader:
    fragment_shader = """
        #version 400
        in vec3 cores;
		out vec4 frag_colour;
		void main () {
		    frag_colour = vec4 (cores, 1.0);
		}
    """
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

def transformaCubo1():
    #matriz de translação
    translacao = np.array([
        [1.0, 0.0, 0.0, 0.7], 
        [0.0, 1.0, 0.0, -0.5], 
        [0.0, 0.0, 1.0, 0.0], 
        [0.0, 0.0, 0.0, 1.0]], np.float32)

    #matriz de rotação em torno do eixo Z
    angulo = np.radians(30)
    cos, sen = np.cos(angulo), np.sin(angulo)
    rotacao = np.array([
        [cos, -sen, 0.0, 0.0],
        [sen, cos, 0.0, 0.0],
        [0.0, 0.0, 1.0, 0.0],
        [0.0, 0.0, 0.0, 1.0]
    ])

    #combinamos as transformacoes, multiplicando as matrizes
    #transformacao = np.identity(4)
    transformacao = translacao
    
    #E passamos a matriz para o Vertex Shader.
    transformLoc = glGetUniformLocation(Shader_programm, "matriz")
    glUniformMatrix4fv(transformLoc, 1, GL_TRUE, transformacao)

def transformaCubo2():
    #matriz de translação
    translacao = np.array([
        [1.0, 0.0, 0.0, -0.5], 
        [0.0, 1.0, 0.0, -0.5], 
        [0.0, 0.0, 1.0, 0.0], 
        [0.0, 0.0, 0.0, 1.0]], np.float32)

    #matriz de rotação em torno do eixo Z
    angulo = np.radians(30)
    cos, sen = np.cos(angulo), np.sin(angulo)
    rotacao = np.array([
        [cos, -sen, 0.0, 0.0],
        [sen, cos, 0.0, 0.0],
        [0.0, 0.0, 1.0, 0.0],
        [0.0, 0.0, 0.0, 1.0]
    ])

    #combinamos as transformacoes, multiplicando as matrizes
    #transformacao = translacao.dot(rotacao)
    #transformacao = np.identity(4)
    transformacao = translacao
    
    #E passamos a matriz para o Vertex Shader.
    transformLoc = glGetUniformLocation(Shader_programm, "matriz")
    glUniformMatrix4fv(transformLoc, 1, GL_TRUE, transformacao)

def especificaMatrizVisualizacao():

    # Especificação da matriz de visualização, que é definida com valores de translação e
	# rotação inversos da "posição" da câmera, pois é o mundo que se movimenta ao redor da
	# câmera, e não a câmera que se movimenta ao redor do mundo.   

    #posicao da camera
    translacaoCamera = np.array([
        [1.0, 0.0, 0.0, -Cam_pos[0]], 
        [0.0, 1.0, 0.0, -Cam_pos[1]], 
        [0.0, 0.0, 1.0, -Cam_pos[2]], 
        [0.0, 0.0, 0.0, 1.0]], np.float32)
    
    #orientacao da camera (rotação em y)
    angulo = np.radians(-Cam_yaw)
    cos, sen = np.cos(angulo), np.sin(angulo)
    rotacaoCamera = np.array([
        [cos, 0.0, sen, 0.0],
        [0.0, 1.0, 0.0, 0.0],
        [-sen, 0.0, cos, 0.0],
        [0.0, 0.0, 0.0, 1.0]
    ])

    visualizacao = rotacaoCamera.dot(translacaoCamera)

    transformLoc = glGetUniformLocation(Shader_programm, "view")
    glUniformMatrix4fv(transformLoc, 1, GL_TRUE, visualizacao)

def especificaMatrizProjecao():
    #Especificação da matriz de projeção perspectiva.
    znear = 0.1 #recorte z-near
    zfar = 100.0 #recorte z-far
    fov = np.radians(67.0) #campo de visão
    aspecto = WIDTH/HEIGHT #aspecto

    a = 1/(np.tan(fov/2)*aspecto)
    b = 1/(np.tan(fov/2))
    c = (zfar + znear) / (znear - zfar)
    d = (2*znear*zfar) / (znear - zfar)
    projecao = np.array([
        [a,   0.0, 0.0,  0.0],
        [0.0, b,   0.0,  0.0],
        [0.0, 0.0, c,    d],
        [0.0, 0.0, -1.0, 0.0]
    ])

    transformLoc = glGetUniformLocation(Shader_programm, "proj")
    glUniformMatrix4fv(transformLoc, 1, GL_TRUE, projecao)

def inicializaCamera():
    especificaMatrizVisualizacao()
    especificaMatrizProjecao()

def trataTeclado():
    global Cam_pos, Cam_yaw, Cam_yaw_speed, Tempo_entre_frames
    if (glfw.PRESS == glfw.get_key(Window, glfw.KEY_ESCAPE)):
            glfw.set_window_should_close(Window, True)

    if (glfw.PRESS == glfw.get_key(Window, glfw.KEY_A)):
        Cam_pos[0] -= Cam_speed * Tempo_entre_frames

    if (glfw.PRESS == glfw.get_key(Window, glfw.KEY_D)):
        Cam_pos[0] += Cam_speed * Tempo_entre_frames

    if (glfw.PRESS == glfw.get_key(Window, glfw.KEY_PAGE_UP)):
        Cam_pos[1] += Cam_speed * Tempo_entre_frames

    if (glfw.PRESS == glfw.get_key(Window, glfw.KEY_PAGE_DOWN)):
        Cam_pos[1] -= Cam_speed * Tempo_entre_frames

    if (glfw.PRESS == glfw.get_key(Window, glfw.KEY_W)):
        Cam_pos[2] -= Cam_speed * Tempo_entre_frames

    if (glfw.PRESS == glfw.get_key(Window, glfw.KEY_S)):
        Cam_pos[2] += Cam_speed * Tempo_entre_frames

    if (glfw.PRESS == glfw.get_key(Window, glfw.KEY_LEFT)):
        Cam_yaw += Cam_yaw_speed * Tempo_entre_frames

    if (glfw.PRESS == glfw.get_key(Window, glfw.KEY_RIGHT)):
        Cam_yaw -= Cam_yaw_speed * Tempo_entre_frames


def inicializaRenderizacao():
    global Window, Shader_programm, Vao, WIDTH, HEIGHT, Tempo_entre_frames

    tempo_anterior = glfw.get_time()

    #Ativação do teste de profundidade. Sem ele, o OpenGL não sabe que faces devem ficar na frente e que faces devem ficar atrás.
    glEnable(GL_DEPTH_TEST)
    
    while not glfw.window_should_close(Window):
        #calcula quantos segundos se passaram entre um frame e outro
        tempo_frame_atual = glfw.get_time()
        Tempo_entre_frames = tempo_frame_atual - tempo_anterior
        tempo_anterior = tempo_frame_atual

        #limpa a tela e limpa os buffers de cores e de profundidade
        glClearColor(0.2, 0.3, 0.3, 1.0)        
        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT)
        
        #configura a viewport para pegar toda a janela
        glViewport(0, 0, WIDTH, HEIGHT)

        glUseProgram(Shader_programm) #ativa o shader programm
        inicializaCamera() #configura a câmera e a projeção

        glBindVertexArray(Vao) #ativa o vao do cubo

        transformaCubo1() #desloca o cubo para a direita
        glDrawArrays(GL_TRIANGLES, 0, 36) #renderiza o cubo

        transformaCubo2() #desloca o cubo para a esquerda
        glDrawArrays(GL_TRIANGLES, 0, 36) #renderiza o cubo

        glfw.poll_events() #recebe as interações de mouse e teclado

        glfw.swap_buffers(Window) #faz a troca de buffers para que a renderização ocorra
        
        trataTeclado() #trata das interações do usuário com o teclado/mouse
    
    glfw.terminate()

# Função principal
def main():
    inicializaOpenGL()
    inicializaObjetos()
    inicializaShaders()
    inicializaRenderizacao()

if __name__ == "__main__":
    main()