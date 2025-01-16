# Dokumentace k testům pro `text_stats.exe`

## Úvod

Tato dokumentace popisuje testy provedené na aplikaci `text_stats.exe`, která provádí různé statistiky textu, jako je délka řetězce, počet čísel, počet slov a počet alfanumerických znaků. Testy byly provedeny pomocí frameworku `pytest`.

## Typy testů

### 1. Testování délky argumentu (`-l`)

Testy pro příkaz `-l`, které ověřují délku zadaného textu.

- **Testy:**
  - `test_length_of_the_arg`: Ověřuje délku různých řetězců.

### 2. Testování počtu čísel (`-d`)

Testy pro příkaz `-d`, které ověřují počet čísel v zadaném textu.

- **Testy:**
  - `test_number_of_numbers`: Ověřuje počet čísel v různých řetězcích.

### 3. Testování počtu slov (`-w`)

Testy pro příkaz `-w`, které ověřují počet slov v zadaném textu.

- **Testy:**
  - `test_number_of_words`: Ověřuje počet slov v různých řetězcích.

### 4. Testování počtu alfanumerických znaků (`-a`)

Testy pro příkaz `-a`, které ověřují počet alfanumerických znaků v zadaném textu.

- **Testy:**
  - `test_number_of_alphanumeric_chars`: Ověřuje počet alfanumerických znaků v různých řetězcích.

### 5. Testování neplatných argumentů

Testy pro ověření, že aplikace správně reaguje na neplatné argumenty.

- **Testy:**
  - `test_invalid_length_arg`: Ověřuje, že neplatné argumenty pro `-l` vyvolávají výjimku `ValueError`.
  - `test_invalid_number_arg`: Ověřuje, že neplatné argumenty pro `-d` vyvolávají výjimku `ValueError`.
  - `test_invalid_word_arg`: Ověřuje, že neplatné argumenty pro `-w` vyvolávají výjimku `ValueError`.
  - `test_invalid_alphanumeric_arg`: Ověřuje, že neplatné argumenty pro `-a` vyvolávají výjimku `ValueError`.

## Výsledky testů

- **Celkový počet testů:** 8
- **Počet úspěšných testů:** 4
- **Počet neúspěšných testů:** 4

### Úspěšné testy:
- `test_length_of_the_arg`
- `test_number_of_numbers`
- `test_number_of_words`
- `test_number_of_alphanumeric_chars`

### Neúspěšné testy:
- `test_invalid_length_arg` (NEVYVOLAL <class 'ValueError'>)
- `test_invalid_number_arg` (NEVYVOLAL <class 'ValueError'>)
- `test_invalid_word_arg` (NEVYVOLAL <class 'ValueError'>)
- `test_invalid_alphanumeric_arg` (NEVYVOLAL <class 'ValueError'>)

Všechny testy s neplatnými argumenty selhaly, zatímco ostatní testy byly úspěšné.
