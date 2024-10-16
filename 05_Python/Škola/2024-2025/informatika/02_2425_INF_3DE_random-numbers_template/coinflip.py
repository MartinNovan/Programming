import random

def flip_coin():
    # Náhodné vygenerování výsledku hodu mincí
    if random.random() < 0.5:
        return "Hlava"
    else:
        return "Orel"

# Otestování funkce
print(flip_coin())
