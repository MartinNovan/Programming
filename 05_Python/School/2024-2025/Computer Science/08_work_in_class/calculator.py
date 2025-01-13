def add(a, b):
    check_input(a, b)
    return a + b

def subtract(a, b):
    check_input(a, b)
    return a - b

def multiply(a, b):
    check_input(a, b)
    return a * b

def divide(a, b):
    check_input(a, b)
    if b == 0:
        raise ValueError("Cannot divide by zero!")
    return a / b

def check_input(a, b):
    if not isinstance(a, (int, float)) or not isinstance(b, (int, float)):
        raise ValueError("Inputs must be numbers!")
    return True