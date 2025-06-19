#include <stdio.h>
#include <stdbool.h> // For boolean type in C99 and later

int main(void) {
    /*
     * Variable names cannot start with a digit.
     * Variable names cannot be a reserved keyword in C. (such as int, return, if, etc.)
     * Variable names cannot have space in it.
     * Variable names must start with a letter or an underscore.
     * Variable names can contain letters, digits, and underscores up to 31 characters.
     * Variable names are case-sensitive.
     */
    int myInteger = 15; // Integer variable - can hold whole numbers
    float myFloat = 5.99; // Float variable - can hold decimal numbers
    double myDouble = 19.99; // Double variable - can hold larger decimal numbers
    long myLong = 1234567890; // Long variable - can hold larger whole numbers

    char myChar = 'A'; // Char variable - can hold a single character
    char myString[] = "Hello, World!"; // String variable - can hold a sequence of characters, in C, strings are arrays of characters

    int myArray[5] = {1, 2, 3, 4, 5}; // Array variable - can hold multiple values of the same type

    bool myBoolean = 1; // Boolean variable - can hold true (1) or false (0) values, requires <stdbool.h> header in C99 and later

    const int myArraySize = 5; // Constant variable - cannot be changed after initialization, can be used for every type of variable

    int myDecimalInt = 10; // In integer variable we can hold value in decimal format
    int myOctalInt = 010; // In octal variable we can hold value in octal format (starts with 0)
    int myHexInt = 0x10; // In hexadecimal variable we can hold value in hexadecimal format (starts with 0x)

    // You can also create variables without initializing them
    int uninitializedVariable; // This variable is declared but not initialized

    // You can also declare multiple variables of the same type in one line and assign values to them or not
    int anotherInteger = 50, yetAnotherInteger = 30; // anotherInteger is initialized to 50, yetAnotherInteger is initialized to 30
    int anotherInt, yetAnotherInt; // Both are uninitialized but declared

    // When you need to use the uninitialized variable, you can assign a value to it later
    uninitializedVariable = 20; // Now the variable has a value
    // You can also assign same value to multiple variables at once
    uninitializedVariable = myDecimalInt = 40; // Assigning the value 40 to both uninitializedVariable and myDecimalInt, you need to have both variables declared before this line

    // When we print variables, we can use format specifiers to control how the output is displayed
    /*
     * Format specifiers in C with examples:
     * %d / %i   : signed int         -> printf("%d", 10);
     * %u        : unsigned int       -> printf("%u", 10u);
     * %o        : unsigned int (octal) -> printf("%o", 10);
     * %x / %X   : unsigned int (hexadecimal) -> printf("%x", 255);
     * %f / %F   : float              -> printf("%f", 3.14);
     * %lf       : double             -> printf("%lf", 3.14159);
     * %Lf       : long double        -> printf("%Lf", 3.141592L);
     * %e / %E   : double (scientific notation) -> printf("%e", 3.14);
     * %g / %G   : double (shortest representation of %%f or %%e) -> printf("%g", 3.14);
     * %a / %A   : double (hexadecimal floating-point) -> printf("%a", 3.14);
     * %c        : char               -> printf("%c", 'A');
     * %s        : string (null-terminated char array) -> printf("%s", "text");
     * %p        : pointer (address)  -> printf("%p", ptr);
     * %n        : number of characters written so far (writes into int*) -> int count; printf("Hello%n", &count);
     * %%        : literal '%' character -> printf("%%");
     *
     * Length modifiers:
     *   h   : short int (e.g., %hd)
     *   l   : long int (e.g., %ld) / double for %lf
     *   ll  : long long int (e.g., %lld)
     *   L   : long double (e.g., %Lf)
     */
    printf("%d\n", myInteger);
    printf("%f\n", myFloat);
    printf("%.3f\n", myFloat); // Printing float with 3 decimal places
    printf("%lf\n", myDouble);
    printf("%ld\n", myLong);
    printf("%c\n", myChar);
    printf("%s\n", myString);
    printf("%d\n", myBoolean);
    printf("%d\n", myArray[0]); // Accessing the first element of the array
    printf("%d\n", myDecimalInt);
    printf("%d\n", myOctalInt); // Octal representation
    printf("%d\n", myHexInt); // Hexadecimal representation
    printf("%d\n", uninitializedVariable); // Printing the value of the uninitialized variable after assignment

    int sum = myInteger + myDecimalInt; // Adding two integer variables
    int multiplication = myInteger * myDecimalInt; // Multiplying two integer variables
    int division = myInteger / myDecimalInt; // Dividing two integer variables
    int subtraction = myInteger - myDecimalInt; // Subtracting two integer variables
    int modulus = myInteger % myDecimalInt; // Modulus operation on two integer variables
    int increment = ++myInteger; // Incrementing myInteger by 1
    int decrement = --myDecimalInt; // Decrementing myDecimalInt by 1
    printf("Sum of myInteger and myDecimalInt: %d\n", sum);
    printf("Multiplication of myInteger and myDecimalInt: %d\n", multiplication);
    printf("Division of myInteger by myDecimalInt: %d\n", division);
    printf("Subtraction of myInteger and myDecimalInt: %d\n", subtraction);
    printf("Modulus of myInteger and myDecimalInt: %d\n", modulus);
    printf("Incremented myInteger: %d\n", increment);
    printf("Decremented myDecimalInt: %d\n", decrement);

    //Memory size of different data types
    printf("Size of int: %zu bytes\n", sizeof(int)); // Size of int = 4 bytes
    printf("Size of float: %zu bytes\n", sizeof(float)); // Size of float = 4 bytes
    printf("Size of double: %zu bytes\n", sizeof(double)); // Size of double = 8 bytes
    printf("Size of long: %zu bytes\n", sizeof(long)); // Size of long = 4 bytes
    printf("Size of char: %zu bytes\n", sizeof(char)); // Size of char = 1 byte
    printf("Size of string: %zu bytes\n", sizeof(myString)); // Size of string (array of characters) - includes null terminator
    printf("Size of array: %zu bytes\n", sizeof(myArray)); // Size of array (5 integers) = 5 * sizeof(int)
    printf("Size of constant: %zu bytes\n", sizeof(myArraySize)); // Size of constant (int) = 4 bytes
    printf("Size of uninitialized variable: %zu bytes\n", sizeof(uninitializedVariable)); // Size of uninitialized variable (int) = 4 bytes

    // Conversion between different data types
    int maxScore = 100; // Integer variable
    int userScore = 85; // Integer variable
    float percentage = (float)userScore / maxScore * 100; // Converting integer to float using type casting
    printf("Percentage: %.2f%%\n", percentage); // Printing percentage with 2 decimal places

    // Working with arrays
    int numbers[] = {10, 20, 30, 40, 50};
    int numbers2[5] = {10, 20, 30, 40, 50};
    // These both declarations are equivalent, but in the second case, we explicitly define the size of the array. You cannot change the size of the array after declaration.
    // Accessing elements of the array
    printf("First element of numbers: %d\n", numbers[0]);
    // You can get the size of the array using sizeof operator
    int length = sizeof(numbers) / sizeof(numbers[0]); // Calculate the number of elements in the array

    int matrix[2][3] = { {1, 4, 2}, {3, 6, 8} }; // 2D array (matrix) with 2 rows and 3 columns
    /*
     * you can see it like this:
     * 1 4 2
     * 3 6 8
     */
    // Accessing 2D array is similar to 1D array, but you need to specify both row and column indices
    printf("Element at matrix[0][1]: %d\n", matrix[0][1]); // Accessing the element in the first row and second column

    return 0;
}
