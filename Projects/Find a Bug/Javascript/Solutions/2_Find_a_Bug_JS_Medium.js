let numbers = [1, 2, 3]; // Array with numbers 1, 2, and 3
// Error: We start with i at 0, but the original condition states that the loop should run while i is greater than the length of the array. This means the loop will never start because 0 is not greater than or equal to 3 (the length of the array).
for (let i = 0; i < numbers.length; i++) { // Now the condition states that the loop should run while i is less than the length of the array. Currently, the loop will repeat according to the length of the array (which is 3 times here).
    console.log(numbers[i]); // Prints the current number from the array
}

/* The result is these numbers:
1
2
3
*/