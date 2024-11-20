let task1 = new Array();
let task2 = new Array();
let task3 = new Array();
let task4 = new Array();
let task5 = new Array(new Array, new Array, new Array);

task5[0][0] = "three";
task5[1][0] = "five";
task5[2][0] = "threefive";

for (var i = 0; i <= 15; i++) {
    task1[i] = i;
}
console.log(task1);

let count1 = 0;
for (var y = 12; y <= 24; y++) {
    task2[count1] = y;
    count1++;
}
console.log(task2);

let count2 = 0;
for (var x = 7; x <= 31; x++) {
    if (x % 2 === 1) {
        task3[count2] = x;
        count2++;
    }
}
console.log(task3);

let count3 = 0;
for (var s = 10; s >= -20; s--) {
    if (s % 2 === 0) {
        task4[count3] = s;
        count3++;
    }
}
console.log(task4);

let count4 = 1;
let count5 = 1;
let count6 = 1;
for (var tp = 1; tp <= 45; tp++) {
    if (tp % 3 === 0) {
        task5[0][count4] = tp;
        count4++;
    }
    if (tp % 5 === 0) {
        task5[1][count5] = tp;
        count5++;
    }
    if (tp % 3 === 0 && tp % 5 === 0) {
        task5[2][count6] = tp;
        count6++;
    }
}
console.log(task5);