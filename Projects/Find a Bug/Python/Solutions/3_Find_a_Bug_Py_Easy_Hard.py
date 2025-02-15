class Counter: # A class that has 2 methods.
    def __init__(self): # 1st method (automatically runs when the class is created due to the use of __init__)
        # Initialize the counter to 0
        self.count = 0

    def increment(self): # 2nd method (runs only when called)
        # Increase the counter value by 1
        self.count += 1

# Creating an instance of the Counter class and storing it in variable c1.
c1 = Counter()

# Creating another variable c2, which will reference the same instance as c1.
c2 = c1

# Fix the error below
c2.increment() # Use the increment method on c2 to increase the count by one. This will achieve the result.
# Fix the error above

# Print the count value from c1 and verify that it has increased.
print("c2: " + str(c2.count)) # Expected result: c2: 1