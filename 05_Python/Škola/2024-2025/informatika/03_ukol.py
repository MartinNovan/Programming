import random
#Profesional tip: pokud panáček zařve "svarta jump" automaticky propadne :)
def simulace_hry():
    PocetPanelu = 20 #počet panelů ve hře
    UspesnyPanely = 0 #počet kolikrát se správně trefí
    
    for i in range(PocetPanelu): #opakuje dokud neprojde všechny panely nebo spadne
        if random.random() < 0.5: #náhodnost 50%
            UspesnyPanely += 1
            i += 1
        else:
            break #spadl :(
    
    return UspesnyPanely #odešle kolik jich přeskočil pro zapsání do celkového počtu

PocetOpakovani = 100000 #nastavení kolikrát to chceme opakovat
CelkemUspesnychPanelu = 0

for j in range(PocetOpakovani): #opakujeme dokud neproběhnou všechny pokusy
    CelkemUspesnychPanelu += simulace_hry() #přičítáme kolik panelů úspěšně přeskočil
    j += 1

PrumerUspesnychPanelu = CelkemUspesnychPanelu / PocetOpakovani #průměr úspěšných panelů
print(f'Průměrný počet panelů, které hráč projde: {PrumerUspesnychPanelu}') #výpis