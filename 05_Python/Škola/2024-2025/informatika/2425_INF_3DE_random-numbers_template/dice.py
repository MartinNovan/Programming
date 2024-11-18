import random

def roll_die(k):
    # Vrátí random číslo mezi 1 a k + včetně
    return random.randint(1, k)
# Otestování funkce
print(roll_die(6))  # Simulace hodu 6-hranou kostkou
