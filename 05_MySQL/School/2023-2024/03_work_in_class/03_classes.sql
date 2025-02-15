CREATE TABLE Classes (
    class_name VARCHAR(3) PRIMARY KEY,
    teacher_last_name VARCHAR(20)
);

CREATE TABLE Students (
    id INT PRIMARY KEY AUTO_INCREMENT,
    first_name VARCHAR(20),
    last_name VARCHAR(20),
    class VARCHAR(3),
    FOREIGN KEY (class) REFERENCES Classes(class_name) ON DELETE CASCADE
);

INSERT INTO Classes (class_name, teacher_last_name) VALUES 
('1.A', 'Smith'),
('1.B', 'Johnson'),
('1.C', 'Williams');

INSERT INTO Students (first_name, last_name, class) VALUES
('John', 'Doe', '1.A'),
('Alice', 'Brown', '1.A'),
('Michael', 'Davis', '1.A'),
('Emily', 'Clark', '1.B'),
('David', 'Miller', '1.B'),
('Sophia', 'Wilson', '1.B'),
('James', 'Taylor', '1.C'),
('Olivia', 'Anderson', '1.C'),
('Liam', 'Thomas', '1.C');

SELECT Students.first_name, Students.last_name, Classes.class_name, Classes.teacher_last_name 
FROM Students 
JOIN Classes ON Students.class = Classes.class_name;

DELETE FROM Classes WHERE class_name = '1.C';

SELECT * FROM Students;
