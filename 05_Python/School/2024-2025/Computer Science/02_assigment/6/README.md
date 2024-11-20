# DRY (Don't Repeat Yourself) in Python

This project demonstrates how to eliminate code repetition in Python by applying the DRY principle. By reducing redundancy, code becomes more maintainable and easier to update.

## 6_1.py: Print User Information

- **Old Code**: Repeatedly printed user information.
- **New Code**: Introduced `print_user_info` function to encapsulate the logic.
- **Reason**: Reduces repetition and centralizes the logic for printing user information.

## 6_2.py: Process Grades

- **Old Code**: Repeated logic for processing grades.
- **New Code**: Introduced `process_grade` function to handle grade processing.
- **Reason**: Consolidates common logic and reduces redundancy.

## 6_3.py: Send and Log Email

- **Old Code**: Repeated logic for sending and logging emails.
- **New Code**: Introduced `send_and_log_email` function to encapsulate the process.
- **Reason**: Centralizes email handling logic, making it easier to manage.

## 6_4.py: Calculate Weighted Sum

- **Old Code**: Repeatedly calculated weighted sum for each pair of values and weights.
- **New Code**: Used a generator expression with `zip` to calculate the weighted sum.
- **Reason**: Simplifies the calculation and reduces code duplication.

By following these practices, the code becomes more efficient and easier to maintain, reducing the risk of errors and improving code quality.