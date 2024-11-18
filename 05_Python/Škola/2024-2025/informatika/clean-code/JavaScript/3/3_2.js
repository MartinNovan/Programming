let finalPrice = basePrice * 0.95; // Apply 5% discount
if (isMember) {
    finalPrice = basePrice * 0.90; // Members get 10% discount
}
console.log("Final price: $" + finalPrice);
