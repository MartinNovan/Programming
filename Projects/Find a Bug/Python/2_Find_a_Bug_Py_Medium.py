# Modify the existing code to achieve the result
def find_maximum(numbers):
    max_num = 0
    for num in numbers:
        if num > max_num:
            max_num = num
    return max_num

print(find_maximum([-1, -2, -3])) # Expected result: -1
