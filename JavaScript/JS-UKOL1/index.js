let tableCreated = false;
function vytvoritTabulku() {
    const pocetRadku = document.getElementById("radky").value;
    const pocetSloupcu = document.getElementById("sloupce").value;

    if (tableCreated) {
        const existingTable = document.getElementById("myTable");
        if (existingTable) {
            existingTable.remove();
        }
    }
    const table = document.createElement("table");
    table.id = "myTable";
    for (let i = 1; i <= pocetRadku; i++) {
        const row = table.insertRow();
        for (let j = 1; j <= pocetSloupcu; j++) {
            const cell = row.insertCell();
            cell.textContent = (i - 1) * pocetSloupcu + j;
        }
    }
    document.body.appendChild(table);
    tableCreated = true;
}
