import random

def generate_seeded_sequence(seed, n):
    # Set the seed
    random.seed(seed)
    
    # Generate a sequence of random numbers
    for _ in range(n):
        print(random.randint(1, 100))

# Testing the function
print("First sequence:")
generate_seeded_sequence(42, 5)  # First test call with seed 42
print("\nSecond sequence with the same seed:")
generate_seeded_sequence(42, 5)  # Second test call with the same seed

print("\nSequence with a different seed:")
generate_seeded_sequence(99, 5)  # Third test call with a different seed
