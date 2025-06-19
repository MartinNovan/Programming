#include <stdio.h>

int main(void) {
    /*
     * Operators in C with examples:
     * Arithmetic Operators:
     *   +  Addition: a + b
     *   -  Subtraction: a - b
     *   *  Multiplication: a * b
     *   /  Division: a / b
     *   %  Modulus (remainder): a % b
     *
     * Assignment Operators:
     *   =   Assignment: a = 5
     *   +=  Addition assignment: a += 5 (same as a = a + 5)
     *   -=  Subtraction assignment: a -= 5
     *   *=  Multiplication assignment: a *= 5
     *   /=  Division assignment: a /= 5
     *   %=  Modulus assignment: a %= 5
     *
     * Comparison Operators:
     *   ==  Equal to
     *   !=  Not equal to
     *   >   Greater than
     *   <   Less than
     *   >=  Greater than or equal to
     *   <=  Less than or equal to
     *
     * Logical Operators:
     *   &&  Logical AND: (a > 5 && b < 10) -> Returns 1 if both statements are true
     *   ||  Logical OR:  (a > 5 || b < 10) -> Returns 1 if one of the statements is true
     *   !   Logical NOT: !(a > 5) -> Returns 1 if the statement is false
     *
     * Bitwise Operators:
     *   &   Bitwise AND: a & b -> Performs AND on each bit (e.g., 5 & 3 = 1)
     *   |   Bitwise OR:  a | b -> Performs OR on each bit (e.g., 5 | 3 = 7)
     *   ^   Bitwise XOR: a ^ b -> Performs XOR on each bit (e.g., 5 ^ 3 = 6)
     *   ~   Bitwise NOT: ~a -> Inverts all bits (e.g., ~5 = -6 for 32-bit int)
     *   <<  Left shift:  a << 1 -> Shifts bits to the left (multiplies by 2, e.g., 5 << 1 = 10)
     *   >>  Right shift: a >> 1 -> Shifts bits to the right (divides by 2, e.g., 5 >> 1 = 2)
     *
     * Increment/Decrement:
     *   ++a  Pre-increment: Increases value by 1, then uses it (e.g., int x = ++a;)
     *   a++  Post-increment: Uses the value, then increases it by 1 (e.g., int x = a++;)
     *   --a  Pre-decrement: Decreases value by 1, then uses it (e.g., int x = --a;)
     *   a--  Post-decrement: Uses the value, then decreases it by 1 (e.g., int x = a--;)
     *
     * Conditional (Ternary):
     *   condition ? expr1 : expr2 -> Returns expr1 if condition is true, otherwise expr2
     *   Example: int max = (a > b) ? a : b;
     *
     * Comma Operator:
     *   int a = (1, 2); -> Evaluates all expressions, returns the last one (a will be 2)
     *
     * sizeof Operator:
     *   sizeof(type) or sizeof(variable) -> Returns size in bytes (e.g., sizeof(int) = 4)
     *
     * Pointer Operators:
     *   *   dereference: *ptr -> Accesses the value pointed to by ptr
     *   &   address-of:  &var -> Returns the memory address of var
     *
     * Typecast Operator:
     *   (type)expression -> Converts a value to a different type (e.g., (float)5 -> 5.0)
     */

    // BITWISE OPERATORS
    int a = 5;      // binary: 0101
    int b = 3;      // binary: 0011

    printf("Bitwise AND (a & b): %d\n", a & b); // 0101 & 0011 = 0001 -> 1
    printf("Bitwise OR  (a | b): %d\n", a | b); // 0101 | 0011 = 0111 -> 7
    printf("Bitwise XOR (a ^ b): %d\n", a ^ b); // 0101 ^ 0011 = 0110 -> 6
    printf("Bitwise NOT (~a): %d\n", ~a);       // ~0101 = 1010... -> -6 (two's complement)
    printf("Left shift (a << 1): %d\n", a << 1); // 0101 << 1 = 1010 -> 10
    printf("Right shift (a >> 1): %d\n", a >> 1); // 0101 >> 1 = 0010 -> 2

    // INCREMENT/DECREMENT
    int x = 10;
    int y;

    y = ++x; // Pre-increment: x becomes 11, then y is assigned 11
    printf("Pre-increment: x = %d, y = %d\n", x, y);

    x = 10;
    y = x++; // Post-increment: y is assigned 10, then x becomes 11
    printf("Post-increment: x = %d, y = %d\n", x, y);

    x = 10;
    y = --x; // Pre-decrement: x becomes 9, y = 9
    printf("Pre-decrement: x = %d, y = %d\n", x, y);

    x = 10;
    y = x--; // Post-decrement: y = 10, then x becomes 9
    printf("Post-decrement: x = %d, y = %d\n", x, y);

    // CONDITIONAL (TERNARY) OPERATOR
    int score = 85;
    int passingMark = 50;
    const char* result = (score >= passingMark) ? "Passed" : "Failed";
    printf("Result: %s\n", result); // Prints "Passed"

    // COMMA OPERATOR
    int value = (printf("Evaluating... "), 100); // Prints "Evaluating...", then assigns 100
    printf("Comma operator result: %d\n", value);

    // SIZEOF OPERATOR
    printf("Size of int: %zu bytes\n", sizeof(int));
    printf("Size of double: %zu bytes\n", sizeof(double));

    // POINTER OPERATORS
    int num = 42;
    int* ptr = &num; // & -> gets address of num
    printf("Address of num: %p\n", (void*)ptr); // address
    printf("Value at ptr: %d\n", *ptr);         // * -> dereference, gets value at that address

    // TYPECAST OPERATOR
    int intVal = 7;
    float floatVal = (float)intVal / 2; // Cast int to float to get accurate division
    printf("Typecast int to float: %.2f\n", floatVal); // 3.50

    return 0;
}