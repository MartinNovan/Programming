# Music Player Application

## Popis aplikace
Tato aplikace je pokročilý hudební přehrávač s podporou lokálních souborů a integrací se Spotify. Aplikace umožňuje správu hudebních alb, playlistů, profilů a vlastních cest k hudebním souborům. Je napsaná v C# pomocí WPF frameworku.

## Hlavní funkce
1. **Přehrávání lokálních hudebních souborů**
   - Podpora formátu MP3
   - Zobrazení metadat (název skladby, interpret, album, délka)
   - Zobrazení obalů alb
   - Možnosti přehrávání (play/pause, skip forward/backward)
   - Režimy opakování (vypnuto, opakovat jednu skladbu, opakovat vše)
   - Náhodné přehrávání

2. **Správa hudební knihovny**
   - Automatické načítání hudby z:
     - Složky "Moje hudba"
     - Složky "Společná hudba"
     - Vlastních cest
   - Vytváření a správa alb/playlistů
   - Přidávání/odebírání skladeb do alb
   - Vyhledávání v hudební knihovně

3. **Správa profilů**
   - Vytváření a mazání profilů
   - Nastavení výchozího profilu při spuštění
   - Ukládání nastavení pro každý profil zvlášť

4. **Integrace se Spotify**
   - Webový prohlížeč pro přístup k Spotify
   - Možnost přehrávání hudby přímo z webového rozhraní

5. **Nastavení**
   - Správa vlastních cest k hudebním souborům
   - Správa profilů
   - Nastavení výchozího profilu

## Struktura projektu
```
16_assignment/
├── App.xaml
├── App.xaml.cs
├── AssemblyInfo.cs
├── FileHelpers.cs
├── GlobalSettings.cs
├── MainWindow.xaml
├── MainWindow.xaml.cs
├── Models/
├── Views/
│   ├── AddPage.xaml
│   ├── AddPage.xaml.cs
│   ├── LocalPlayerMainPage.xaml
│   ├── LocalPlayerMainPage.xaml.cs
│   ├── SettingPage.xaml
│   ├── SettingPage.xaml.cs
│   ├── SpotifyPage.xaml
│   └── SpotifyPage.xaml.cs
└── Resources/
```

## Použité technologie
- .NET 9
- WPF (Windows Presentation Foundation)
- Fluent Design System (Windows 11 motiv)
- TagLib# pro práci s metadaty MP3 souborů
- WebView2 pro integraci Spotify
- Newtonsoft.Json pro práci s JSON soubory

## Instalace a spuštění
1. Klonujte repozitář
2. Otevřete řešení v Visual Studiu 2022 nebo novějším
3. Sestavte řešení
4. Spusťte aplikaci

## Použití
1. **Hlavní okno**
   - Tři záložky: Lokální přehrávač, Spotify, Nastavení
   - Možnost přepínání mezi záložkami

2. **Lokální přehrávač**
   - Levý panel: Seznam alb/playlistů
   - Hlavní panel: Seznam skladeb
   - Pravý panel: Informace o aktuální skladbě
   - Spodní panel: Ovládací prvky přehrávače

3. **Spotify**
   - Integrovaný webový prohlížeč pro přístup k Spotify

4. **Nastavení**
   - Správa profilů
   - Správa vlastních cest
   - Nastavení výchozího profilu

## Ukládání dat
Aplikace ukládá data do:
```
%AppData%\MartinNovan\MusicPlayer\
```
Struktura:
```
DataPath/
├── Default/
│   └── profile.json
├── Profile1/
│   └── profile.json
├── Profile2/
│   └── profile.json
└── settings.json
```

## Závislosti
- Microsoft.Web.WebView2
- Newtonsoft.Json
- TagLibSharp

## Omezení
- Podporuje pouze MP3 soubory
- Spotify integrace je pouze webový prohlížeč, ne plná integrace API

## Budoucí vylepšení
- Podpora více audio formátů
- Pokročilá integrace se Spotify pomocí API
- Export/import playlistů
- Cloudová synchronizace