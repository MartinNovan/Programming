function processTransactions(transactions) {
  for (let i = 0; i < transactions.length; i++) {
      let transaction = transactions[i];
      if (transaction.type === "credit") {
          if (transaction.amount > 1000) {
              applyBonus(transaction);
          } else {
              applyStandardProcessing(transaction);
          }
      } else if (transaction.type === "debit") {
          if (transaction.amount > 500) {
              requireApproval(transaction);
          } else {
              deductAmount(transaction);
          }
      } else {
          console.log("Unknown transaction type: " + transaction.type);
      }
  }
}
