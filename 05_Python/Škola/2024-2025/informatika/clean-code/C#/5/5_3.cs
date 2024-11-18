void EvaluateCondition(int a)
{
    if (a > 0)
    {
        if (a < 10)
        {
            if (a % 2 == 0)
            {
                Console.WriteLine("a is positive, less than 10, and even.");
            }
            else
            {
                Console.WriteLine("a is positive, less than 10, and odd.");
            }
        }
        else
        {
            if (a % 2 == 0)
            {
                Console.WriteLine("a is positive, 10 or more, and even.");
            }
            else
            {
                Console.WriteLine("a is positive, 10 or more, and odd.");
            }
        }
    }
    else if (a == 0)
    {
        Console.WriteLine("a is zero.");
    }
    else
    {
        Console.WriteLine("a is negative.");
    }
}
