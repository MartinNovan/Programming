function analyzeData(data) {
  if (data && data.length > 0) {
      let total = 0;
      for (let i = 0; i < data.length; i++) {
          let value = data[i];
          if (value > 0) {
              if (value % 2 === 0) {
                  total += value;
              } else {
                  total -= value;
              }
          } else {
              console.log("Non-positive value encountered: " + value);
          }
      }
      console.log("Final total: " + total);
  } else {
      console.error("Data is empty or undefined.");
  }
}
