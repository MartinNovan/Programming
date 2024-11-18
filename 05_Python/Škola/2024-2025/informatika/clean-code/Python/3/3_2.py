final_price = base_price * 0.95  # Apply 5% discount
if is_member:
    final_price = base_price * 0.90  # Members get 10% discount
print("Final price: $", final_price)
