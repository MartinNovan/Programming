# MySQL Students Table

This SQL script demonstrates basic operations on a MySQL database table designed to store information about students. The script includes table creation, data insertion, and data retrieval.

## SQL Script Overview

### Table Creation

- **`create table students`**: 
  - Creates a table named `students` with the following columns:
    - `id`: An integer that serves as the primary key and auto-increments with each new entry.
    - `first_name`: A `varchar` field with a maximum length of 20 characters, representing the student's first name.
    - `last_name`: A `varchar` field with a maximum length of 20 characters, representing the student's last name.
    - `class`: A `varchar` field with a maximum length of 3 characters, representing the class the student belongs to.

### Data Insertion

- **`insert into students(first_name, last_name, class) values (...)`**: 
  - Inserts multiple records into the `students` table with various first names, last names, and class assignments.

### Data Retrieval

- **`select * from students`**: 
  - Retrieves all records from the `students` table, displaying all columns for each entry.

- **`SELECT id, first_name FROM students WHERE class = '1.A'`**: 
  - Retrieves the `id` and `first_name` of students who are in class '1.A'.

- **`SELECT first_name, class FROM students WHERE id > 6`**: 
  - Retrieves the `first_name` and `class` of students whose `id` is greater than 6.

## Usage

- This script is intended for use in a MySQL database environment.
- It demonstrates basic SQL operations such as creating tables, inserting data, and querying data with conditions.

## Notes

- Ensure that the MySQL server is running and accessible before executing the script.
- The script assumes that the database context is already set to the appropriate database where the `students` table should be created.
- The names used in the script are fictional and used for demonstration purposes.
