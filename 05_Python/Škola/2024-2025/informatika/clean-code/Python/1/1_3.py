class P:
    def __init__(self, n, a):
        self.n = n
        self.a = a

    def d(self):
        print(f"{self.n} is {self.a} years old.")

p = P("Alice", 30)
p.d()
