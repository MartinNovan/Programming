# Documentation for Basic Arithmetic Operations Tests

## Introduction

This documentation describes white box tests performed on the `script_1.py` application, which implements basic arithmetic operations (addition and subtraction) using an iterative approach. The tests were implemented using the `pytest` framework.

## Types of Tests

### 1. Addition Testing (function `add_numbers`)

Tests verifying correct addition of numbers using iterative increment/decrement.

- **Tests:**
  - `test_add_numbers_int`: Tests basic integer addition
  - `test_add_numbers_int_negative`: Tests addition with negative integers
  - `test_add_numbers_zero`: Tests addition with zero
  - `test_add_numbers_large`: Tests addition with large numbers
  - `test_add_numbers_float`: Tests addition with floating-point numbers (currently failing)

### 2. Subtraction Testing (function `subtract_numbers`)

Tests verifying correct subtraction of numbers using iterative increment/decrement.

- **Tests:**
  - `test_subtract_numbers_int`: Tests basic integer subtraction
  - `test_subtract_numbers_int_negative`: Tests subtraction with negative integers
  - `test_subtract_numbers_zero`: Tests subtraction with zero
  - `test_subtract_numbers_large`: Tests subtraction with large numbers
  - `test_subtract_numbers_float`: Tests subtraction with floating-point numbers (currently failing)

## Code Coverage

Tests cover the main functional parts of the application:
- Basic arithmetic operations with positive integers
- Operations with negative numbers
- Operations with zero
- Operations with large numbers
- Operations with floating-point numbers (revealing implementation limitations)

## Test Results

- **Total number of tests:** 10
- **Successful tests:** 8
- **Failed tests:** 2 (floating-point operations)

### Interesting Findings:
- The implementation works correctly for integer operations
- Current implementation doesn't support floating-point numbers properly
- The iterative approach handles large numbers successfully
- Zero cases are handled correctly
- Negative numbers are processed correctly

## White Box Testing Techniques Used

1. **Statement Coverage** - tests cover all lines of code in both functions
2. **Branch Coverage** - testing different condition branches (positive/negative numbers)
3. **Path Coverage** - testing different code paths through the loops
4. **Boundary Testing** - testing with zero, large numbers, and negative values

## Known Issues

1. Floating-point operations are not supported in the current implementation
2. The iterative approach, while functional, might not be the most efficient for large numbers

## Conclusion

White box tests revealed that while the implementation works correctly for integer operations, it has limitations with floating-point numbers. The code successfully handles edge cases like zero and negative numbers, but would benefit from adding floating-point support.
