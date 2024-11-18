if product.in_stock:
    print("Product is available.")
else:
    print("Product is out of stock.")

def add_to_cart():
    cart.add(product)
    print("Product added to cart.")
