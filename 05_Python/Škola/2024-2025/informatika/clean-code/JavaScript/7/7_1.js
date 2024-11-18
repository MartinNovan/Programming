function calculateAverage (numbers){
  let total=0;
  for(let i=0;i<numbers.length;i++){
  total+=numbers[i];
  }
  let average=total/numbers.length;
  return average;}
  
  let scores=[80,90,100];
  let avgScore=calculateAverage(scores);
  console.log("Average Score: "+avgScore);
  