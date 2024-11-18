function c(a, b) {
  let d = Math.sqrt(a * a + b * b);
  console.log("The result is: " + d);
  return d;
}

let x = 3;
let y = 4;
let r = c(x, y);
console.log("Computed value: " + r);
