using System;

int attempt = 0;
while (attempt < 3)
{
    if (TryConnect())
    {
        Console.WriteLine("Connected successfully.");
        break;
    }
    else
    {
        Console.WriteLine("Retrying connection...");
        attempt++;
    }
}

if (attempt == 3)
{
    Console.WriteLine("Failed to connect after 3 attempts.");
}
