#include <stdio.h>

int main(void) {
    // If statement example
    int a = 10, b = 20;
    if (a < b) { // Check if a is less than b
        printf("a is less than b\n"); // This block executes if the condition is true
    } else if (a == b) { // Check if a is equal to b
        printf("a is equal to b\n"); // This block executes if the condition is true
    } else { // If neither of the above conditions is true
        printf("a is not less than b\n"); // This block executes if the condition is false
    }
    // Short Hand if statement example
    int max = (a > b) ? a : b; // Ternary operator to find the maximum of a and b
    /* How it works:
     * (a > b) -> Condition to check if a is greater than b
     * ? -> If true, return value after the question mark
     * : -> If false, return value after the colon
     */
    printf("The maximum value is: %d\n", max); // Print the maximum value

    // Switch statement example
    int day = 4;

    switch (day) { // Switch statement to determine the day of the week
        case 1: // if day is 1 this block executes
            printf("Monday");
            break; // break statement to exit the switch after executing this case
        case 2:
            printf("Tuesday");
            break;
        case 3:
            printf("Wednesday");
            break;
        case 4:
            printf("Thursday");
            break;
        case 5:
            printf("Friday");
            break;
        case 6:
            printf("Saturday");
            break;
        case 7:
            printf("Sunday");
            break;
    }

    switch (day) {
        case 6:
            printf("Today is Saturday");
            break;
        case 7:
            printf("Today is Sunday");
            break;
        default: // Default case if none of the above cases match
            printf("Looking forward to the Weekend"); // This block executes if day is not 6 or 7
            break;
    }

    return 0;
}