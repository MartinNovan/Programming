#include <stdio.h>

int main(void) {
    /* Types of loops in C:
     * While loop: Executes as long as a condition is true.
     * Do-while loop: Executes at least once and then continues as long as a condition is true.
     * For loop: Executes a block of code a specific number of times, often with an iterator.
     *
     * For-each loop: Not natively supported in C, but can be simulated using pointers or arrays.
     */

    /* Difference between while and for loops:
     * While loop: Checks the condition before executing the loop body.
     * For loop: Combines initialization, condition checking, and increment/decrement in one line.
     * Do-while loop: Executes the loop body at least once before checking the condition.
     */

    // Example of a while loop
    int i = 0;
    while (i < 5) { // Loop until i is less than 5
        printf("While loop iteration: %d\n", i);
        i++;
    } // This will run 5 times, printing 0 to 4
    // Example of a do-while loop
    int j = 0;
    do { // Execute at least once
        printf("Do-while loop iteration: %d\n", j);
        j++;
    } while (j < 5); // Continue while j is less than 5
    // This will also run 5 times, printing 0 to 4

    // Note: The do-while loop guarantees at least one execution, even if the condition is false initially.
    // Example of a do-while loop with a condition that is false initially
    int k = 5;
    do {
        printf("Do-while loop with false condition: %d\n", k);
        k++;
    } while (k < 5); // This will run only once, printing 5

    // Example of a for loop
    /* For loop condition is combined with 3 parts:
     * 1. Initialization: int k = 0; -> runs once at the start.
     * 2. Condition: k < 5; -> checked before each iteration.
     * 3. Increment: k++ -> executed after each iteration.
     */
    for (int k = 0; k < 5; k++) { // Loop from 0 to 4
        printf("For loop iteration: %d\n", k);
    } // This will run 5 times, printing 0 to 4

    // Example of a for-each loop using an array
    int arr[] = {1, 2, 3, 4, 5}; // An array of integers
    int size = sizeof(arr) / sizeof(arr[0]); // Calculate the size of the array
    for (int *ptr = arr; ptr < arr + size; ptr++) { // Pointer to iterate through the array
        printf("For-each loop iteration: %d\n", *ptr);
    } // This will print each element of the array


    // Break and continue statements
    for (int m = 0; m < 10; m++) {
        if (m == 5) {
            printf("Breaking at m = %d\n", m);
            break; // Exit the loop when m is 5
        }
        printf("Loop iteration before break: %d\n", m);
    }
    for (int n = 0; n < 10; n++) {
        if (n % 2 == 0) {
            // Skip even numbers
            printf("Continuing at n = %d\n", n);
            continue; // Skip the rest of the loop body for even numbers
        }
        printf("Loop iteration after continue: %d\n", n); // This will only print odd numbers
    }
    return 0;
}