import random  # Tohle potřebujeme pro náhodný výběr

# Tady máme všechny předměty a kolikrát se mají v rozvrhu objevit
PREDMETY = {
    'CJL': 3, 'OBN': 1, 'ANJ': 3, 'MAT': 4, 'TEV': 2,
    'ASW': 2, 'POS': 3, 'PRG': 3, 'MIT': 2, 'INF': 2,
    'VAP': 2, 'MSW': 2
}

DNY = ['Po', 'Út', 'St', 'Čt', 'Pá']  # Dny v týdnu
OBED = 'ㅤ'  # Tohle je speciální neviditelný znak pro oběd

def vytvor_prazdny_rozvrh():
    # Vytvoříme prázdný rozvrh, kde každý den má 10 prázdných hodin
    rozvrh = {den: [''] * 10 for den in DNY}
    rozvrh['St'] = [' '] * 10  # Středa je volná, tak ji vyplníme mezerami
    return rozvrh

def najdi_volnou_hodinu(rozvrh, den):
    # Tahle funkce najde první volnou hodinu v daném dni
    return next((i for i, hodina in enumerate(rozvrh[den]) if hodina == ''), None)

def pridej_obed(rozvrh):
    # Přidáme oběd náhodně mezi 4. a 8. hodinou pro každý den kromě středy
    for den in ['Po', 'Út', 'Čt', 'Pá']:
        obed_hodina = random.randint(3, 7)
        rozvrh[den][obed_hodina] = OBED

def pridej_telocvik(rozvrh):
    # Přidáme dvě hodiny tělocviku za sebou v náhodný den
    tev_den = random.choice(['Po', 'Út', 'Čt', 'Pá'])
    tev_hodina = najdi_volnou_hodinu(rozvrh, tev_den)
    if tev_hodina is not None and tev_hodina < 9:
        rozvrh[tev_den][tev_hodina] = 'TEV'
        rozvrh[tev_den][tev_hodina + 1] = 'TEV'

def pridej_predmety(rozvrh):
    # Přidáme všechny ostatní předměty do rozvrhu
    for predmet, pocet in PREDMETY.items():
        if predmet != 'TEV':  # Tělocvik už jsme přidali, tak ho přeskočíme
            for _ in range(pocet):
                while True:
                    den = random.choice(['Po', 'Út', 'Čt', 'Pá'])
                    hodina = najdi_volnou_hodinu(rozvrh, den)
                    if hodina is not None:
                        rozvrh[den][hodina] = predmet
                        break

def uspordej_predmety(rozvrh):
    # Uspořádáme předměty tak, aby nebyly zbytečné mezery
    for den in ['Po', 'Út', 'Čt', 'Pá']:
        predmety = [p for p in rozvrh[den] if p != '' and p != OBED]
        obed_index = rozvrh[den].index(OBED)
        
        # Uspořádáme předměty před obědem
        for i in range(obed_index):
            rozvrh[den][i] = predmety[i] if i < len(predmety) else ''
        
        # Uspořádáme předměty po obědě
        for i in range(obed_index + 1, 10):
            rozvrh[den][i] = predmety[i - 1] if i - 1 < len(predmety) else ''

def kontrola_poctu_hodin(rozvrh):
    # Zkontrolujeme, jestli má každý den aspoň 4 hodiny
    for den in ['Po', 'Út', 'Čt', 'Pá']:
        pocet_hodin = sum(1 for p in rozvrh[den] if p != '' and p != OBED)
        while pocet_hodin < 4:
            # Pokud ne, vezmeme hodinu z nejdelšího dne a přidáme ji sem
            nejdelsi_den = max(['Po', 'Út', 'Čt', 'Pá'], key=lambda d: sum(1 for p in rozvrh[d] if p != '' and p != OBED))
            if sum(1 for p in rozvrh[nejdelsi_den] if p != '' and p != OBED) > 4:
                for i, predmet in enumerate(rozvrh[nejdelsi_den]):
                    if predmet not in ['', 'TEV', OBED]:
                        hodina = najdi_volnou_hodinu(rozvrh, den)
                        if hodina is not None:
                            rozvrh[den][hodina] = predmet
                            rozvrh[nejdelsi_den][i] = ''
                            pocet_hodin += 1
                            break
            if pocet_hodin == 4:
                break

def generuj_rozvrh():
    # Tady dáme všechno dohromady a vytvoříme kompletní rozvrh
    rozvrh = vytvor_prazdny_rozvrh()
    pridej_obed(rozvrh)
    pridej_telocvik(rozvrh)
    pridej_predmety(rozvrh)
    uspordej_predmety(rozvrh)
    kontrola_poctu_hodin(rozvrh)
    return rozvrh

def vypis_rozvrh(rozvrh):
    # Tahle funkce nám hezky vypíše rozvrh do konzole
    print("+-----+-------------+-------------+-------------+-------------+-------------+-------------+-------------+-------------+-------------+-------------+")
    print("| Den | 1. hodina   | 2. hodina   | 3. hodina   | 4. hodina   | 5. hodina   | 6. hodina   | 7. hodina   | 8. hodina   | 9. hodina   | 10. hodina  |")
    print("|     | 08:00-08:45 | 08:55-09:40 | 10:00-10:45 | 10:55-11:40 | 11:50-12:35 | 12:45-13:30 | 13:40-14:25 | 14:30-15:15 | 15:20-16:05 | 16:10-16:55 |")
    print("+-----+-------------+-------------+-------------+-------------+-------------+-------------+-------------+-------------+-------------+-------------+")

    for den in DNY:
        print(f"| {den}  |", end="")
        for predmet in rozvrh[den]:
            if predmet == OBED:
                print("             |", end="")
            else:
                print(f" {predmet:11} |", end="")
        print("\n+-----+-------------+-------------+-------------+-------------+-------------+-------------+-------------+-------------+-------------+-------------+")

# Tady to všechno spustíme
rozvrh = generuj_rozvrh()
vypis_rozvrh(rozvrh)