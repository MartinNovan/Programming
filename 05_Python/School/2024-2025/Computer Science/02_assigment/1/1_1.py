# Old code
# def c(a, b):
#     d = (a ** 2 + b ** 2) ** 0.5
#     print("The result is:", d)
#     return d

# x = 3
# y = 4
# r = c(x, y)
# print("Computed value:", r)

# New code with meaningful names
def calculate_hypotenuse(side_a, side_b):
    hypotenuse = (side_a ** 2 + side_b ** 2) ** 0.5
    print("The result is:", hypotenuse)
    return hypotenuse

side1 = 3
side2 = 4
result = calculate_hypotenuse(side1, side2)
print("Computed value:", result)