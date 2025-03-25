# Documentation for Tests of `text_stats.exe`

## Introduction

This documentation describes the tests conducted on the application `text_stats.exe`, which performs various text statistics, such as string length, number of digits, number of words, and number of alphanumeric characters. The tests were conducted using the `pytest` framework.

## Types of Tests

### 1. Testing Argument Length (`-l`)

Tests for the `-l` command that verify the length of the provided text.

- **Tests:**
  - `test_length_of_the_arg`: Verifies the length of various strings.

### 2. Testing Number of Digits (`-d`)

Tests for the `-d` command that verify the number of digits in the provided text.

- **Tests:**
  - `test_number_of_numbers`: Verifies the number of digits in various strings.

### 3. Testing Number of Words (`-w`)

Tests for the `-w` command that verify the number of words in the provided text.

- **Tests:**
  - `test_number_of_words`: Verifies the number of words in various strings.

### 4. Testing Number of Alphanumeric Characters (`-a`)

Tests for the `-a` command that verify the number of alphanumeric characters in the provided text.

- **Tests:**
  - `test_number_of_alphanumeric_chars`: Verifies the number of alphanumeric characters in various strings.

### 5. Testing Invalid Arguments

Tests to verify that the application correctly responds to invalid arguments.

- **Tests:**
  - `test_invalid_length_arg`: Verifies that invalid arguments for `-l` raise a `ValueError` exception.
  - `test_invalid_number_arg`: Verifies that invalid arguments for `-d` raise a `ValueError` exception.
  - `test_invalid_word_arg`: Verifies that invalid arguments for `-w` raise a `ValueError` exception.
  - `test_invalid_alphanumeric_arg`: Verifies that invalid arguments for `-a` raise a `ValueError` exception.

## Test Results

- **Total number of tests:** 8
- **Number of successful tests:** 4
- **Number of failed tests:** 4

### Successful Tests:
- `test_length_of_the_arg`
- `test_number_of_numbers`
- `test_number_of_words`
- `test_number_of_alphanumeric_chars`

### Failed Tests:
- `test_invalid_length_arg` (DID NOT RAISE <class 'ValueError'>)
- `test_invalid_number_arg` (DID NOT RAISE <class 'ValueError'>)
- `test_invalid_word_arg` (DID NOT RAISE <class 'ValueError'>)
- `test_invalid_alphanumeric_arg` (DID NOT RAISE <class 'ValueError'>)

All tests with invalid arguments failed, while the other tests were successful.
