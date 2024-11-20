import random

# Task to analyze a game using random numbers (the goal is for the result to be similar to the previous one)
def simulate_game():
    score = 0
    rolls = 0

    while score != 10:
        roll = random.randint(1, 6)
        rolls += 1
        if score < 10:
            score += roll
        else:
            score -= roll

    return rolls

def average_rolls():
    total_rolls = 0

    for i in range(100000):
        total_rolls += simulate_game()

    return total_rolls / 100000

print("Average number of rolls per game:", average_rolls())

# OUTPUT:
# Average number of rolls per game: 7.59014
# Average number of rolls per game: 7.58758
# Average number of rolls per game: 7.60392
# Average number of rolls per game: 7.57849
# Average number of rolls per game: 7.56682
# Average number of rolls per game: 7.55842