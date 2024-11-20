# Old code
# arr = [5, 10, 15, 20, 25]
# def p(a):
#     for i in range(len(a)):
#         print("Value at index", i, ":", a[i])
# p(arr)

# New code with meaningful names
numbers = [5, 10, 15, 20, 25]

def print_array(array):
    for index in range(len(array)):
        print("Value at index", index, ":", array[index])

print_array(numbers)