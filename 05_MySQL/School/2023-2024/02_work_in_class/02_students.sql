create table students (
    id int primary key auto_increment,
    first_name varchar(20),
    last_name varchar(20),
    class varchar(3)
);

insert into students(first_name, last_name, class) values
("John", "Doe", "1.A"),
("Simon", "Smith", "1.A"),
("Frank", "Brown", "1.A"),
("Dan", "White", "1.B"),
("Martin", "Green", "1.B"),
("Zach", "Black", "1.B"),
("Henry", "King", "1.C"),
("Luke", "Stone", "1.C"),
("Ben", "Wood", "1.C");

select * from students;
SELECT id, first_name FROM students WHERE class = '1.A';
SELECT first_name, class FROM students WHERE id > 6;