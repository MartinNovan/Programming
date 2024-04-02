let arr = new Array(300);

for(var i = 0; i < arr.length; i++){
arr[i] = Math.floor(Math.random() * 300);
}

let prumer = (arr) => {
var sum = 0;
    for(var y = 0; y < arr.length; y++) {
    sum += arr[y];
}
return sum/arr.length;
}
//console.log(arr)
console.log(prumer(arr));