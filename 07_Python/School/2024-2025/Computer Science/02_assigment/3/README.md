# Magic Constants in Python

This project demonstrates the importance of replacing magic constants with named constants in Python code. Named constants improve code readability and maintainability by providing meaningful context to otherwise arbitrary values.

## 3_1.py: Long-term Service Award

- **Old Code**: Used the magic number `10` directly in the condition.
- **New Code**: Introduced `LONG_TERM_SERVICE_THRESHOLD` to represent the threshold for long-term service.
- **Reason**: The named constant clarifies the purpose of the number, making the code more understandable.

## 3_2.py: Discount Calculation

- **Old Code**: Used magic numbers `0.95` and `0.90` for discounts.
- **New Code**: Introduced `STANDARD_DISCOUNT` and `MEMBER_DISCOUNT` to represent the discount rates.
- **Reason**: Named constants provide clarity on the discount rates applied, improving code readability.

## 3_3.py: Pause Duration

- **Old Code**: Used the magic number `2.5` for the sleep duration.
- **New Code**: Introduced `PAUSE_DURATION` to represent the duration of the pause.
- **Reason**: The named constant makes it clear why the pause is needed and how long it lasts.

## 3_4.py: Connection Retries

- **Old Code**: Used the magic number `3` for the maximum number of retries.
- **New Code**: Introduced `MAX_RETRIES` to represent the maximum retry attempts.
- **Reason**: The named constant provides context for the retry logic, making the code easier to modify and understand.

By following these practices, the code becomes more intuitive and easier to maintain, reducing the likelihood of errors and improving collaboration.