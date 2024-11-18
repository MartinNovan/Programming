int totalScore = 0;

int AddScore(int currentScore, int points)
{
    int newScore = currentScore + points;
    Console.WriteLine("Total score is now: " + newScore);
    return newScore;
}

totalScore = AddScore(totalScore, 10);
totalScore = AddScore(totalScore, 20);
