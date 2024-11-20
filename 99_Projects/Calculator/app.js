let powerActive = 0; // Variable to store the state of whether a power function is active
let alreadyInPower = 0; // Variable to check if we are already writing in a power function
const inputField = document.querySelector(".inputfield");
const outputField = document.querySelector(".outputfield");

// Function to write to the input field using buttons
function toInput(indx) {
    if (indx === "C") {
        inputField.value = ""; // Clear input
        outputField.value = ""; // Clear output
        powerActive = 0; // Reset helper variable
        alreadyInPower = 0; // Reset another helper variable
    } else if (indx === "DEL") {
        inputField.value = inputField.value.slice(0, -1); // Delete the last character in the input line
    } else if (indx === "=") {
        if (inputField.value === "") {
            alert("You must write something!"); // If "=" is pressed and the input line is empty, show an error
        } else {
            calculate(); // If the input line is valid, call the calculate function
        }
    // Handle entries using parentheses and the "^" sign
    } else if (indx === "SIN" || indx === "COS" || indx === "TAN" || indx === "√x") {
        if (indx === "√x") {
            inputField.value += "√(";
        } else {
            inputField.value += indx + "(";
        }
    } else if (indx === "10ˣ" || indx === "x²" || indx === "xʸ") {
        if (indx === "x²") {
            inputField.value += "²"; // For the second power, we use the power notation
            // For others, we handle using the notation x^(y), the closing parenthesis must always be typed manually by pressing the same button again
        } else if (indx === "10ˣ" || indx === "xʸ") {
            if (indx === "10ˣ") {
                if (powerActive === 1) {
                    powerActive = 0;
                    alreadyInPower = 0;
                    inputField.value += ")"; 
                } else {
                    powerActive = 1;
                    inputField.value += "10" + "^" + "(";
                }
                // Writing "^(" or ")" depending on whether the power is expanded or a new one is starting
            } else {
                if (powerActive === 1) {
                    powerActive = 0;
                    alreadyInPower = 0;
                    inputField.value += ")"; 
                } else {
                    powerActive = 1;
                    inputField.value += "^" + "(";
                }
            }
        }
    } else {
        if (powerActive === 1) {
            if (alreadyInPower === 0) {
                inputField.value += indx;
                alreadyInPower = 1;
            } else {
                inputField.value += indx;
            }
        } else {
            inputField.value += indx;
        }
    }
}

function calculate() {
    try {
        const expression = inputField.value.replace(/×/g, '*').replace(/\^/g, '**').replace(/²/g, '**2').replace(/π/g, Math.PI); // Replace certain characters with those we will use in the calculation
        const result = eval(expression); // Calculate using the eval function
        outputField.value = result; // Output the result
    } catch (error) {
        outputField.value = "Error"; // If there is an error, display "Error" in the output field
        console.error(error); // Also log the error to the console
    }
}
