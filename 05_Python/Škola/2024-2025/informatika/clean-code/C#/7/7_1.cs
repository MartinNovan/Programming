double CalculateAverage (double[] numbers){
double total=0;
for(int i=0;i<numbers.Length;i++){
total+=numbers[i];
}
double average=total/numbers.Length;
return average;}

double[] scores={80,90,100};
double avgScore=CalculateAverage(scores);
Console.WriteLine("Average Score: "+avgScore);
