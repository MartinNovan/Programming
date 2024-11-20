# Old code with complex logic
# def analyze_data(data):
#     if data and len(data) > 0:
#         total = 0
#         for value in data:
#             if value > 0:
#                 if value % 2 == 0:
#                     total += value
#                 else:
#                     total -= value
#             else:
#                 print("Non-positive value encountered:", value)
#         print("Final total:", total)
#     else:
#         print("Data is empty or undefined.")

# New code with simplified logic
def analyze_data(data):
    if not data:
        print("Data is empty or undefined.")
        return

    total = 0
    for value in data:
        if value <= 0:
            print("Non-positive value encountered:", value)
            continue

        total += value if value % 2 == 0 else -value

    print("Final total:", total)