CREATE TABLE Tridy (
    nazev_tridy VARCHAR(3) PRIMARY KEY,
    prijmeni_tridniho VARCHAR(20)
);

CREATE TABLE Zaci (
    id INT PRIMARY KEY AUTO_INCREMENT,
    jmeno VARCHAR(20),
    prijimeni VARCHAR(20),
    trida VARCHAR(3),
    FOREIGN KEY (trida) REFERENCES Tridy(nazev_tridy) ON DELETE CASCADE
);

INSERT INTO Tridy (nazev_tridy, prijmeni_tridniho) VALUES 
('1.A', 'Novák'),
('1.B', 'Kovář'),
('1.C', 'Svoboda');

INSERT INTO Zaci (jmeno, prijimeni, trida) VALUES
('Petr', 'Januške', '1.A'),
('Šimon', 'Šupola', '1.A'),
('František', 'Poupa', '1.A'),
('Dan', 'Lalák', '1.B'),
('Martin', 'Novan', '1.B'),
('Zdeněk', 'Chudoba', '1.B'),
('Jindřich', 'Kreisinger', '1.C'),
('Lukáš', 'Fafala', '1.C'),
('Benjamin', 'Masopust', '1.C');

SELECT Zaci.jmeno, Zaci.prijimeni, Tridy.nazev_tridy, Tridy.prijmeni_tridniho FROM Zaci JOIN Tridy ON Zaci.trida = Tridy.nazev_tridy;

DELETE FROM Tridy WHERE nazev_tridy = '1.C';

SELECT * FROM Zaci;
