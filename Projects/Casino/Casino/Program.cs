namespace Casino
{
    static class Program
    {
        static void Main()
        {
            bool hasMoney = CheckMoney();
            if (hasMoney)
            {
                Console.WriteLine("Welcome to the casino! :D");
                int credit = SetLimit();
                StartCasino(credit, "");
            }
            else
            {
                Console.WriteLine("You cannot enter without money! >:(");
            }
        }

        static bool CheckMoney()
        {
            Console.Clear();
            Console.WriteLine("Do you have money: Y/N (default: N)");
            string? response = Console.ReadLine();
            if (response == "Y")
            {
                return true;
            }
            else if (response == "N" || response == "")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid input, please enter a valid value.");
                Console.ReadKey();
                return CheckMoney();
            }
        }

        static int SetLimit()
        {
            Console.WriteLine("How much money do you have available?");
            int credit = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            if (credit <= 0)
            {
                Console.WriteLine("Cannot be zero.");
                Console.ReadKey();
                return SetLimit();
            }
            return credit;
        }

        private static void StartCasino(int credit, string lastGame)
        {
            Console.Clear();
            Console.WriteLine($"You have {credit} credits!");
            Console.WriteLine("Choose a game: \n1) Roulette \n2) Guess a random number from 1 to 50 \n99) Exit");
            string? game = Console.ReadLine();
            lastGame = "";
            if (game == "1")
            {
                lastGame = "roulette";
                PlayRoulette(credit, lastGame);
            }
            else if (game == "2")
            {
                lastGame = "randomNumber";
                PlayRandomNumber(credit, lastGame);
            }
            else if (game == "99")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid input, please enter a valid value.");
                Console.ReadKey();
                StartCasino(credit, lastGame);
            }
        }

        static int PlayRoulette(int credit, string lastGame)
        {
            Console.Clear();
            Console.WriteLine($"You have {credit} credits!");
            Random rand = new Random();
            int winningNumber = rand.Next(0, 37);
            string? colorBet = "";
            int betNumber = 99;
            Console.WriteLine("How much do you want to bet?");
            int bet = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            if (bet <= 0)
            {
                Console.WriteLine("You cannot bet a negative value.");
                Console.ReadKey();
                return PlayRoulette(credit, lastGame);
            }
            else if (bet > credit)
            {
                Console.WriteLine("Insufficient credits! Do you have money?");
                Console.ReadKey();
                CheckMoney();
            }

            Console.WriteLine("Do you want to bet on a number or a color? 1) Number 2) Color");
            string? response = Console.ReadLine();
            if (response == "1")
            {
                Console.WriteLine("Enter your bet (number from 0 to 36): ");
                betNumber = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            }
            else if (response == "2")
            {
                Console.WriteLine("Are you betting on red or black? \n1) Red \n2) Black");
                colorBet = Console.ReadLine();
                if (colorBet != "1" && colorBet != "2")
                {
                    Console.WriteLine("Invalid input.");
                    Console.ReadKey();
                    return PlayRoulette(credit, lastGame);
                }
            }

            int[] redNumbers = [1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36];
            int[] blackNumbers = [2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35];

            Console.WriteLine($"Winning number is: {winningNumber}");

            if (betNumber != 99 && betNumber == winningNumber)
            {
                credit += bet * 35;
                Console.WriteLine($"You won {bet * 35} credits.");
                Console.WriteLine($"Congratulations! You won! You have: {credit} credits!");
                Console.ReadKey();
                EndGame(credit, lastGame);
            }
            else if (colorBet == "1" && redNumbers.Contains(winningNumber))
            {
                credit += bet;
                Console.WriteLine($"You won {bet * 2} credits.");
                Console.WriteLine($"Congratulations! You won! You have: {credit} credits!");
                Console.ReadKey();
                EndGame(credit, lastGame);
            }
            else if (colorBet == "2" && blackNumbers.Contains(winningNumber))
            {
                credit += bet;
                Console.WriteLine($"You won {bet * 2} credits.");
                Console.WriteLine($"Congratulations! You won! You have: {credit} credits!");
                Console.ReadKey();
                EndGame(credit, lastGame);
            }
            else
            {
                Console.WriteLine("Unfortunately, you lost.");
                credit -= bet;
                Console.WriteLine($"You lost {bet} credits.");
                Console.WriteLine($"You have {credit} credits.");
                if (credit <= 0)
                {
                    Console.WriteLine("You are out of credits.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    Console.ReadKey();
                    EndGame(credit, lastGame);
                }
            }
            return credit;
        }

        static void PlayRandomNumber(int credit, string lastGame)
        {
            Console.Clear();
            Console.WriteLine($"You have {credit} credits!");
            Random rand = new Random();
            int winningNumber = rand.Next(0, 50);
            Console.WriteLine("Enter your bet");
            int bet = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine("Enter the number you think is correct:");
            int guessedNumber = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine($"Winning number is: {winningNumber}");
            if (guessedNumber < 0 || guessedNumber > 50)
            {
                Console.WriteLine("Invalid number entered!");
                Console.ReadKey();
                PlayRandomNumber(credit, lastGame);
            }
            if (guessedNumber == winningNumber)
            {
                credit += bet * 50;
                Console.WriteLine($"You won {bet * 50} credits.");
                Console.WriteLine($"Congratulations! You won! You have: {credit} credits!");
                Console.ReadKey();
                EndGame(credit, lastGame);
            }
            else
            {
                Console.WriteLine("Unfortunately, you lost.");
                credit -= bet;
                Console.WriteLine($"You lost {bet} credits.");
                Console.WriteLine($"You have {credit} credits.");
                if (credit <= 0)
                {
                    Console.WriteLine("You are out of credits.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    Console.ReadKey();
                    EndGame(credit, lastGame);
                }
            }
        }

        static void EndGame(int credit, string lastGame)
        {
            Console.WriteLine("Do you want to play again? \n1) Yes \n2) Another game \n3) No");
            string? response = Console.ReadLine();
            if (response == "1" || response == "")
            {
                if (lastGame == "roulette")
                {
                    PlayRoulette(credit, lastGame);
                }
                else if (lastGame == "randomNumber")
                {
                    PlayRandomNumber(credit, lastGame);
                }
                else
                {
                    StartCasino(credit, lastGame);
                }
            }
            else if (response == "2")
            {
                StartCasino(credit, lastGame);
            }
            else if (response == "3")
            {
                Console.WriteLine("Thank you for playing!");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid input.");
                Console.ReadKey();
                EndGame(credit, lastGame);
            }
        }
    }
}
