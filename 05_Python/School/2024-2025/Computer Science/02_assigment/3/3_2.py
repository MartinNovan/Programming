# Old code
# final_price = base_price * 0.95  # Apply 5% discount
# if is_member:
#     final_price = base_price * 0.90  # Members get 10% discount
# print("Final price: $", final_price)

# New code with named constants
STANDARD_DISCOUNT = 0.05
MEMBER_DISCOUNT = 0.10

final_price = base_price * (1 - STANDARD_DISCOUNT)
if is_member:
    final_price = base_price * (1 - MEMBER_DISCOUNT)
print("Final price: $", final_price)