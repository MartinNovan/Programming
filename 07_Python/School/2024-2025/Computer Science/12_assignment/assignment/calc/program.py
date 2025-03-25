def calc_price(total, discount_code):
    """
    Calculates the final price of an order in an e-shop after applying a discount code if applicable.

    Steps:
      1. If the total price (total) is less than 100, raises ValueError, as a discount code cannot be used.
      2. If no discount code is provided (None), returns the original price.
      3. If a discount code is provided, checks its validity (only "DISCOUNT10" and "DISCOUNT20" are valid).
         If the code is invalid, raises ValueError.
      4. If the discount code is valid, sets the percentage discount:
            - "DISCOUNT10" => 10%
            - "DISCOUNT20" => 20%
      5. Calculates the final price: total * (1 - discount).

    Parameters:
      total (float): Total price of the order.
      discount_code (str | None): Discount code entered by the customer.

    Return value:
      float: Final price of the order after deducting the discount.

    Raises:
      ValueError: If the order does not meet the conditions or the discount code is invalid.
    """
    if total < 100:
        raise ValueError("The order must have a minimum of 100 to use a discount code.")

    if not discount_code:
        return total

    if discount_code not in ("DISCOUNT10", "DISCOUNT20"):
        raise ValueError("Invalid discount code.")

    if discount_code == "DISCOUNT10":
        discount = 0.10
    else:  # discount_code == "DISCOUNT20"
        discount = 0.20

    return total * (1 - discount)