def find_maximum(numbers):
    # This function finds the largest number in a list of numbers.
    
    # Initialize the variable max_num to the smallest possible number,
    # so we can compare it with the numbers in the list.
    # If we left the number at 0, then no number in the list would be greater, leading to unusable code.
    # Note: the number could also be set to -4 for the code to work, and that is also a correct solution, but here we show the ideal case where we don't see the numbers.
    max_num = float('-inf')  
    
    # For each number in the 'numbers' list, we do the following:
    for num in numbers:
        # Check if the current number (num) is greater than max_num.
        if num > max_num:
            # If so, update max_num to this number.
            max_num = num  # max_num now contains the larger number.
    
    # After examining all the numbers, we return the largest number we found.
    return max_num  # Returns the maximum number found in the list.

# Here we test the function with an example where we expect it to return -1,
# because that is the largest number in the list [-1, -2, -3].
print(find_maximum([-1, -2, -3])) # Expected result: -1