import random

def roll_multiple_dice(n, k):
    # seznam výsledků pro "n" počet kostek s "k" stranami
    results = [random.randint(1, k) for _ in range(n)]
    return results
# Otestování funkce
print(roll_multiple_dice(3, 6))  # Simulace hodu 3 kostkami, každá má 6 hran
