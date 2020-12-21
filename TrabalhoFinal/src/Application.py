class Mimi:
    def __init__(self, n : int):
        self.n = n






class teste01:
    def __init__(self, obj : Mimi):
        self.obj = obj

    def alterarValor(self, n):
        print("[Teste01] valor original: ", self.obj.n, " Valor Alterado para: ", n)
        self.obj.n = n






class teste02:
    def __init__(self, obj : Mimi):
        self.obj = obj

    def alterarValor(self, n):
        print("[Teste02] valor original: ", self.obj.n, " Valor Alterado para: ", n)
        self.obj.n = n








mimi = Mimi(10)
print("mimi instanciado: ", mimi.n)

instanciaTeste01 = teste01(mimi)
instanciaTeste02 = teste02(mimi)

instanciaTeste01.alterarValor(1)
print("Valor do objeto apos o teste: ", mimi.n)
instanciaTeste02.alterarValor(4)
print("Valor do objeto apos o teste: ", mimi.n)

instanciaTeste01.alterarValor(10)
instanciaTeste02.alterarValor(71)
instanciaTeste01.alterarValor(12)


print("Valor do objeto apos o teste: ", mimi.n)