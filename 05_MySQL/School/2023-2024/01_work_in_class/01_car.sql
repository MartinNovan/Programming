create table cars (
    id int primary key auto_increment,
    model varchar(20),
    manufacturer varchar(20)
);

alter table cars add something int;
alter table cars drop column something;

insert into cars(model, manufacturer) values("Fabia", "Škoda"),("Scala", "Škoda");

select * from cars;