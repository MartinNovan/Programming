inventory = {'Widget': 10}

def update_inventory(product, quantity):
    inventory[product] -= quantity
    print(f"{quantity} units of {product} sold.")

update_inventory('Widget', 5)
