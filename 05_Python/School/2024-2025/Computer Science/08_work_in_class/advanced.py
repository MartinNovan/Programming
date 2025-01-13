import math

def factorial(n: int) -> int:
    """
    Calculates the factorial of a given integer n >= 0.
    """
    if n < 0:
        raise ValueError("Negative values are not allowed.")
    if n == 0:
        return 1
    result = 1
    for i in range(1, n + 1):
        result *= i
    return result


def distance_2d(x1: float, y1: float, x2: float, y2: float) -> float:
    """
    Calculates the Euclidean distance between two points (x1, y1) and (x2, y2).
    """
    dx = x2 - x1
    dy = y2 - y1
    return math.sqrt(dx**2 + dy**2)


def calculate_bmi(weight_kg: float, height_m: float) -> float:
    """
    Calculates BMI = weight (kg) / (height (m)^2).
    """
    return weight_kg / (height_m ** 2)


def menu():
    """
    Simple CLI menu for blackbox testing:
    The user selects a function and inputs values, the function prints the result.
    """
    while True:
        print("\n--- ADVANCED CALC MENU ---")
        print("1) Factorial")
        print("2) Distance (2D)")
        print("3) BMI")
        print("4) Exit")
        
        choice = input("Enter your choice: ").strip()
        if choice == "1":
            n_str = input("Enter an integer n>=0: ")
            try:
                n = int(n_str)
                print(f"factorial({n}) = {factorial(n)}")
            except ValueError:
                print("Error: the input is not valid!")
        elif choice == "2":
            try:
                x1 = float(input("x1: "))
                y1 = float(input("y1: "))
                x2 = float(input("x2: "))
                y2 = float(input("y2: "))
                print(f"distance_2d({x1}, {y1}, {x2}, {y2}) = {distance_2d(x1, y1, x2, y2)}")
            except ValueError:
                print("Error: the input is not valid!")
        elif choice == "3":
            try:
                w = float(input("Enter weight in kg: "))
                h = float(input("Enter height in meters: "))
                print(f"BMI({w}, {h}) = {calculate_bmi(w, h)}")
            except ValueError:
                print("Error: the input is not valid!")
        elif choice == "4":
            print("Exiting the program.")
            break
        else:
            print("Invalid choice, please try again.")


if __name__ == "__main__":
    menu()