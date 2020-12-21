import glfw
from OpenGL.GL import *


class Window:
    def __init__(self, WIDTH: int, HEIGHT: int, TITLE_WINDOW: str):
        self.WIDTH = WIDTH
        self.HEIGHT = HEIGHT
        self.TITLE_WINDOW = TITLE_WINDOW
        self.Canvas = None

        self._initialize_Glfw()

        print("Placa de vídeo: ", OpenGL.GL.glGetString(OpenGL.GL.GL_RENDERER))
        print("Versão do OpenGL: ", OpenGL.GL.glGetString(OpenGL.GL.GL_VERSION))


    def _initialize_Glfw(self):
        # Inicializa GLFW
        glfw.init()

        # Criação de uma janela
        self.Canvas = glfw.create_window(
            self.WIDTH, self.HEIGHT, self.TITLE_WINDOW, None, None)
        if not self.Canvas:
            glfw.terminate()
            exit()

        glfw.set_window_size_callback(self.Canvas, self._ResizeCallBack)
        glfw.make_context_current(self.Canvas)


    def _ResizeCallBack(self, WIDTH: int, HEIGHT: int):
        self.WIDTH = WIDTH
        self.HEIGHT = HEIGHT
