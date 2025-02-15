import random

def roll_die(k):
    # Returns a random number between 1 and k inclusive
    return random.randint(1, k)

# Testing the function
print(roll_die(6))  # Simulates rolling a 6-sided die
