// These are notes from FreeCodeCamp assignments when I was learning JavaScript. The code is not intended to function.
// If you want to see how it works you can create new .js file and copy-paste the selected program and run it there

var variableName;
// var = variable, must be closed ==> ;

variableName = 2 ;
// We set and change the variable using = and close it ==> ;

var variableName = 0;
// We can define a variable right when we create it; just combine the previous two examples and close it ==> ;

var variableName = "letters";
// We can write in the variable, but we must add "..." instead of dots we can write letters and close it ==> ;

let variableName = ... ;
// The "let" function allows defining a variable only once, and then it cannot be overwritten 

const variableName = ... ;
// The "const" function works similarly to "let" with the only difference that "const" is read-only and must be closed ==> ;

variableName ++ ;
// Using the variable and "++" means that we add 1 to the variable; it's a shorter notation for "variableName = variableName + 1" (no = is written)
// The same can be used for -1 with the only change that instead of ++ we write --

variableName = 5 % 2 ;
// The % sign is used if we want the variable to have a number equal to the remainder; thus, 2 / 5 = 2 remainder 1, so the variable will have the value 1

variableName += 5 ;
// A shortened notation for "variableName = variableName + 5"; the same works for minus and other math signs

variableName = "Some Text \"Some Text\" Some text" ;
// By using \" ... \" in the string, we achieve quotes in the text

variableName = 'Some text "some text" ' ;
// In JavaScript, we can use two types of quotes for strings "..." or '...'; the reason is that if we use "..." we cannot use
// "..." for quotes in the text and we would have to use \"...\"; again, we can use '...' in the text 
// The same applies in reverse; if we use '...' we can use "..." in the text without slashes, but we cannot use '...'
const myStr = '<a href="http://www.example.com" target="_blank">Link</a>';
// In this example, we can see that in conjunction with HTML we use "..." in the string, so we start with '...'

/*
\'	single quote        (To write '...' in the string)
\"	double quote        (To write "..." in the string)
\\	backslash           (To write \...\ in the string)
\n	newline             (To write a new line in the string)
\t	tab                 (To write a tab in the string)
\r	carriage return     (It's a control character in text files indicating the end of a line. It was used in old typewriters and printers, where the carriage had to return to the starting position at the end of a line.)
\b	word boundary       (https://javascript.info/regexp-boundary)
\f	form feed           (In printers, it loads the next page. In some terminal emulators, it clears the screen.)
Here are some shortcuts for editing text in a string.
*/

variableName = "Some Text" + "Some text" ;
// By using + in the string, we achieve combining two texts into one

const variableName = "Some text" ;
variableName += "Some additional text" ;
// We can also combine in this way

const myName = "Martin";
const myStr = "My name is " + myName + " and I am well!";
// We can add variables to the string by using +variableName+ between texts

const someAdjective = "pain in the ass.";
let myStr = "Learning to code is ";
myStr += someAdjective
// Strings can also be combined as variables

let lastNameLength = 0;
const lastName = "Lovelace";
lastNameLength = lastName.length;
// Using .length we can count how many letters are written in the string; we use it by writing variableName.length as shown above

let firstLetterOfLastName = "";
const lastName = "Lovelace";
firstLetterOfLastName = lastName[0];
// To find a specific letter or number, we find out by how many numbers it is away, and we write it using variableName[distance]
// WARNING JAVASCRIPT COUNTS FROM 0 !!!

const lastName = "Lovelace";
const lastLetterOfLastName = lastName[lastName.length-1];
// We can also find the last letter by giving the total number of letters and subtracting 1

const myArray = ["some text", 38, "some more text"];
// Using Array, we can store multiple data in one variable in the style variableName = ["...", ...]; we can store multiple types here, such as strings or numbers

const myArray = [["Team Blue", 39], ["Team Red", 40]];
// We can also store multiple arrays in one array

const myArray = [50, 60, 70];
console.log([myArray[0]]);
const myData = myArray[1];
// Data from the Array is taken according to the position in the string; thus, 50=0, 60=1, 70=2, so console will print number 50 and myData will store number 60

const myArray = [18, 64, 99];
myArray[0] = 45;
// In the array, we can change data using variableName[position] = ...

const arr = [
    [1, 2, 3],
    [4, 5, 6],
    [7, 8, 9],
    [[10, 11, 12], 13, 14]
  ];
  
  const subarray = arr[3];           // [[10, 11, 12], 13, 14]
  const nestedSubarray = arr[3][0];  // [10, 11, 12]
  const element = arr[3][0][1];      // 11
// For an Array that consists of multiple Arrays, we access them step by step and count each time from 0; we write Array next to Array and select the position we need

const myArray = [["John", 23], ["cat", 2]];
myArray.push(["dog", 3]);
// Using the .push function, we can add more data to the array; we write it as variableName.push("data")
// WE ALWAYS ADD AT THE END

const myArray = [["John", 23], ["cat", 2]];
const removedFromMyArray = myArray.pop(["John", 23]);
// Using the .pop function, we can remove data from the array and move it somewhere else or delete it; we write variableName.pop("data")
// IF WE DO NOT SPECIFY IN THE PARENTHESES, IT WILL ALWAYS REMOVE THE LAST DATA

const myArray = [["John", 23], ["dog", 3]];
const removedFromMyArray = myArray.shift();
// Works the same as the .pop function, but instead of the last, it takes the first 

const myArray = [["John", 23], ["dog", 3]];
myArray.shift()
myArray.unshift(["Paul", 35])
// The .unshift function works the same as .push, except that instead of writing the last, it writes the first

function reusableFunction(){
    console.log("Hello World");
  }
  reusableFunction()
// In the function, we write code that we can invoke by writing the function name

function functionWithArgs(param1, param2){
    console.log(param1 + param2)
  }

  functionWithArgs(1, 2) //3
  functionWithArgs(7, 9) //16
// Using functions, we can create a predefined procedure and then use the function with given data
// The function above has defined parameters (param1 and param2) that serve as variables and can be used in the function
// function(variables we need to invoke) <== these can be created here and then replaced or taken from the program

function timesFive(num){
    console.log(num * 5)
  }
  
  timesFive(5)
  timesFive(2)
  timesFive(0)
// Another example for functions

function timesFive(num) {
    return num * 5;
  }
  const answer = timesFive(5);
/*
This code defines a function called timesFive that takes one parameter num and multiplies it by 5. It then calls this function 
with the argument 5 and assigns the result to a variable called answer. When the timesFive function is called with the argument 5, 
it multiplies 5 by five and returns the result, which is 25. This value is then assigned to the variable answer. 
Therefore, the resulting value of the variable answer will be 25.
*/

const variableName = 5 ;
function somefunction(variableName){
variableName = ... ;
}
// If we write a variable outside the function, it becomes a so-called GLOBAL variable, meaning the variable is available everywhere in the code

function somefunction(){
  const variableName = 5 ;
}
// However, if we write a variable into a function, it becomes a so-called LOCAL variable, meaning it can only be used in that specific function

function multiply(a, b) {
  return a * b;
}
let result = multiply(3, 4); // result is now 12
// The return statement is used to end the execution of a function and optionally return a value to the caller
// When the function is called with the arguments 3 and 4, it returns the value 12, which is then assigned to the variable result.
// It's important to note that if the return statement is not included in the function, the function will still return the value undefined to the caller.

function nextInLine(arr, item) {
  arr.push(item);
  return arr.shift();
  return item;
}

// Setup
let testArr = [1, 2, 3, 4, 5];

// Display code
console.log("Before: " + JSON.stringify(testArr));
console.log(nextInLine(testArr, 6));
console.log("After: " + JSON.stringify(testArr));

// Example code for adding numbers and then removing the first number in the sequence

function testEqual(val) {
  if (val == 12) {
    return "Equal";
  }
  return "Not Equal";
}
testEqual(10);
// By using "==" we get an equality operator that we use when comparing two values
// With this type of operator, it doesn't matter if the number is in a string or not, as shown in the example below
/*
1   ==  1  // true
1   ==  2  // false
1   == '1' // true
"3" ==  3  // true
*/

function testStrict(val) {
  if (val===7) { 
    return "Equal";
  }
  return "Not Equal";
}
testStrict(10);
// The "===" operator is a strict equality operator that checks for both value and type equality
// Unlike "==", it does not perform type coercion, so both the value and type must match for it to return true

function testNotEqual(val) {
  if (val != 99) { 
    return "Not Equal";
  }
  return "Equal";
}
testNotEqual(10);
// The "!=" operator signifies inequality and works the same as == but in reverse

function testStrictNotEqual(val) {
  if (val !==17) {
    return "Not Equal";
  }
  return "Equal";
}
testStrictNotEqual(10);
// The same applies to "!==" which works the same as the "===" operator but in reverse

function testGreaterThan(val) {
  if (val>100) {  
    return "Over 100";
  }
  if (val>10) {  
    return "Over 10";
  }
  return "10 or Under";
}
testGreaterThan(10);
// The operators "<" ">" or otherwise greater and less compare two values

function testGreaterOrEqual(val) {
  if (val>=20) { 
    return "20 or Over";
  }
  if (val>=10) { 
    return "10 or Over";
  }
  return "Less than 10";
}
testGreaterOrEqual(10);
// We also have "<=" ">=" or otherwise less than or equal, greater than or equal

function testLogicalAnd(val) {
  if (val > 24 && val < 51) {
    return "Yes";
  }
return "No";
}
testLogicalAnd(10);
// If we need two comparisons, we can combine them into one using "&&" which works as a conjunction "and at the same time" and is true only when both statements are true or false (equivalence)

function testLogicalOr(val) {
  if (val<10 || val>20) {
    return "No";
  }
  return "Yes";
}
testLogicalOr(15);
// The "||" operator works as "between"; here we have shown that numbers from 10 to 20 are "Yes" including 10 and 20
// The logical OR operator "||" returns true if either of the operands is true. Otherwise, it returns false (conjunction)

function testLogicalOr(val) {
  if (val>10 || val<20) {
    return "Yes";
  }
  return "No";
}
testLogicalOr(15);
// However, if we swap "<" and ">" and swap the outputs, we turn the conjunction into a disjunction
// The logical OR operator "||" returns true if either of the operands is true. Otherwise, it returns false (disjunction)

function testElseIf(val) {
  if (val > 10) {
    return "Greater than 10";
  } else if (val < 5) {
 return "Smaller than 5";
  } else{
    return "Between 5 and 10";
  }
}
testElseIf(7);
// If we need to use if multiple times, we use "else" or "else if"

function testSize(num) {
  if(num<5) {
return "Tiny";
  }
    else if(num<10){
return "Small";
    }
    else if(num<15){
return "Medium";
    }
    else if(num<20){
return "Large";
    }
    else if (num>=20) {
return "Huge";
    }
    else{
  return "Change Me";
    }
}
testSize(7);
// Example of using multiple else if statements to categorize a number

function chainToSwitch(val) {
  let answer = "";
switch(val){
  case "bob":
    answer = "Marley"
    break;
  case 42:
    answer = "The Answer"
    break;
  case 1:
    answer = "There is no #1"
    break;
  case 99:
    answer = "Missed me by this much!"
    break;
  case 7:
    answer = "Ate Nine"
    break;
}
  return answer;
}
chainToSwitch(7);
// This way, the code is easier to read and understand

function isEqual(a, b) {
  if (a === b) {
    return true;
  } else {
    return false;
  }
}
// We used to write Boolean (or true/false) this way
// But there is a shorter and faster way

function isEqual(a, b) {
  return a === b;
}
// We can also write Boolean this way, and it's much faster
// The function will return either true or false

function abTest(a, b) {

  if(a<0||b<0){
return undefined
}

  return Math.round(Math.pow(Math.sqrt(a) + Math.sqrt(b), 2));
}
abTest(2,2);
// Code to check if neither of the numbers is 0 or lower
// "undefined" is not a value but a keyword

let count = 0;

function cc(card) {
switch(card){
  case 2:
  case 3:
  case 4:
  case 5:
  case 6:
  count ++ ;
  break;
  case 10:
  case "J":
  case "Q":
  case "K":
  case "A":
  count -- ;
  break;
}
if(count>0){
return count + " Bet";
}
else{
  return count + " Hold";
}
return "Change Me";
}
cc(2); cc(3); cc(7); cc('K'); cc('A');
// Code for card counting

const cat = {
  "name": "Whiskers",
  "legs": 4,
  "tails": 1,
  "enemies": ["Water", "Dogs"]
};
// Objects are similar to arrays, but instead of indexes, data is accessed using properties.
// Objects are useful for structured data storage and can represent real-world objects, like a cat.
// In this example, all properties are stored as strings, such as name, legs, and tails. However, you can also use numbers as properties.
// For single-word string properties, you can even omit the quotes, as follows:
const anotherObject = {
  make: "Ford",
  5: "five",
  "model": "focus"
};
// However, if your object contains non-string properties, JavaScript will automatically convert them to strings.

const testObj = {
  "hat": "ballcap",
  "shirt": "jersey",
  "shoes": "cleats"
};
const hatValue = testObj.hat;
const shirtValue = testObj.shirt;
// Accessing object properties using dot notation

const myObj = {
  "Space Name": "Kirk",
  "More Space": "Spock",
  "NoSpace": "USS Enterprise"
};

myObj["Space Name"];
myObj['More Space'];
myObj["NoSpace"];
// The second way to access object properties is bracket notation ([]).
// If the object property you're trying to access has a space in its name, you must use bracket notation.

const myDog = {
  "name": "Coder",
  "legs": 4,
  "tails": 1,
  "friends": ["freeCodeCamp Campers"]
};
myDog["name"] = "Happy Coder"; 
// We change a property the same way as a regular variable

myDog.bark = "bow-wow";
// or
myDog["bark"] = "bow-bow";
// These are the ways we can add new properties to an object

delete myDog.bark;
// or
delete myDog["bark"]
// We can delete object properties

const article = {
  "title": "How to create objects in JavaScript",
  "link": "https://www.freecodecamp.org/news/a-complete-guide-to-creating-objects-in-javascript-b0e2450655e8/",
  "author": "Kaashan Hussain",
  "language": "JavaScript",
  "tags": "TECHNOLOGY",
  "createdAt": "NOVEMBER 28, 2018"
};

const articleAuthor = article["author"];
const articleLink = article["link"];

const value = "title";
const valueLookup = article[value];
// Notation for looking up values using another variable

const myObj = {
  top: "hat",
  bottom: "pants"
};

myObj.hasOwnProperty("top");
myObj.hasOwnProperty("middle");
// If we need to check if a variable contains the property we need, we can use the .hasOwnProperty() function
// In this example, we can see that the first line will give us TRUE, but the second will give FALSE

const myStorage = {
  "car": {
    "inside": {
      "glove box": "maps",
      "passenger seat": "crumbs"
     },
    "outside": {
      "trunk": "jack"
    }
  }
};

const gloveBoxContents = myStorage.car.inside["glove box"];
// When writing properties into properties, we access them step by step, as shown in the line above

const myPlants = [
  {
    type: "flowers",
    list: [
      "rose",
      "tulip",
      "dandelion"
    ]
  },
  {
    type: "trees",
    list: [
      "fir",
      "pine",
      "birch"
    ]
  }
];

const secondTree = myPlants[1].list[1];
// As we saw in previous examples, objects can contain both nested objects and nested arrays.
// Similar to accessing nested objects, you can use bracket notation to access nested arrays.
// secondTree = "pine"

const myArray = [];
let i = 5;
while(i>= 0){
  myArray.push(i);
  i--;
}
// The first type of loop is called a while loop because it runs as long as the specified condition is true and stops when the condition is no longer true.
// The code adds numbers 5 to 0 (inclusive) in descending order to the myArray using a while loop.

const myArray = [];
for (var i = 1; i < 6; i++) {
  myArray.push(i);
}
// The most common type of loop in JavaScript is called a for loop because it runs a certain cycle as many times as we need.
// For loops are declared with three optional expressions separated by semicolons:
// for (a; b; c), where a is the initialization statement, b is the condition statement, and c is the final expression.
// The initialization statement is executed only once before the loop starts. It is usually used to define and set the loop variable.
// The condition statement is evaluated at the beginning of each loop iteration and will continue as long as it evaluates to true.
// If the condition is false at the start of an iteration, the loop will stop executing.
// In the previous example, we initialize i = 1 and iterate as long as our condition i < 6 is true. In each loop iteration, we increment i by 1, with i++ being our final expression.

const myArray = [];
for (let i = 1; i < 10; i += 2) {
  myArray.push(i);
}
// Another example of a for loop, this time incrementing by 2

// Another type of loop is Do...While, this loop will always execute at least once, and then when the loop is completed, the condition is checked
// So when i=10 and the loop is executed, at the end of the loop, i=11

const contacts = [
  {
    firstName: "Akira",
    lastName: "Laine",
    number: "0543236543",
    likes: ["Pizza", "Coding", "Brownie Points"],
  },
  {
    firstName: "Harry",
    lastName: "Potter",
    number: "0994372684",
    likes: ["Hogwarts", "Magic", "Hagrid"],
  },
  {
    firstName: "Sherlock",
    lastName: "Holmes",
    number: "0487345643",
    likes: ["Intriguing Cases", "Violin"],
  },
  {
    firstName: "Kristian",
    lastName: "Vos",
    number: "unknown",
    likes: ["JavaScript", "Gaming", "Foxes"],
  },
];
function lookUpProfile(name, prop) {
for (let x = 0; x < contacts.length; x++) {
    if (contacts[x].firstName === name) {
      if (contacts[x].hasOwnProperty(prop)) {
        return contacts[x][prop];
      } else {
        return "No such property";
      }
    }
  }
  return "No such contact";
}

lookUpProfile("Akira", "likes");
// Code for searching in personal documents or something like that

function randomFraction() {
  var result = 0;
  while (result === 0) {
    result = Math.random();
  }
  return result;
}

randomFraction()
// Code for generating random numbers from 0 to 1, using the Math.random function
// We put a loop with a condition there so that the random number doesn't come out as 0

function randomWholeNum() {
  var result = 0;
  while(result===0){
    result = Math.floor(Math.random()*10)
  }
  return result;
}
// For better number generation, we use this code, which multiplies the random number and rounds it to a whole number
// This code generates random numbers from 1 to 9 (0 is not included because there is a condition that it should not be zero)
// Using Math.floor, we round numbers to whole numbers (without decimals)

function randomRange(myMin, myMax) {
  return Math.floor(Math.random() * (myMax - myMin + 1) + myMin);
}

randomRange(2, 9)
// Code for generating random numbers within a given range

function convertToInteger(str) {
  return parseInt(str)
  }
  
  convertToInteger("56");
// To convert a string to a number, we can use the parseInt() function, which converts the string to a number

function convertToInteger(str) {
  return parseInt(str, 2);
 }
 
 convertToInteger("10011");
// Converting a binary string to a regular base 10 number
// In the parseInt() function, the binary string is written first, and the second number, "2", indicates that it is a binary system
// We can use the same for base 16, we just need to change 2 to 16 and write a hexadecimal string

function findGreater(a, b) {
  if(a > b) {
    return "a is greater";
  }
  else {
    return "b is greater or equal";
  }
}
// This code can be shortened and rewritten as follows:
function findGreater(a, b) {
  return a > b ? "a is greater" : "b is greater or equal";
}
// The syntax is "a ? b : c", where "a" is the condition, "b" is the code that runs when the condition is true, and "c" is the code that runs when the condition is false
// In this code, "a" = "a>b", "b" = "a is greater", and "c" = "b is greater or equal"

function checkSign(num) {
return (num===0) ? "zero" : (num>=1) ? "positive" : "negative" ;
}

checkSign(10);
// Code for determining the sign of a number

/*
////////////////
//    ES6     //
////////////////


*/

function freezeObj() {
  const MATH_CONSTANTS = {
    PI: 3.14
  };
  // Only change code below this line
Object.freeze(MATH_CONSTANTS);

  // Only change code above this line
  try {
    MATH_CONSTANTS.PI = 99;
  } catch(ex) {
    console.log(ex);
  }
  return MATH_CONSTANTS.PI;
}
const PI = freezeObj();
// freeze.object works as protection against changing the value, especially in the const data type

const magic = () => {
  return new Date();
};
// To avoid having to name every function, we can use an anonymous function, which is written without a name, and after the parentheses, we write =>

doubler(...)
// The doubler function doubles the value or variable written in the parentheses

const myConcat = (arr1, arr2) => {
  return arr1.concat(arr2);
};

console.log(myConcat([1, 2], [3, 4, 5]));
// Function for joining two arrays
// To join, we use .concat(), so the output will be myConcat = [1,2,3,4,5]

const increment = (number, value=1) => number + value;
// The increment function adds a default value of 1 to the number if no value is provided

const sum = (...args) => {
  return args.reduce((a, b) => a + b, 0);
}
// The sum function uses the rest parameter syntax to accept multiple arguments and sums them up

const arr1 = ['JAN', 'FEB', 'MAR', 'APR', 'MAY'];
let arr2;
arr2 = [...arr1];
console.log(arr2);
// We can "duplicate" an array; of course, when not using "...arr" for the function, we need to change the brackets to square brackets
// arr2 will be identical to arr1

const user = { name: 'John Doe', age: 34 };
const name = user.name;
const age = user.age;
// Regular property extraction

const user = { name: 'John Doe', age: 34 };
const {name, age} = user;
// Shortened notation for extracting properties into variables
// If we write console.log(name) or (age), it will give us the property value, but if we write console.log(user), it will give us { name: 'John Doe', age: 34 }

const user = { name: 'John Doe', age: 34 };
const { name: userName, age: userAge } = user;
// If we need a different variable name, we can write it this way

const user = {
  johnDoe: { 
    age: 34,
    email: 'johnDoe@freeCodeCamp.com'
  }
};
const { johnDoe: { age: userAge, email: userEmail }} = user;
// If we want to navigate deeper, we do it the same way as always; the example is above

const [a, b] = [1, 2, 3, 4, 5, 6];
console.log(a, b);
// Using a single line, we can create multiple variables at once using an array
// This way, we don't have to write several lines, just one
// a=1 b=2

const [a, b,,, c] = [1, 2, 3, 4, 5, 6];
console.log(a, b, c);
// The value is determined by the order in the array, so a=1 b=2 and c=5

function removeFirstTwo(list) {
  const [a,b,...shorterList] = list;
  return shorterList;
}
const source = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
const sourceWithoutFirstTwo = removeFirstTwo(source);
// Code to remove the first two variables from an array using the previous example

const stats = {
  max: 56.78,
  standard_deviation: 4.34,
  median: 34.54,
  mode: 23.87,
  min: -0.75,
  average: 35.85
};
const half = (stats)=> (stats.max + stats.min) / 2.0; 
// The first way to get properties into a function is to write it like this (stats) => {} and this way we can use all the properties in the "stats" object in the function
// However, if we only need certain properties in the function, we write it as shown in the example below

const stats = {
  max: 56.78,
  standard_deviation: 4.34,
  median: 34.54,
  mode: 23.87,
  min: -0.75,
  average: 35.85
};
const half = ({max, min})=> (max + min) / 2.0; 
// This way, we import only 2 properties from the object into the function, not the entire object with all its functions
