# Old code with side effects
# inventory = {'Widget': 10}
# def update_inventory(product, quantity):
#     inventory[product] -= quantity
#     print(f"{quantity} units of {product} sold.")

# New code without side effects
def update_inventory(inventory, product, quantity):
    new_inventory = inventory.copy()
    new_inventory[product] -= quantity
    print(f"{quantity} units of {product} sold.")
    return new_inventory

inventory = {'Widget': 10}
inventory = update_inventory(inventory, 'Widget', 5)