import glfw
from OpenGL.GL import *


class Window:
    def __init__(self, WIDTH: int, HEIGHT: int, TITLE_WINDOW: str):
        self.WIDTH = WIDTH
        self.HEIGHT = HEIGHT
        self.TITLE_WINDOW = TITLE_WINDOW
        self.WINDOW = None

        self._CreateAndInitGLFW()

        print("Placa de vídeo: ", OpenGL.GL.glGetString(OpenGL.GL.GL_RENDERER))
        print("Versão do OpenGL: ", OpenGL.GL.glGetString(OpenGL.GL.GL_VERSION))

    def _CreateAndInitGLFW(self):
        # Inicializa GLFW
        glfw.init()

        # Criação de uma janela
        self.WINDOW = glfw.create_window(
            self.WIDTH, self.HEIGHT, self.TITLE_WINDOW, None, None)
        if not self.WINDOW:
            glfw.terminate()
            exit()

        glfw.set_window_size_callback(self.WINDOW, self._ResizeCallBack)
        glfw.make_context_current(self.WINDOW)

    def _ResizeCallBack(self, w: int, h: int):
        self.WIDTH = w
        self.HEIGHT = h
