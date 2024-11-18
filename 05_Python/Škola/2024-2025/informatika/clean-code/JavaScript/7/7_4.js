function divide(a,b){
  if(b!==0){
  return a/b;}else{
  console.error("Division by zero.");
  return null;
  }
  }
  
  let result=divide(10,2);
  console.log("Result:"+result);
  