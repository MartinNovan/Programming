# Documentation for Price Calculation Tests

## Introduction

This documentation describes white box tests performed on the `calc/program.py` module, which implements a function for calculating prices. The tests were implemented using the `pytest` framework, with coverage analysis provided by the `pytest-cov` plugin.

## Types of Tests

### 1. Price Calculation Testing (function `calc_price`)

These tests verify the correct calculation of prices under various conditions.

- **Tests:**
  - `test_calc_price_basic`: Tests price calculation with standard input values
  - `test_calc_price_discount`: Tests price calculation with a discount applied
  - `test_calc_price_large_numbers`: Tests price calculation with large numerical inputs
  - `test_calc_price_zero`: Tests behavior when the price is zero
  - `test_calc_price_negative`: Ensures correct handling of negative price inputs

## Code Coverage

The test coverage report ensures that all functional parts of `calc/program.py` are tested:
- 100% statement coverage
- 100% branch coverage
- Full validation of different pricing scenarios

## Test Results

- **Total number of tests:** 5
- **Successful tests:** 5
- **Failed tests:** 0

### Interesting Findings:
- The implementation correctly handles standard price calculations
- Discounts are applied as expected
- The function correctly manages edge cases such as zero and large values
- Negative price inputs are handled appropriately

## White Box Testing Techniques Used

1. **Statement Coverage** - ensuring all lines in `calc_price` are executed during tests
2. **Branch Coverage** - validating different pricing conditions, including discounts and edge cases
3. **Boundary Testing** - testing with zero, large numbers, and negative values to check robustness

## Conclusion

The test results confirm that the `calc_price` function is reliable under different conditions. Full test coverage ensures that all functional aspects are verified, and no critical issues were identified. The implementation is robust and properly handles both typical and edge cases.

## File Links
- [calc/program.py](calc/program.py)
- [tests/test_program.py](tests/test_program.py)
- [calc/__init__.py](calc/__init__.py)
- [tests/__init__.py](tests/__init__.py)

