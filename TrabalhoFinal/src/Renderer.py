from Window import Window


class Renderer:
    def __init__(self, WINDOW: Window):

    def initObject(self):
        Vao_triangulo = glGenVertexArrays(1)
        glBindVertexArray(Vao_triangulo)

        # VBO dos vértices
        points = [
            0.0, 0.5, 0.0,  # cima
            0.5, -0.5, 0.0,  # direita
            -0.5, -0.5, 0.0  # /esquerda
        ]

        points = np.array(points, dtype=np.float32)

        pvbo = glGenBuffers(1)
        glBindBuffer(GL_ARRAY_BUFFER, pvbo)
        glBufferData(GL_ARRAY_BUFFER, points, GL_STATIC_DRAW)
        glEnableVertexAttribArray(0)
        glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 0, None)

        # VBO das cores
        cores = [
            1.0, 0.0, 0.0,  # vermelho
            0.0, 1.0, 0.0,  # verde
            0.0, 0.0, 1.0  # azul
        ]
        cores = np.array(cores, dtype=np.float32)
        cvbo = glGenBuffers(1)
        glBindBuffer(GL_ARRAY_BUFFER, cvbo)
        glBufferData(GL_ARRAY_BUFFER, cores, GL_STATIC_DRAW)
        glEnableVertexAttribArray(1)
        glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, 0, None)
