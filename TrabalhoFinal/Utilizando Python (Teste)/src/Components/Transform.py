import numpy as np

class Transform:
    def __init__(self):
        self.position = np.array([0.0, 0.0, 0.0, 1.0])
        self.rotation = np.array([0.0, 0.0, 0.0, 1.0])
        self.scale = np.array([1.0, 1.0, 1.0, 1.0])


    def Reset(self):
        self.position = np.array([0.0, 0.0, 0.0, 1.0])
        self.rotation = np.array([0.0, 0.0, 0.0, 1.0])
        self.scale = np.array([1.0, 1.0, 1.0, 1.0])

    def Translate(self, translation):
        #transladar
        #posicao += translation
        print("Translate Method")

    def Translate(self, x, y, z):
        print("Translate Method")

    def Rotate(self, rotation):
        #rotate += rotation
        print("Translate Method")

    def Rotate(self, x, y, z):
        #rotation
        print("Translate Method")