# Old code
# class P:
#     def __init__(self, n, a):
#         self.n = n
#         self.a = a
#     def d(self):
#         print(f"{self.n} is {self.a} years old.")
# p = P("Alice", 30)
# p.d()

# New code with meaningful names
class Person:
    def __init__(self, name, age):
        self.name = name
        self.age = age

    def display(self):
        print(f"{self.name} is {self.age} years old.")

person = Person("Alice", 30)
person.display()