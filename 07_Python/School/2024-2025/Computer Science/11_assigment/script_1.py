def add_numbers(a, b):
    result = a
    for _ in range(abs(b)):
        if b > 0:
            result += 1
        else:
            result -= 1
    return result

def subtract_numbers(a, b):
    result = a
    for _ in range(abs(b)):
        if b > 0:
            result -= 1
        else:
            result += 1
    return result