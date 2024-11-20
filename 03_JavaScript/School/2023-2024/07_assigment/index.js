let tableCreated = false;
function createTable() {
    const numberOfRows = document.getElementById("rows").value;
    const numberOfColumns = document.getElementById("columns").value;

    if (tableCreated) {
        const existingTable = document.getElementById("myTable");
        if (existingTable) {
            existingTable.remove();
        }
    }
    const table = document.createElement("table");
    table.id = "myTable";
    for (let i = 1; i <= numberOfRows; i++) {
        const row = table.insertRow();
        for (let j = 1; j <= numberOfColumns; j++) {
            const cell = row.insertCell();
            cell.textContent = (i - 1) * numberOfColumns + j;
        }
    }
    document.body.appendChild(table);
    tableCreated = true;
}
