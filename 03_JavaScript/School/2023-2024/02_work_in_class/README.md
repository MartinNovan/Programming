# JavaScript Array Tasks

This script demonstrates various operations on arrays using loops in JavaScript. It initializes several arrays and populates them with numbers based on different conditions.

## Functionality

The script defines five arrays: `task1`, `task2`, `task3`, `task4`, and `task5`. Each array is filled with numbers according to specific rules:

1. **Task 1**: 
   - Fills `task1` with numbers from 0 to 15.
   - Uses a `for` loop to iterate from 0 to 15 and assigns each number to the array.

2. **Task 2**: 
   - Fills `task2` with numbers from 12 to 24.
   - Uses a `for` loop to iterate from 12 to 24 and assigns each number to the array.

3. **Task 3**: 
   - Fills `task3` with odd numbers from 7 to 31.
   - Uses a `for` loop to iterate from 7 to 31, checking if each number is odd, and assigns it to the array.

4. **Task 4**: 
   - Fills `task4` with even numbers from 10 down to -20.
   - Uses a `for` loop to iterate from 10 to -20, checking if each number is even, and assigns it to the array.

5. **Task 5**: 
   - Initializes `task5` as a 2D array with three sub-arrays.
   - The first sub-array is filled with multiples of 3 up to 45.
   - The second sub-array is filled with multiples of 5 up to 45.
   - The third sub-array is filled with numbers that are multiples of both 3 and 5 up to 45.
   - Uses a `for` loop to iterate from 1 to 45, checking the divisibility conditions, and assigns numbers to the respective sub-arrays.

## Example Output

The script logs the contents of each array to the console:

- `task1`: [0, 1, 2, ..., 15]
- `task2`: [12, 13, 14, ..., 24]
- `task3`: [7, 9, 11, ..., 31]
- `task4`: [10, 8, 6, ..., -20]
- `task5`: 
  - Sub-array 1: [3, 6, 9, ..., 45]
  - Sub-array 2: [5, 10, 15, ..., 45]
  - Sub-array 3: [15, 30, 45]

## Notes

- The script uses `console.log` to display the contents of each array.
- The arrays are dynamically filled based on the conditions specified in the loops.
- The `task5` array demonstrates the use of a 2D array to store related data.
