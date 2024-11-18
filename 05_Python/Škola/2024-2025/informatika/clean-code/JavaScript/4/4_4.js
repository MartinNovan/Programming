function updateInventory(product, quantity) {
  inventory[product] -= quantity;
  console.log(quantity + " units of " + product + " sold.");
}

updateInventory("Widget", 5);
