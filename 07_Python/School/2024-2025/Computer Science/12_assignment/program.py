def calc_price(total, discount_code):
    """
    Vypocita konecnou cenu objednavky v e-shopu po pripadnem pouziti slevoveho kodu.

    Postup:
      1. Pokud je celkova cena (total) mensi nez 100, vyhazuje ValueError, protoze neni mozne pouzit slevovy kod.
      2. Pokud neni zadan zadny slevovy kod (None), vraci puvodni cenu.
      3. Pokud byl zadan slevovy kod, overi jeho platnost (platne jsou pouze "DISCOUNT10" a "DISCOUNT20").
         Pokud kod neni platny, vyhazuje ValueError.
      4. Pokud je slevovy kod platny, nastavi procentualni slevu:
            - "DISCOUNT10" => 10%
            - "DISCOUNT20" => 20%
      5. Vypocita konecnou cenu: total * (1 - discount).

    Parametry:
      total (float): Celkova cena objednavky.
      discount_code (str | None): Slevovy kod zadan zakaznikem.

    Navratova hodnota:
      float: Konecna cena objednavky po odecitani slevy.

    Vyhazuje:
      ValueError: Pokud objednavka nesplnuje podminky nebo je slevovy kod neplatny.
    """
    if total < 100:
        raise ValueError("Objednavka musi mit minimalne 100 pro pouziti slevoveho kodu.")

    if not discount_code:
        return total

    if discount_code not in ("DISCOUNT10", "DISCOUNT20"):
        raise ValueError("Neplatny slevovy kod.")

    if discount_code == "DISCOUNT10":
        discount = 0.10
    else:  # discount_code == "DISCOUNT20"
        discount = 0.20

    return total * (1 - discount)