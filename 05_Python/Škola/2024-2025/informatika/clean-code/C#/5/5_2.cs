void ProcessTransactions(List<Transaction> transactions)
{
    foreach (var transaction in transactions)
    {
        if (transaction.Type == "credit")
        {
            if (transaction.Amount > 1000)
            {
                ApplyBonus(transaction);
            }
            else
            {
                ApplyStandardProcessing(transaction);
            }
        }
        else if (transaction.Type == "debit")
        {
            if (transaction.Amount > 500)
            {
                RequireApproval(transaction);
            }
            else
            {
                DeductAmount(transaction);
            }
        }
        else
        {
            Console.WriteLine("Unknown transaction type: " + transaction.Type);
        }
    }
}
