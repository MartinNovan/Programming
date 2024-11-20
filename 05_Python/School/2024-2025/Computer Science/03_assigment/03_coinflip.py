import random

def flip_coin():
    # Randomly generate the result of a coin flip
    if random.random() < 0.5:
        return "Heads"
    else:
        return "Tails"

# Testing the function
print(flip_coin())
