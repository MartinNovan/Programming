# MySQL Classes and Students Tables

This SQL script demonstrates the creation and management of two related tables in a MySQL database: `Classes` and `Students`. The script includes table creation, data insertion, data retrieval, and deletion operations.

## SQL Script Overview

### Table Creation

- **`CREATE TABLE Classes`**: 
  - Creates a table named `Classes` with the following columns:
    - `class_name`: A `VARCHAR` field serving as the primary key, representing the class name.
    - `teacher_last_name`: A `VARCHAR` field representing the last name of the class teacher.

- **`CREATE TABLE Students`**: 
  - Creates a table named `Students` with the following columns:
    - `id`: An integer that serves as the primary key and auto-increments with each new entry.
    - `first_name`: A `VARCHAR` field representing the student's first name.
    - `last_name`: A `VARCHAR` field representing the student's last name.
    - `class`: A `VARCHAR` field representing the class the student belongs to, with a foreign key constraint referencing `Classes(class_name)`.

### Data Insertion

- **`INSERT INTO Classes`**: 
  - Inserts records into the `Classes` table with class names and teacher last names.

- **`INSERT INTO Students`**: 
  - Inserts records into the `Students` table with student names and their respective classes.

### Data Retrieval

- **`SELECT` with JOIN**: 
  - Retrieves student names along with their class names and teacher last names by joining the `Students` and `Classes` tables.

### Data Deletion

- **`DELETE FROM Classes`**: 
  - Deletes a class from the `Classes` table, which also cascades to delete students in that class due to the foreign key constraint.

## Usage

- This script is intended for use in a MySQL database environment.
- It demonstrates SQL operations such as creating tables, inserting data, joining tables, and deleting records with cascading effects.

## Notes

- Ensure that the MySQL server is running and accessible before executing the script.
- The script assumes that the database context is already set to the appropriate database where the `Classes` and `Students` tables should be created.
- The names used in the script are fictional and used for demonstration purposes.
