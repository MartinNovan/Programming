create table auta(
    id int primary key auto_increment,
    model varchar(20),
    vyrobce varchar(20)
);

alter table auta add neco int;
alter table auta drop column neco;

insert into auta(model, vyrobce) values("Fabia", "Škoda"),("Scala", "Škoda");

select * from auta;