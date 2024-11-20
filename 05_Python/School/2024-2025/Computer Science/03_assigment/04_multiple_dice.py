import random

def roll_multiple_dice(n, k):
    # List of results for "n" dice with "k" sides
    results = [random.randint(1, k) for _ in range(n)]
    return results

# Testing the function
print(roll_multiple_dice(3, 6))  # Simulates rolling 3 dice, each with 6 sides
