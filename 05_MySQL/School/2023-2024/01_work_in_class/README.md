# MySQL Car Table

This SQL script demonstrates basic operations on a MySQL database table designed to store information about cars. The script includes table creation, modification, data insertion, and data retrieval.

## SQL Script Overview

### Table Creation

- **`create table cars`**: 
  - Creates a table named `cars` with the following columns:
    - `id`: An integer that serves as the primary key and auto-increments with each new entry.
    - `model`: A `varchar` field with a maximum length of 20 characters, representing the car model.
    - `manufacturer`: A `varchar` field with a maximum length of 20 characters, representing the car manufacturer.

### Table Modification

- **`alter table cars add something int`**: 
  - Adds a new column named `something` of type integer to the `cars` table.

- **`alter table cars drop column something`**: 
  - Removes the `something` column from the `cars` table.

### Data Insertion

- **`insert into cars(model, manufacturer) values("Fabia", "Škoda"),("Scala", "Škoda")`**: 
  - Inserts two records into the `cars` table with models "Fabia" and "Scala", both manufactured by "Škoda".

### Data Retrieval

- **`select * from cars`**: 
  - Retrieves all records from the `cars` table, displaying all columns for each entry.

## Usage

- This script is intended for use in a MySQL database environment.
- It demonstrates basic SQL operations such as creating tables, modifying table structure, inserting data, and querying data.

## Notes

- Ensure that the MySQL server is running and accessible before executing the script.
- The script assumes that the database context is already set to the appropriate database where the `cars` table should be created.
