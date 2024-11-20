# Old code
# def s(r):
#     a = 3.14 * r * r
#     c = 2 * 3.14 * r
#     print("Area:", a)
#     print("Circumference:", c)
# s(5)

# New code with meaningful names
def calculate_circle_properties(radius):
    area = 3.14 * radius * radius
    circumference = 2 * 3.14 * radius
    print("Area:", area)
    print("Circumference:", circumference)

calculate_circle_properties(5)