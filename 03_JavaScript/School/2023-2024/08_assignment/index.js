document.addEventListener("DOMContentLoaded", function () {
    var canvas = document.getElementById("canvas");
    var context = canvas.getContext("2d");
    var circleCenterX = 100;
    var circleCenterY = 100;
    canvas.onmousemove = function (event) {
        circleCenterX = event.clientX;
        circleCenterY = event.clientY;
    };
    function draw() {
        context.clearRect(0, 0, canvas.width, canvas.height);
        context.fillStyle = "blue";
        context.beginPath();
        context.arc(circleCenterX, circleCenterY, 50, 0, 2 * Math.PI);
        context.fill();
        context.fillStyle = "green";
        context.fillRect(100, 100, 100, 100);
        requestAnimationFrame(draw);
    }
    draw();
});
