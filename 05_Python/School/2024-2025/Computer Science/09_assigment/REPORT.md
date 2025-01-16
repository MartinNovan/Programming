# Test Report

- **Total number of tests:** 8
- **Number of successful tests:** 4
- **Number of failed tests:** 4

## Successful tests:
- `test_length_of_the_arg`
- `test_number_of_numbers`
- `test_number_of_words`
- `test_number_of_alphanumeric_chars`

## Failed tests:
- `test_invalid_length_arg` (DID NOT RAISE <class 'ValueError'>)
- `test_invalid_number_arg` (DID NOT RAISE <class 'ValueError'>)
- `test_invalid_word_arg` (DID NOT RAISE <class 'ValueError'>)
- `test_invalid_alphanumeric_arg` (DID NOT RAISE <class 'ValueError'>)

All tests with invalid arguments failed, while the other tests passed successfully.