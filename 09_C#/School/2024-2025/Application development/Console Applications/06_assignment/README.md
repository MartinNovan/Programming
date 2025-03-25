# Book Value Comparison Application

This console application allows users to compare different types of books based on their value. It demonstrates the use of interfaces, classes, and polymorphism in C#. The program creates instances of different book types and determines which book has the highest value.

## Features

1. **Interface Implementation**: The program defines an `IBook` interface that requires implementing a `GetValue()` method, which calculates the value of the book.
2. **Book Classes**: There are three classes representing different genres of books:
   - **FantasyBook**: Represents a fantasy book with a name, author, and price.
   - **ScifiBook**: Represents a science fiction book with a name, author, price, and page count. Its value is calculated based on its price and page count.
   - **DetectiveBook**: Represents a detective book with a name, author, price, and number of victims. Its value is calculated based on its price and the number of victims.
3. **Comparison Logic**: The program includes a method to compare two books and determine which one has a higher value. If both books have the same value, one is chosen randomly.
4. **Best Book Selection**: The program creates a list of books and determines the best book by comparing their values.

## Code Explanation

### IBook Interface

- The `IBook` interface defines a contract for book classes, requiring them to implement the `GetValue()` method.

### Book Classes

- **FantasyBook**: Implements the `IBook` interface and provides a method to return its price as its value.
- **ScifiBook**: Implements the `IBook` interface and calculates its value based on its price and page count.
- **DetectiveBook**: Implements the `IBook` interface and calculates its value based on its price and the number of victims.

### Program Class

- The `Program` class contains the `Main` method, which initializes a list of books and determines the best book by comparing their values using the `BetterBook` method.

### BetterBook Method

- The `BetterBook` method compares two books and returns the one with the higher value. If both books have the same value, it randomly selects one.

### Main Method

- The `Main` method creates a list of books, finds the best book by comparing all books in the list, and outputs the name and value of the best book.

## Conclusion

This Book Value Comparison Application serves as a practical example of object-oriented programming concepts in C#. It demonstrates the use of interfaces, class inheritance, and polymorphism. The program is designed to be educational and provides a clear understanding of how to implement and use interfaces in C#.