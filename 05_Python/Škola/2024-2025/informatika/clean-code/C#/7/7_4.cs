double Divide(double a,double b){
if(b!=0){
return a/b;}else{
Console.WriteLine("Division by zero.");
return 0;
}
}

double result=Divide(10,2);
Console.WriteLine("Result:"+result);
