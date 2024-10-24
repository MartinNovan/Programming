import random
# úkol na analýzu hry pomocí random number (úkolem má být že výsledek vyjde podobný předešlému)
def simulace_hry():
    skore = 0
    hody = 0

    while skore != 10:
        hod = random.randint(1, 6)
        hody += 1
        if skore < 10:
            skore += hod
        else:
            skore -= hod

    return hody

def prumer_hodu():
    celkem_hodu = 0

    for i in range(100000):
        celkem_hodu += simulace_hry()

    return celkem_hodu / 100000

print("Průměrný počet hodů na hru:", prumer_hodu())

#OUTPUT:
#PS C:\Users\Mnova\Documents\GitHub\Programovani> python -u "c:\Users\Mnova\Documents\GitHub\Programovani\05_Python\Škola\2024-2025\informatika\02_ukol.py"
#Průměrný počet hodů na hru: 7.59014
#PS C:\Users\Mnova\Documents\GitHub\Programovani> python -u "c:\Users\Mnova\Documents\GitHub\Programovani\05_Python\Škola\2024-2025\informatika\02_ukol.py"
#Průměrný počet hodů na hru: 7.58758
#PS C:\Users\Mnova\Documents\GitHub\Programovani> python -u "c:\Users\Mnova\Documents\GitHub\Programovani\05_Python\Škola\2024-2025\informatika\02_ukol.py"
#Průměrný počet hodů na hru: 7.60392
#PS C:\Users\Mnova\Documents\GitHub\Programovani> python -u "c:\Users\Mnova\Documents\GitHub\Programovani\05_Python\Škola\2024-2025\informatika\02_ukol.py"
#Průměrný počet hodů na hru: 7.57849
#PS C:\Users\Mnova\Documents\GitHub\Programovani> python -u "c:\Users\Mnova\Documents\GitHub\Programovani\05_Python\Škola\2024-2025\informatika\02_ukol.py"
#Průměrný počet hodů na hru: 7.56682
#PS C:\Users\Mnova\Documents\GitHub\Programovani> python -u "c:\Users\Mnova\Documents\GitHub\Programovani\05_Python\Škola\2024-2025\informatika\02_ukol.py"
#Průměrný počet hodů na hru: 7.55842