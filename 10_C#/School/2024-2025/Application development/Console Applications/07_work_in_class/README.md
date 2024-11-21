# File Processing and Caesar Cipher Application

This console application demonstrates file handling and the implementation of a Caesar cipher in C#. It reads text from a file, writes to a file, and encodes text using a simple Caesar cipher algorithm.

## Features

1. **File Reading**: The program reads text from a file named `text.txt` located in the `bin/Debug/net...` directory. It demonstrates how to read the entire content of a file using `StreamReader`. **Make sure that the `text.txt` file exists in the output directory before running the program.**
2. **File Writing**: The program creates a new file based on command-line arguments. It writes predefined messages to this file using `StreamWriter`.
3. **Caesar Cipher**: The program implements a Caesar cipher, which shifts each character in the input text by a specified key. The encoded text is then written to another file.
4. **Command-Line Arguments**: The program requires command-line arguments to specify the output file for writing, the input file for the Caesar cipher, the output file for the encoded text, and the shift key for the cipher.

## Code Explanation

### Main Method

- The `Main` method serves as the entry point of the program. It checks for command-line arguments and proceeds with file operations if arguments are provided.
- It reads from `text.txt`, writes to a file specified by the first command-line argument, and processes the Caesar cipher using the input and output files specified by the subsequent arguments.

### File Handling

- **StreamReader**: Used to read the contents of `text.txt`. The program reads the entire file and stores its content in a string.
- **StreamWriter**: Used to create a new file and write messages to it. The file name is provided as a command-line argument.

### Caesar Cipher Implementation

- The `Coder` class is responsible for encoding text using the Caesar cipher. It takes the text and a key as parameters.
- The `Encode` method shifts each character in the text by the specified key and returns the encoded string.

### Command-Line Arguments

- The program expects the following command-line arguments:
  1. The name of the output file to write messages.
  2. The name of the input file for the Caesar cipher.
  3. The name of the output file for the encoded text.
  4. The shift key for the Caesar cipher (an integer).

## Conclusion

This File Processing and Caesar Cipher Application serves as a practical example of file handling, command-line argument processing, and basic encryption techniques in C#. It demonstrates how to read from and write to files, as well as how to implement a simple encryption algorithm. The program is designed to be educational and provides a clear understanding of these concepts in C# programming.