create table zaci(
    id int primary key auto_increment,
    jmeno varchar(20),
    prijimeni varchar(20),
    trida varchar(3)
);

insert into zaci(jmeno, prijimeni, trida) values
("Petr","Januške", "1.A"),
("Šimon","Šupola", "1.A"),
("František","Poupa", "1.A"),
("Dan","Lalák", "1.B"),
("Martin","Novan", "1.B"),
("Zdeněk","Chudoba", "1.B"),
("Jindřich","Kreisinger", "1.C"),
("Lukáš","Fafala", "1.C"),
("Benjamin","Masopust", "1.C");

select * from zaci;
SELECT id, jmeno FROM zaci WHERE trida = '1.A';
SELECT jmeno, trida FROM zaci WHERE id > 6;