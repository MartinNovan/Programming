# JavaScript Calculator

This script is a simple calculator implemented in JavaScript. It defines a function `calculate` that performs basic arithmetic operations based on the provided operator.

## Functionality

The `calculate` function takes three parameters:
- `num1`: The first number in the calculation.
- `operator`: A string representing the arithmetic operation to perform. Supported operators are:
  - `+` for addition
  - `-` for subtraction
  - `/` for division
  - `*` for multiplication
- `num2`: The second number in the calculation.

## How It Works

1. The function uses a `switch` statement to determine which operation to perform based on the `operator` parameter.
2. For each case, it calculates the result using the corresponding arithmetic operation.
3. If the division operator `/` is used and `num2` is zero, it logs an error message to the console to prevent division by zero.
4. The result of the calculation is logged to the console.

## Example Usage

The script includes an example call to the `calculate` function:

```javascript
calculate(4, "*", 8);
```

This example multiplies 4 by 8 and logs the result, which is 32, to the console.

## Notes

- The script currently logs the result to the console. It can be modified to return the result if needed.
- Ensure that the `operator` parameter is one of the supported operators to avoid unexpected behavior.
