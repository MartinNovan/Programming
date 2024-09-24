let supon = 0; //proměná pro uchování stavu zda je mocnina stisknuta
let alreadysupon = 0; //proměnná pro zjištění či se již píše do mocniny
const inputfield = document.querySelector(".inputfield");
const outputfield = document.querySelector(".outputfield");
//funkce pro zapsání do vstupního pole pomocí tlačítek 
function toinput(indx) {
    if (indx === "C") {
        inputfield.value = ""; //vynuluj input
        outputfield.value = ""; //vynuluj output
        supon = 0; //vynuluj pomocnou proměnnou
        alreadysupon = 0; //vynuluj další pomocnou proměnnou
    } else if (indx === "DEL") {
        inputfield.value = inputfield.value.slice(0, -1); //smazání posledního charakteru ve stupním řádku
    } else if (indx === "=") {
        if (inputfield.value === "") {
            alert("You must write something!"); //pokud se zmáčkne tlačítko "=" a vstupní řádek je prádný vyhodí to chybu
        } else{
            calculate(); //pokud je řádek v pořádku spustí se funkce vypočítej
        }
    //zde se řeší zápisy pomocí závorek a znaménka "^"
    } else if (indx === "SIN" || indx === "COS" || indx === "TAN" || indx === "√x") {
        if (indx === "√x") {
            inputfield.value += "√(";
        } else {
            inputfield.value += indx + "(";
        }
    } else if (indx === "10ˣ" || indx === "x²" || indx === "xʸ") {
        if (indx === "x²") {
            inputfield.value += "²"; //pro druhou mocninu používáme mocninový zápis
            //pro ostatní řešíme pomocí zápisu x^(y), konec závorky se musí vždy napsat ručně stisknutím znova stejného talčítka
        } else if (indx === "10ˣ" || indx === "xʸ") {
            if (indx === "10ˣ") {
                if (supon === 1) {
                    supon = 0;
                    alreadysupon = 0;
                    inputfield.value += ")"; 
                } else {
                    supon = 1;
                    inputfield.value += "10" + "^" + "(";
                }
                //zapsání "^(" nebo ")" podle toho zda je mocnina rozepsaná nebo se začíná nová --- toto se bude muset upravit a trošičku předělat
            }else{
                if (supon === 1) {
                    supon = 0;
                    alreadysupon = 0;
                    inputfield.value += ")"; 
                } else {
                    supon = 1;
                    inputfield.value += "^" + "(";
                }
            }
        }
    } else {
        if (supon === 1) {
            if (alreadysupon === 0) {
                inputfield.value += indx;
                alreadysupon = 1;
            } else {
                inputfield.value += indx;
            }
        } else {
            inputfield.value += indx;
        }
    }
}

function calculate() {
    try {
        const expression = inputfield.value.replace(/×/g, '*').replace(/\^/g, '**').replace(/²/g, '**2').replace(/π/g, Math.PI); //zaměnit některé znaky za ty které použijeme ve výpočtu
        const result = eval(expression); //výpočet pomocí funkce eval
        outputfield.value = result; //vypsání výsledku
    } catch (error) {
        outputfield.value = "Error"; //pokud se zde bude nacházet chyba vypíše se do výstupního pole error
        console.error(error); //error se také vypíše do konzole
    }
}
