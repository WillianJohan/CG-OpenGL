from Window import *
import glfw

window = Window(100,100,"teste")

while not glfw.window_should_close(window.Canvas):
        
    if (glfw.PRESS == glfw.get_key(window.Canvas, glfw.KEY_ESCAPE)):
        glfw.set_window_should_close(window.Canvas, True)
    
glfw.terminate()