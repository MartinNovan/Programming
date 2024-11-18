import random

def generate_sequence(n):
    return [random.randint(1, 100) for _ in range(n)] # Generuje sekvenci "n" náhodných čísel od 1 do 100
# Otestování funkce
print(generate_sequence(10))  # Vygeneruje 10 náhodných čísel
