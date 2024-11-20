//first calculator in JS
function calculate(num1, operator, num2){
    var result;
    switch(operator){
    case "+":
        result = num1 + num2
        break;
    case "-":
        result = num1 - num2
        break;
    case "/":
        if (num2 === 0){
            console.log("error")
        } else {
        result = num1 / num2
            } break;
    case "*":
        result = num1 * num2
        break;
    }
console.log(result)
}
calculate(4, "*", 8)