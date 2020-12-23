from Window import *
import glfw
from OpenGL.GL import *
import OpenGL.GL.shaders
import numpy as np


window = Window(1000,1000,"teste")











# Start Criando Objeto =====================================================
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

# End Criando Objeto =====================================================










# Especificação do Vertex Shader:
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















while not glfw.window_should_close(window.Canvas):
        
    glClear(GL_COLOR_BUFFER_BIT)
    glClearColor(0.2, 0.3, 0.3, 1.0)
    glViewport(0, 0, window.WIDTH, window.HEIGHT)

    glUseProgram(Shader_programm)

    glBindVertexArray(Vao)

    # Observe que, neste exemplo, passamos o valor 6 como parâmetro, pois o quadrado é formado por 2 triângulos,
    # cada um com 3 vértices... 2x3 = 6
    glDrawArrays(GL_TRIANGLES, 0, 6)

    glfw.poll_events()

    glfw.swap_buffers(window.Canvas)
    
    if (glfw.PRESS == glfw.get_key(window.Canvas, glfw.KEY_ESCAPE)):
        glfw.set_window_should_close(window.Canvas, True)
    
glfw.terminate()