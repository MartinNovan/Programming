import random

def flip_biased_coin(p):
    if random.random() < p:
        return "Hlava"  # Vrací "Hlava", pokud je randommenší než p
    else:
        return "Orel"  # V opačném případě vrací "Orel"

# Otestování funkce s pravděpodobností 70% na padnutí hlavy
print(flip_biased_coin(0.7))  # Výstup bude "Hlava" nebo "Orel" s 70% šancí na "Hlava"
