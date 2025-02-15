# Old code with complex logic
# def evaluate_condition(a):
#     if a > 0:
#         if a < 10:
#             if a % 2 == 0:
#                 print("a is positive, less than 10, and even.")
#             else:
#                 print("a is positive, less than 10, and odd.")
#         else:
#             if a % 2 == 0:
#                 print("a is positive, 10 or more, and even.")
#             else:
#                 print("a is positive, 10 or more, and odd.")
#     elif a == 0:
#         print("a is zero.")
#     else:
#         print("a is negative.")

# New code with simplified logic
def evaluate_condition(a):
    if a == 0:
        print("a is zero.")
        return

    if a > 0:
        evaluate_positive(a)
    else:
        print("a is negative.")

def evaluate_positive(a):
    size = "less than 10" if a < 10 else "10 or more"
    parity = "even" if a % 2 == 0 else "odd"
    print(f"a is positive, {size}, and {parity}.")