random = 564
print(random)

# Conditional statement
if random < 600:
    print(random)

# Loop from 'random' to 599
for i in range(random, 600):
    print(i)
    i = i + 1

# List operations
my_list = [0, 1, 2, 3, 4, 5, 6]
print(my_list)
my_list.pop(2)  # Remove element at index 2
print(my_list)
my_list.append(10)  # Add element to the end
print(my_list)
my_list[4] = 50  # Change element at index 4
print(my_list)

# Function definition
def main():
    name = input("Enter your name:")
    print("Welcome!", name)

# Function call
main()
