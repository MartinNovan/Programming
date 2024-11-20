# Side Effects of Functions in Python

This project demonstrates how to eliminate side effects in Python functions. By avoiding side effects, functions become more predictable and easier to test, as they do not alter external states or variables unexpectedly.

## 4_1.py: Add Score

- **Old Code**: Used a global variable `total_score` to track the score.
- **New Code**: The function `add_score` now returns a new score without modifying a global variable.
- **Reason**: Eliminating the global variable makes the function more predictable and easier to test.

## 4_2.py: Adjust Brightness

- **Old Code**: Modified the `settings` dictionary directly.
- **New Code**: The function `adjust_brightness` returns a new settings dictionary with the updated brightness.
- **Reason**: Returning a new dictionary prevents unintended modifications to the original settings.

## 4_3.py: User Logout

- **Old Code**: Modified the `user_session` dictionary directly.
- **New Code**: The function `logout` returns a new session dictionary with updated login status.
- **Reason**: Returning a new dictionary ensures that the original session remains unchanged.

## 4_4.py: Update Inventory

- **Old Code**: Modified the `inventory` dictionary directly.
- **New Code**: The function `update_inventory` returns a new inventory dictionary with updated quantities.
- **Reason**: Returning a new dictionary prevents unintended changes to the original inventory.

By following these practices, the code becomes more modular and easier to maintain, reducing the risk of bugs and improving code quality.