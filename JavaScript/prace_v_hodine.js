let zadani1= new Array();
let zadani2= new Array();
let zadani3= new Array();
let zadani4= new Array();
let zadani5= new Array(new Array, new Array, new Array);

zadani5[0][0] = "tri"
zadani5[1][0] = "pet"
zadani5[2][0] = "tripet"

for(var i = 0; i<=15; i++){
    zadani1[i] = i;
}
console.log(zadani1);

let poc1 = 0;
for(var y = 12; y<=24; y++){
    zadani2[poc1] = y;
    poc1 ++;
}
console.log(zadani2);

let poc2 = 0;
for(var x = 7; x<=31; x++){
    if(x % 2 === 1){
        zadani3[poc2] = x;
        poc2 ++;
    }
}
console.log(zadani3);

let poc3 = 0;
for(var s = 10; s>= -20; s--){
    if(s % 2 === 0){
        zadani4[poc3] = s;
        poc3 ++;
    }
}
console.log(zadani4);

let poc4 = 1;
let poc5 = 1;
let poc6 = 1;
for(var tp = 1; tp <=45; tp++){
    if(tp % 3 === 0){
        zadani5[0][poc4] = tp;
        poc4 ++;
    } 
    if(tp % 5 === 0){
        zadani5[1][poc5] = tp;
        poc5 ++;
    }
    if(tp % 3 === 0 && tp % 5 === 0){
        zadani5[2][poc6] = tp;
        poc6 ++;
    }
}
console.log(zadani5);