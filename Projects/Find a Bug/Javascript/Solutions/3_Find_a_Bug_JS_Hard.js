// Modify the code to achieve the result
function isEven(number) {
    // Note: the operation number % 2 returns the remainder of dividing the number by 2
    if ((number % 2) == 0) { // Originally, the condition had only one = which is used for assignment, not comparison. For comparison, we use == or === (== and === work similarly but are not the same! Both will work here).
        return true; // Returns true if the number is even
    } else {
        return false; // Returns false if the number is odd
    }
}
console.log("Is even: " + isEven(4)); // Resulting output = Is even: true
console.log("Is even: " + isEven(7)); // Resulting output = Is even: false