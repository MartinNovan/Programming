import random

def flip_biased_coin(p):
    if random.random() < p:
        return "Heads"  # Returns "Heads" if random is less than p
    else:
        return "Tails"  # Otherwise returns "Tails"

# Testing the function with a 70% chance of landing heads
print(flip_biased_coin(0.7))  # Output will be "Heads" or "Tails" with a 70% chance of "Heads"
