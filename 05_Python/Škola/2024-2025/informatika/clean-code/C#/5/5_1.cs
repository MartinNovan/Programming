void AnalyzeData(List<int> data)
{
    if (data != null && data.Count > 0)
    {
        int total = 0;
        foreach (int value in data)
        {
            if (value > 0)
            {
                if (value % 2 == 0)
                {
                    total += value;
                }
                else
                {
                    total -= value;
                }
            }
            else
            {
                Console.WriteLine("Non-positive value encountered: " + value);
            }
        }
        Console.WriteLine("Final total: " + total);
    }
    else
    {
        Console.WriteLine("Data is empty or undefined.");
    }
}
