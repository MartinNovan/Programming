function evaluateCondition(a) {
  if (a > 0) {
      if (a < 10) {
          if (a % 2 === 0) {
              console.log("a is positive, less than 10, and even.");
          } else {
              console.log("a is positive, less than 10, and odd.");
          }
      } else {
          if (a % 2 === 0) {
              console.log("a is positive, 10 or more, and even.");
          } else {
              console.log("a is positive, 10 or more, and odd.");
          }
      }
  } else if (a === 0) {
      console.log("a is zero.");
  } else {
      console.log("a is negative.");
  }
}
