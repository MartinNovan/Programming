#include <stdio.h>
#include <string.h>

int main(void) {
    char alphabet[] = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    // Printing the length of the string and the size of the array
    printf("%zu\n", strlen(alphabet)); // Length of the string (number of characters before null terminator)
    printf("%zu\n", sizeof(alphabet)); // Size of the array (includes null terminator "/0")

    // Concatenate  two strings together
    char str1[20] = "Hello ";
    char str2[] = "World!";

    // Concatenate str2 to str1 (result is stored in str1)
    strcat(str1, str2); // str1 has to be large enough to hold both strings
    printf("%s\n", str1); // Output: Hello World!

    // Copying a string
    char str01[20] = "Hello World!";
    char str02[20];
    // Copy str01 to str02
    strcpy(str02, str01); // str02 must be large enough to hold str01
    printf("%s\n", str02); // Output: Hello World!

    // Comparing two strings
    char str11[] = "Hello";
    char str12[] = "Hello";
    char str13[] = "Hi";

    // Compare str11 and str12, and print the result
    printf("%d\n", strcmp(str11, str12));  // Returns 0 (the strings are equal)

    // Compare str11 and str13, and print the result
    printf("%d\n", strcmp(str11, str13));  // Returns -1 (the strings are not equal)
}