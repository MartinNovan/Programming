import random

def generate_sequence(n):
    return [random.randint(1, 100) for _ in range(n)]  # Generates a sequence of "n" random numbers from 1 to 100

# Testing the function
print(generate_sequence(10))  # Generates 10 random numbers
