// <== dvoje lomítka znamenají jednořádkový kmentář
/* <== toto je víceřádkový komentář
musí se uzavřít */

var JménoProměnné;
// var= varriable, musí se uzavřít ==> ;

JménoProměnné = 2 ;
// Proměnou nastavujeme a měníme pomocí = a uzavíráme ==> ;

var JménoProměnné = 0;
// Proměnou můžeme definovat hned jak ji vytvoříme stačí pouze spojit předchozí dva příklady a uzavřít ==> ;

var JménoProměnné = "písmena";
//do porměnné můžeme psát ale musíme přidat "..." místo teček můžeme psát písmena a uzavřeme ==> ;

let JménoProměnné = ... ;
// funkce "let" umožňuje definovat proměnnou pouze jednou a poté již nejde přepsat 

const JménoProměnné = ... ;
// funkce "const" funguje podobně jako "let" s jediným rozdílem že "const" je read-only uzavírá se ==> ;

JménoProměnné ++ ;
// použitím proměné a "++" znamená že k proměnné přidáme 1 je to kratší zapis pro "JménoProměnné = JménoProměnné + 1" (nepíše se = )
// stejné se dá použít i pro -1 s jedinou změnou že místo ++ napíšeme --

JménoProměnné = 5 % 2 ;
// značka % se používá pokud chceme aby proměnná měla číslo stejné velikosti zbytku tím pádem 2 / 5 = 2 zb. 1 takže proměnná bude mít hodnotu 1

JménoProměnné += 5 ;
//zkrácený zápis pro "JménoProměnné = JménoProměnné + 5" stjené funguje pro mínus a ostatní znaky pro matiku

JménoProměnné = "Nějáký Text \"Nějáký Text\" Nějáký text" ;
// použitím \" ... \" ve stringu docílíme uvozovek v textu

JménoProměnné = 'Nějáký text "nějáký text" ' ;
// v Javascriptu můžeme pro string používat dva typy uvozovek "..." a nebo '...' důvod je takový že pokud použijeme "..." nemůžeme použít
// "..." pro uvozovky v textu a museli bychom použít \"...\" zase můžeme v textu použít '...' 
// to samé i naopak pokud použíjeme '...' můžeme v textu použít "..." bez lomítka ale nemůžeme použít '...'
const myStr = '<a href="http://www.example.com" target="_blank">Link</a>';
// na tomto příkladu si můžeme ukázat že v propojení s HTML používáme "..." ve stringu a proto nazačátek použijeme '...'

/*
\'	single quote        (Pro zapsání '...' ve stringu)
\"	double quote        (Pro zapsání "..." ve stringu)
\\	backslash           (Pro zapsání \...\ ve stringu)
\n	newline             (Pro zapsání nového řádku ve stringu)
\t	tab                 (Pro zapsání Tabu ve stringu)
\r	carriage return     (Je to řídicí znak v textových souborech označující konec řádku. Používal se ze starých psacích strojů a tiskáren, kde se vozík s papírem musel na konci řádku vrátit do výchozí polohy.)
\b	word boundary       (https://javascript.info/regexp-boundary)
\f	form feed           (Na tiskárnách načtěte další stránku. V některých emulátorech terminálů vyčistí obrazovku.)
Tady jsou některé zkratky pro upravování textu ve stringu.
*/

JménoProměnné = "Nějáký Text" + "Nějáký text" ;
// použitím + ve stringu docílíme spojením dvou textů do jednoho

const JménoProměnné = "Nějáký text" ;
JménoProměnné += "Nějáký další text" ;
// zápis můžeme spojovat i tímto způsobem

const myName = "Martin";
const myStr = "My name is" +myName+ "and I am well!";
// Do stringu můžeme přidávat i proměnné použitím +JménoProměnné+ mezi texty

const someAdjective = "pain in the ass.";
let myStr = "Learning to code is ";
myStr += someAdjective
// stringy můžeme spojovat i jako proměnné

let lastNameLength = 0;
const lastName = "Lovelace";
lastNameLength = lastName.length;
// pomocí .length můžeme spočítat kolik písmen je zapsáno ve stringu, použijeme je tak že napíšeme JménoProměnné.length jako je ukázáno výše

let firstLetterOfLastName = "";
const lastName = "Lovelace";
firstLetterOfLastName = lastName[0];
// Pro zjištení určitého písmene či čísla zjistíme pomocí toho kolikáté číslo to je zapíšeme to pomocí JménoProměnné[počet vzdálenosti]
// UPOZORNĚNÍ JAVASCRIPT POČÍTÁ OD 0 !!!

const lastName = "Lovelace";
const lastLetterOfLastName = lastName[lastName.length-1];
//poslední písmeno můžeme zjistit i tak, že dáme počet všech pímen a dáme -1

const myArray = ["nějáký text" , 38 , "nějáký další text"];
// pomocí Array můžeme ukládat více dat do jedné proměnné stylem JménoPorměnné = ["...", ...] můžeme zde ukládat více typů např. string či čísla

const myArray = [["Team Modry", 39], ["Team cerveni", 40]];
// můžeme taky ukládat více array v jednom array

const myArray = [50, 60, 70];
console.log([myArray[0]]);
const myData = myArray[1];
//Data z Array se berou podle pozice v řetězci proto 50=0, 60=1, 70=2 proto console vypíše číslo 50 a v myData je uloženo číslo 60

const myArray = [18, 64, 99];
myArray[0] = 45;
//V array můžeme měnit data pomocí JménoProměnné[místo v řetězci] = ...

const arr = [
    [1, 2, 3],
    [4, 5, 6],
    [7, 8, 9],
    [[10, 11, 12], 13, 14]
  ];
  
  const subarray = arr[3];           // [[10, 11, 12], 13, 14]
  const nestedSubarray = arr[3][0];  // [10, 11, 12]
  const element = arr[3][0][1];      // 11
// Při Array které se skládá z více Array se přistupuje postupně a počítá se pokáždé od 0 píšeme Array vedle Array a vybíráme pozici kterou potřebujeme

const myArray = [["John", 23], ["cat", 2]];
myArray.push(["dog", 3]);
// pomocí funkce .push můžeme přidat další data do array, zapíšeme to způsobem JménoProměnné.push("data")
// PŘIDÁVÁME VŽDYCKY NAKONEC

const myArray = [["John", 23], ["cat", 2]];
const removedFromMyArray = myArray.pop(["John", 23]);
// pomocí funkce .pop můžeme z array vyndat data a přesunot je někam jinam či odstranit zapíšeme JménoProměnné.pop("data")
// POKUD NESPECIFIKUJEME DO ZÁVORKY ODSTRANÍ VŽDY POSLEDNÍ DATA

const myArray = [["John", 23], ["dog", 3]];
const removedFromMyArray = myArray.shift();
//Funguje stejně jako funkce .pop ale místo poslední vezme první 

const myArray = [["John", 23], ["dog", 3]];
myArray.shift()
myArray.unshift(["Paul", 35])
//funkce .unshift funguje stejně jako .push akorát že místo toho aby to zapsalo poslední tak to zapíše první

function reusableFunction(){
    console.log("Hello World");
  }
  reusableFunction()
// Do funkce píšeme kód který můžeme vyvolat napsáním názvu funkce

function functionWithArgs(param1,param2){
    console.log(param1+param2)
  }

  functionWithArgs(1,2) //3
  functionWithArgs(7,9) //16
// pomocí funkcí si múžeme vytvořit předem daný postup a pak můžeme použít funkci s danými daty
// funkce nahoře má definované parametry (param1 a param2) které nám slouží jako proměnná a můžeme je ve funkci používat
// funkce(sem se píší proměnné které potřebujeme vyvolat) <== tyto můžeme zde vytvořit a pak je nahradit či si je vzít z programu

function timesFive(num){
    console.log(num*5)
  }
  
  timesFive(5)
  timesFive(2)
  timesFive(0)
// Další příklad pro funkce

function timesFive(num) {
    return num * 5;
  }
  const answer = timesFive(5);
/*
Tento kód definuje funkci s názvem timesFive, která přijímá jeden parametr num a násobí jej číslem 5. Poté volá tuto funkci 
s argumentem 5 a výsledek přiřazuje proměnné s názvem answer. Když je funkce timesFive zavolána s argumentem 5, vynásobí 5 pěti 
a vrátí výsledek, který je 25. Tuto hodnotu pak přiřadí proměnné answer. Výsledná hodnota proměnné answer tedy bude 25.
*/

const JménoPorměnné = 5 ;
function somefunction(JménoPorměnné){
JménoPorměnné = ... ;
}
// Pokud píšeme proměnnou mimo funkci stává se z proměnné tkzv. GLOBAL proměnná to znamená že proměnná je dostupná všude v kódu

function somefunction(){
  const JménoPorměnné = 5 ;
}
// Pokud ale napíšeme proměnnou do funkce tak se z ní stáva tkzv. LOCAL proměnná a to znamená že se dá použít jen v té dané funkci

function vynasob(a, b) {
  return a * b;
}
let vysledek = vynasob(3, 4); // vysledek je nyní 12
//příkaz return se používá k ukončení provádění funkce a volitelnému vrácení hodnoty volajícímu
//Když je funkce zavolána s argumenty 3 a 4, vrátí hodnotu 12, která je pak přiřazena do proměnné vysledek.
//Je důležité poznamenat, že pokud příkaz return není uveden v funkci, funkce stále vrátí hodnotu undefined volajícímu.

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

//Příklad kódu pro přídávání čísel s následním ubráním prvního čísla v řetězci

function testEqual(val) {
  if (val == 12) {
    return "Equal";
  }
  return "Not Equal";
}
testEqual(10);
// Použitím "==" získáme operátor rovnosti který používáme při porovnání dvou hodnot
// u tohoto typu operátoru nezáleží jestli je číslo ve stringu či ne viz. příklad níže
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
//operátor "===" funguje stějně jako "==" akorát že tento operátor je tkzv. striktní
// to znamená že tento operátor už rozlišuje string a hodnotu viz. příklad
/*
3 ===  3  // true
3 === '3' // false
*/

function testNotEqual(val) {
  if (val != 99) { 
    return "Not Equal";
  }
  return "Equal";
}
testNotEqual(10);
//operátor "!=" značí nerovnost funguje stejně jako == ale je to opačně

function testStrictNotEqual(val) {
  if (val !==17) {
    return "Not Equal";
  }
  return "Equal";
}
testStrictNotEqual(10);
// to samé plaí pro "!==" funguje stejně jako operátor === ale opačně

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
// operátory "<" ">" či jinak větší a měnší porovnávají dvě hodnoty

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
// dále tu máme samozřejmě "<=" ">=" či jinak menší a rovno, vetší a rovno 

function testLogicalAnd(val) {
  if (val > 24 && val < 51) {
    return "Yes";
  }
return "No";
}
testLogicalAnd(10);
// pokud potřebujeme dvě porovnání můžeme to sloučit do jedné pomcí "&&" funguje jako spojka "a zároveň" a platí pouze když jsou oba výroky pravdivé či nepravdivé (ekvivalence)

function testLogicalOr(val) {
  if (val<10 || val>20) {
    return "No";
  }
  return "Yes";
}
testLogicalOr(15);
// operátor "||" fungují jako "mezi" tady máme znázorněno že čísla od 10 do 20 jsou "Ano" včetně 10 a 20
//Logický operátor nebo "||" vrací hodnotu true, pokud jsou oba z operandů true. V jiném případě vrací false (konjunkce)

function testLogicalOr(val) {
  if (val>10 || val<20) {
    return "Yes";
  }
  return "No";
}
testLogicalOr(15);
//Pokud ale prohodíme "<" a ">" a prohodíme výstupi tak se nám z konjunkce stane disjunkce
//Logický operátor nebo "||" vrací hodnotu true, pokud je některý z operandů true. V opačném případě vrací false (disjunkce)

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
// Pokud potřebujeme použít vícekrát if použijeme "else" popřípadě "else if"

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
// Tady máme udělán program pro kontrolu velikosti

function caseInSwitch(val) {
  let answer = "";
 switch(val) {
  case 1:
    answer = "alpha" ; 
    break;
  case 2:
    answer = "beta" ; 
    break;
  case 3:
    answer = "gamma" ; 
    break;
  case 4:
    answer = "delta" ;
    break;
 }
  return answer;
}
caseInSwitch(1);
//pokud máme na výběr více možnistí tak místo opakování "if" a "else if" můžemem použít funkci "switch"
// funkce "switch" funguje s funkcí "case" a "break" kdy switch si můžeme přeložit (když), case (případ/když) a break (konec)
// pokud funkci "case" neuzavřeme "break" tak se funkce "case" bude stále probíhat dokud nenarazí na break

function switchOfStuff(val) {
  let answer = "";
  switch (val){
    case "a":
      answer = "apple"
      break;
    case "b":
      answer = "bird"
      break;
    case "c":
      answer = "cat"
      break;
    default:
      answer = "stuff"
  }
  return answer;
}
switchOfStuff(1);
//funkce "default" se používá v případě že ani jedna z case není pravdivá/provedená
//provedena bude vždy když se žádná z case neprovede

function sequentialSizes(val) {
  let answer = "";
  switch(val){
    case 1 :
    case 2 :
    case 3 :
      answer = "Low"
      break;
    case 4 :
    case 5 :
    case 6 : 
      answer = "Mid"
      break;
    case 7 :
    case 8 :
    case 9 :
      answer = "High"
      break;
  }
  return answer;
}
sequentialSizes(1);
// pokud funkci "case" neuzavřeme "break" tak se funkce "case" bude stále probíhat dokud nenarazí na break
// tady máme příklad který nám ukazeje že hodnoty 1-3 nam dají "Low" 4-6 nám dají "Mid" a 7-9 "High"

//pomocí funkce switch můžeme nahradit if níže příklad
function chainToSwitch(val) {
  let answer = "";
  if (val === "bob") {
    answer = "Marley";
  } else if (val === 42) {
    answer = "The Answer";
  } else if (val === 1) {
    answer = "There is no #1";
  } else if (val === 99) {
    answer = "Missed me by this much!";
  } else if (val === 7) {
    answer = "Ate Nine";
  }
  return answer;
}
chainToSwitch(7);

//používá se aby byl zápis úhlednější

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
// tímto způsobem se dá v kódu lépe orientovat a číst

function isEqual(a, b) {
  if (a === b) {
    return true;
  } else {
    return false;
  }
}
//Boolean (či true/false) jsme byli zvyklí psát tímto způsobem
//je tu ale jeden kratší a rychlehší způsob

function isEqual(a, b) {
  return a === b;
}
//tímto způsobem můžeme také zapsat boolean a je to mmnohem rychlejší
//funkce nám dá hodnotu buďto true či false

function abTest(a, b) {

  if(a<0||b<0){
return undefined
}

  return Math.round(Math.pow(Math.sqrt(a) + Math.sqrt(b), 2));
}
abTest(2,2);
// kód pro kontrolu jestli ani jedno z čísel není 0 či níž
// "undefined" není hodnota ale keyword

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
// Kód pro počítání karet

const cat = {
  "name": "Whiskers",
  "legs": 4,
  "tails": 1,
  "enemies": ["Water", "Dogs"]
};
//Objekty jsou podobné array, ale místo indexů se k datům v nich přistupuje pomocí tzv. vlastností.
//Objekty jsou užitečné pro strukturované ukládání dat a mohou reprezentovat objekty reálného světa, například kočku.
//V tomto příkladu jsou všechny vlastnosti uloženy jako řetězce, například jméno, nohy a ocasy. Jako vlastnosti však můžete použít i čísla. 
//U jednoslovných řetězcových vlastností můžete dokonce vynechat uvozovky, a to následujícím způsobem:
const anotherObject = {
  make: "Ford",
  5: "five",
  "model": "focus"
};
//Pokud však váš objekt obsahuje jiné než řetězcové vlastnosti, JavaScript je automaticky přepíše na řetězce.

const testObj = {
  "hat": "ballcap",
  "shirt": "jersey",
  "shoes": "cleats"
};
const hatValue = testObj.hat;
const shirtValue = testObj.shirt;
//Objekty vyvoláváme pomocí "Proměnné"."název objektu" jinak napsáno o řádek výše

const myObj = {
  "Space Name": "Kirk",
  "More Space": "Spock",
  "NoSpace": "USS Enterprise"
};

myObj["Space Name"];
myObj['More Space'];
myObj["NoSpace"];
//Druhým způsobem přístupu k vlastnostem objektu je zápis v závorkách ([]). 
//Pokud má vlastnost objektu, ke které se snažíte přistupovat, ve svém názvu mezeru, musíte použít zápis v závorkách.

const myDog = {
  "name": "Coder",
  "legs": 4,
  "tails": 1,
  "friends": ["freeCodeCamp Campers"]
};
myDog["name"] = "Happy Coder"; 
//vlastnost měníme stejně jako obyčejná proměnnou

myDog.bark = "bow-wow";
//nebo
myDog["bark"] = "bow-bow";
//těmito způdoby můžeme přidávat nové vlastnosti objektu

delete myDog.bark;
//nebo
delete myDog["bark"]
//můžeme vymazat vlastnosti objektu


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
//zápis pro dohledání hodnot pomocí jiné proměnné

const myObj = {
  top: "hat",
  bottom: "pants"
};

myObj.hasOwnProperty("top");
myObj.hasOwnProperty("middle");
//pokud potřebujeme zjistit zda proměná obsahje vlastnost kterou potřebujeme můžeme použít funkci .hasOwnPropety()
//na tomto příkladu můžeme vidět že první řádek nám dá odpověď TRUE ale druhý už dá FALSE

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
//pokud píšeme vlastnosti do vlastností přistupujeme do nich postupně viz. řádek výše

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
//Jak jsme viděli v předchozích příkladech, objekty mohou obsahovat jak vnořené objekty, tak vnořená array. 
//Podobně jako při přístupu k vnořeným objektům lze k přístupu k vnořeným polím(array) použít řetězový zápis závorek pro pole(array).
//secondTree = "pine"

const myArray = [];
let i = 5;
while(i>= 0){
  myArray.push(i);
  i--;
}
//První typ cyklu, se nazývá cyklus while, protože běží, dokud platí zadaná podmínka, a zastaví se, když podmínka přestane platit.
//Kód přidá čísla 5 až 0 (včetně) v sestupném pořadí do pole myArray pomocí cyklu while.

const myArray = [];
for (var i = 1; i < 6; i++) {
  myArray.push(i);
}
//Nejběžnější typ smyčky jazyka JavaScript se nazývá smyčka for, protože se spouští určitý cyklus kolikrát potřebujeme.
//Smyčky For se deklarují třemi nepovinnými výrazy oddělenými středníky:
//for (a; b; c), kde a je inicializační příkaz, b je příkaz podmínky a c je konečný výraz.
//Inicializační příkaz se provede pouze jednou před spuštěním smyčky. Obvykle se používá k definování a nastavení proměnné smyčky.
//Příkaz podmínky je vyhodnocen na začátku každé iterace cyklu a bude pokračovat, dokud bude vyhodnocen jako true. 
//Pokud je podmínka na začátku iterace nepravdivá, smyčka se přestane provádět. 
//To znamená, že pokud podmínka začne jako false, smyčka se nikdy nevykoná.
//V předchozím příkladu inicializujeme i = 1 a iterujeme, dokud je naše podmínka i < 6 pravdivá. V každé iteraci cyklu zvýšíme i o 1, přičemž i++ je náš konečný výraz.

const myArray = [];
for (let i = 1; i < 10; i += 2) {
  myArray.push(i);
}
//kód pro vypsání lichých čísel do 10

const myArr = [2, 3, 4, 5, 6];
let total = 0
for (let i = 0; i < myArr.length; i++) {
   total += myArr[i];
}
// kód pro sečtení hodnot v Array

function multiplyAll(arr) {
  let product = 1;

  for (let i = 0; i < arr.length; i++) {

    for (let j = 0; j < arr[i].length; j++) {
      product *= arr[i][j] 
  }
}
  return product;
}

multiplyAll([[1, 2], [3, 4], [5, 6, 7]]);
//kód pro vynásobení všech hodnot mezi s sebou a dále vydání výsledku

const myArray = [];
let i = 10;
do{
myArray.push(i);
  i++
} while (i < 5)
//další typ cyklu je Do...While, tento cyklus se vždy provede aspoň jednou a poté když je cyklus dokončen se teprve zkontroluje podmínka
// takže když i=10 a cyklus se provede tím pádem na konci cyklu je i=11

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
//kód pro hledání v osobních dokumentech či něco takového

function randomFraction() {
  var result = 0;
  while (result === 0) {
    result = Math.random();
  }
  return result;
}

randomFraction()
//kód pro generování random čísel od 0 do 1, používáním funkce Math.random
//loop s podmínkou tam dáváme proto, aby náhodné číslo nevyšlo 0


function randomWholeNum() {
  var result = 0;
  while(result===0){
    result = Math.floor(Math.random()*10)
  }
  return result;
}
//pro lepší účel generování čísel použijeme tento kód, který nám náhodné číslo vynásobí a zaokrouhlí na celé číslo
//tento kód generuje náhodná čísla od 1 do 9 (0 není započítána protože tam je podmínka aby to nula nebyla)
// pomocí Math.floor zaokrouhlujeme čísla na celé číslo (bez desetin)

function randomRange(myMin, myMax) {
  return Math.floor(Math.random() * (myMax - myMin + 1) + myMin);
}

randomRange(2, 9)
// kód pro generování random čísel v daném rozsahu

function convertToInteger(str) {
  return parseInt(str)
  }
  
  convertToInteger("56");
// převádění stringu na čísla můžeme použít funkci parseInt() které nám string převede na číslo

function convertToInteger(str) {
  return parseInt(str, 2);
 }
 
 convertToInteger("10011");
//převádění binárního řetězce do obyčejné 10 soustavy
//ve funkci parseInt() je napsán jako první binární řetězec a druhé číslo tedy "2" říká že je to binární soustava
// to samé můžeme použít pro 16 soustavu, jediné co potřebujeme změnit je 2 na 16 a napsat hexidecimální řetězec

function findGreater(a, b) {
  if(a > b) {
    return "a is greater";
  }
  else {
    return "b is greater or equal";
  }
}
//tento kód můžeme zkrátit a přepsat takto:
function findGreater(a, b) {
  return a > b ? "a is greater" : "b is greater or equal";
}
//Syntaxe je "a ? b : c", kde "a" je podmínka, "b" je kód který běží když podmínka je true, a "c" je kód který běží když podmínka je false
// v tomto kódu je "a" = "a>b", "b" = "a is greater" a "c" = "b is greater or equal" 

function checkSign(num) {
return (num===0) ? "zero" : (num>=1) ? "positive" : "negative" ;
}

checkSign(10);
//kód pro určení čísla

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
//freeze.object funguje jako protekce proti změnění hodnoty hlavmě v datovém typu const

const magic = () => {
  return new Date();
};
// pro to aby jsme každou funkci nemuseli nějak pojmenovávat můžeme použít anonymní funkci která se zapisuje beze jména a po závorkách píšeme =>¨

doubler(...)
//funkce doubler nám udělá to že nám zdvojnásobí hodnotu či proměnnou která je zapsána v závorce

const myConcat = (arr1, arr2) => {
  return arr1.concat(arr2);
};

console.log(myConcat([1, 2], [3, 4, 5]));
//funkce pro spojetí dvou polí
// pro spojení použijeme .concat() takže output bude myConcat = [1,2,3,4,5]

const increment = (number, value=1) => number + value;
// pro proměnné můžeme nastavovat základní parametry např value=1 což znamená, že pokud nespecifikujeme value bude ji automaticky přiřazena hodnota 1
// také si můžeme všimnout že jsme sem nepoužili závorky {} to ale nevadí, pokud ale píšeme závorky musíme psát funkci return aby nám funkce vrátila hodnotu
// takto bez závorek nám to vrátí automaticky hodnotu, toto je vhodné pro jednoduché výpočty pro čitelný zápis  

const product = (n1, n2, n3) => {
  const args = [n1, n2, n3];
  let total = 0;
  for (let i = 0; i < args.length; i++) {
    total += args[i];
  }
  return total;
}
console.log(product(2, 4, 6)); //12
//toto je jednoduché sčítání 3 čísel pommocí loopu for
//vlastně funguje tak že si do array dáme jednotlivé čísla (n1, n2, n3) a funkce args.lenght nám říká kolik máme v array proměnných
//funkce v loopu vlastně říká opakuj dokud nebude i mít stejnou hodnotu jako args.length 
//total vlastně funguje tak že si z array vezme číslo na které je nastavené i a přičte ho do total
//loop se oakuje dokud i nebude stejně velké jako délka array
//loop se neprovede jestli že bde podmínka false

const sum = (...args) => {
  let total = 0;
  for (let i = 0; i < args.length; i++) {
    total += args[i];
  }
  return total;
}
console.log(sum(2, 4, 6, 9)); //21
// toto je druhý možný zápis pro předchozí zadání
//místo toho aby jsme byli omezeni na počet čísle múžeme použít "rest parametr" který nám proměnný ukládá do array
//je to to stejné jak const args = [n1, n2, n3]; ale s tím rozdílem že nám to ukládá rovnou do array a nemáme omezení na psaní proměnných do funkce
//také je to kratší a přehlednější
//kód jinak funguje stejně

var arr = [6, 89, 3, 45];
var maximus = Math.max.apply(null, arr);
//kdysi se v javasriptu muselo používat toto, protože bez null či .apply by nám to nefungovalo a hodilo by nám to chybu
//avšak v moderním javascriptu se používá spread operator který nám umožňuje rozložit array do jednotlivých argumentů

const arr = [6, 89, 3, 45];
const maximus = Math.max(...arr);
console.log(maximus);
//prakticky nám to přepíše array do jednotlivých argumentů a díky tomu nemusíme nějak obcházet tuto záležitost

const arr1 = ['JAN', 'FEB', 'MAR', 'APR', 'MAY'];
let arr2;
arr2 = [...arr1];
console.log(arr2);
//array můžeme "duplikovat" samozřejmně když nepoužíváme "...arr" k funkci musíme změnit závorky na hranaté 
//arr2 bude identická s arr1


const user = { name: 'John Doe', age: 34 };
const name = user.name;
const age = user.age;
//obyčejný výpis vlastnostní 

const user = { name: 'John Doe', age: 34 };
const {name, age} = user;
//zkrácený zápis pro výpis vlastnostní do proměnných
//pokud napíšeme console.log(name) nebo (age) dá nám to hodnotu vlastnosti pokud bychom ale napsali console.log(user) dalo by nám to { name: 'John Doe', age: 34 }

const user = { name: 'John Doe', age: 34 };
const { name: userName, age: userAge } = user;
//pokud potřebujeme jiný název proměnné můžeme to zapsat tímto stylem

const user = {
  johnDoe: { 
    age: 34,
    email: 'johnDoe@freeCodeCamp.com'
  }
};
const { johnDoe: { age: userAge, email: userEmail }} = user;
//pokud chceme hlouběji navigovat uděláme to stejně jako vždy výše je příklad

const [a, b] = [1, 2, 3, 4, 5, 6];
console.log(a, b);
//pomocí jednoho řádku dokážeme vytvořit více proměnných najednou s použitím array
//díky tomu nemusíme vypisovat několik řádku ale stačí jeden
// a=1 b=2

const [a, b,,, c] = [1, 2, 3, 4, 5, 6];
console.log(a, b, c);
//určení hodnoty se určuje podle pořadí v array proto se a=1 b=2 a c=5

function removeFirstTwo(list) {
  const [a,b,...shorterList] = list;
  return shorterList;
}
const source = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
const sourceWithoutFirstTwo = removeFirstTwo(source);
//kód pro vyndání prvních dvou proměných z array pomocí předchozí ukázky

const stats = {
  max: 56.78,
  standard_deviation: 4.34,
  median: 34.54,
  mode: 23.87,
  min: -0.75,
  average: 35.85
};
const half = (stats)=> (stats.max + stats.min) / 2.0; 
//1. možnost jak do funkce dostat vlastnosti můžeme zapsat takto (stats) => {} a tím dosáhneme že všechny vlastnosti v objektu "stats" budeme moct použít ve funkci
//pokud ale potřebujeme pouze určité vlastnosti ve funkci zapíšeme to níže uvedeným příkladem 

const stats = {
  max: 56.78,
  standard_deviation: 4.34,
  median: 34.54,
  mode: 23.87,
  min: -0.75,
  average: 35.85
};
const half = ({max, min})=> (max + min) / 2.0; 
// tímto docílíme že do funkce importujeme pouze 2 vlastnosti z objektu a ne celý objekt se všemi funkcemi 
