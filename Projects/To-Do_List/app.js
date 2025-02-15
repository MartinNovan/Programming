function addTodo() {
    var inputElement = document.getElementById("input");
    var newTask = inputElement.value;
    if (newTask === '') {
        alert("You must enter something!");
    } else {
        var list = document.createElement("LI");
        var text = document.createTextNode(newTask);
        list.appendChild(text);

        var span = document.createElement("SPAN");
        var txt = document.createTextNode("\u00D7");
        span.className = "close";
        span.appendChild(txt);
        list.appendChild(span);

        document.getElementById("list").appendChild(list);
        inputElement.value = "";
    }
    span.onclick = function() {
        var div = this.parentElement;
        div.style.display = "none";
    }
}

var list = document.querySelector('ul');
list.addEventListener('click', function(ev) {
    if (ev.target.tagName === 'LI') {
        ev.target.classList.toggle('checked');
    }
}, false);

/*Negr */