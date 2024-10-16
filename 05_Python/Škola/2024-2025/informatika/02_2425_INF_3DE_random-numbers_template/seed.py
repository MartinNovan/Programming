import random

def generate_seeded_sequence(seed, n):
    # Nastavíme seed
    random.seed(seed)
    
    # Vygenerujeme sekvenci náhodných čísel
    for _ in range(n):
        print(random.randint(1, 100))

# Otestování funkce
print("První sekvence:")
generate_seeded_sequence(42, 5)  # První testovací volání s seed 42
print("\nDruhá sekvence se stejným seedem:")
generate_seeded_sequence(42, 5)  # Druhé testovací volání s tím samým seedem

print("\nSekvence s jiným seedem:")
generate_seeded_sequence(99, 5)  # Třetí testovací volání s jiným seedem
