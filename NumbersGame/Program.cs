using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Getting SecretNumber[0] and attemptsLeft[1] from method Setting based on what Menu gives in return.
            int[] secretNumbAndAttempts = Settings(Menu());

            if (secretNumbAndAttempts[1] != 0)
            {
                Console.WriteLine();
                Console.WriteLine($"\"Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får {secretNumbAndAttempts[1]} försök.\"\n");
                Console.WriteLine("Tryck på en valfri tangent när du är redo att börja!");
                Console.ReadKey();
                Console.Clear();

                int attempts = 0;
                bool guess = false;
                while (guess == false && secretNumbAndAttempts[1] != 0)
                {
                    //Console.WriteLine(secretNumbAndAttempts[0]); Enable the line to see the result of secret number for debugging.
                    Console.Write($"Du har #{secretNumbAndAttempts[1]} försök kvar \n");
                    Console.Write("Gissa nummer: ");

                    int playerGuess = 0;
                    try
                    {
                        playerGuess = Convert.ToInt32(Console.ReadLine());

                    }
                    catch (System.FormatException)
                    {

                        Console.WriteLine("Detta var inget nummer, försök igen.");
                    }
                    Console.WriteLine();

                    // Checking the guess input and returning true or false.
                    bool checkedGuess = CheckGuess(playerGuess, secretNumbAndAttempts[0]);
                    Console.WriteLine();
                    attempts++;

                    // checks if user guessed to many times and exiting the program.
                    if (secretNumbAndAttempts[1] == 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"\nTyvärr du lyckades inte gissa talet på {attempts} försök, det hemliga talet var {secretNumbAndAttempts[0]} :( \n");
                        guess = true;

                        Console.WriteLine("Vill du börja om? ( ja / nej ) \n");
                        Console.Write("svar: ");
                        string playAgain = Console.ReadLine().ToLower();
                        if (playAgain == "ja")
                        {
                            Console.Clear();
                            guess = false;
                            secretNumbAndAttempts = Settings(Menu());
                            Console.WriteLine();
                        }
                        secretNumbAndAttempts[1]--;
                    }
                    // Checks if user guessed the right number.
                    if (checkedGuess == true)
                    {
                        Console.Clear();
                        Console.Write("##############################\n");
                        Console.WriteLine("\nWohoo! Du gjorde det!");
                        Console.WriteLine($"\nRätt svar: {playerGuess}");
                        Console.WriteLine($"\nAntal försök: {attempts}");
                        Console.WriteLine();
                        Console.Write("##############################\n");
                        break;
                    }
                }
                Console.WriteLine("\nTryck på valfri tangent för att avsluta programmet...");
                Console.ReadKey();
            }
            else 
            {
                Console.WriteLine("Avslutar spelet...");
                Console.ReadKey();
            }
        }
        public static int Menu()
        {
            int userChoice = 0;
            while (userChoice == 0 && userChoice <= 6)
            {

                Console.WriteLine("              Välj svårighetsgrad");
                Console.WriteLine();
                Console.WriteLine("1.Easy");
                Console.WriteLine("2.Medium");
                Console.WriteLine("3.Hard");
                Console.WriteLine("4.Expert");
                Console.WriteLine("5.Impossible");
                Console.WriteLine("6.Avsluta programmet\n");
                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());

                }
                catch (System.FormatException)
                {

                    Console.WriteLine("Fel inmatning, försök igen.");
                }
                Console.Clear();
                Console.WriteLine();
            
                switch (userChoice)
                {
                    case 1:
                        Console.Write("1. Du valde: Easy\n");
                        break;
                    case 2:
                        Console.Write("2. Du valde: Medium\n");
                        break;
                    case 3:
                        Console.Write("3. Du valde: Hard\n");
                        break;
                    case 4:
                        Console.Write("4. Du valde: Expert\n");
                        break;
                    case 5:
                        Console.Write("5. Du valde: Impossible\n");
                        break;
                    case 6:
                        break;
                }
            }
            return userChoice;
        }
        public static int[] Settings(int setting)
        {   
            Random rnd = new Random();
            int SecretNumber = 0;
            int attemptsLeft = 0;
            int chosenDifficulty = setting;
            int[] suggestions = {attemptsLeft, SecretNumber};

            if (chosenDifficulty == 1)
            {
                SecretNumber = rnd.Next(1, 16);
                attemptsLeft = 10;
                suggestions[0] = SecretNumber;
                suggestions[1] = attemptsLeft;
            }
            else if (chosenDifficulty == 2)
            {
                SecretNumber = rnd.Next(1, 16);
                attemptsLeft = 8;
                suggestions[0] = SecretNumber;
                suggestions[1] = attemptsLeft;
            }
            else if (chosenDifficulty == 3)
            {
                SecretNumber = rnd.Next(1, 21);
                attemptsLeft = 5;
                suggestions[0] = SecretNumber;
                suggestions[1] = attemptsLeft;
            }
            else if (chosenDifficulty == 4)
            {
                SecretNumber = rnd.Next(1, 21);
                attemptsLeft = 3;
                suggestions[0] = SecretNumber;
                suggestions[1] = attemptsLeft;
            }
            else if (chosenDifficulty == 5)
            {
                SecretNumber = rnd.Next(1, 21);
                attemptsLeft = 1;
                suggestions[0] = SecretNumber;
                suggestions[1] = attemptsLeft;
            }
            else if (chosenDifficulty == 6)
            {
                SecretNumber = 0;
                attemptsLeft = 0;
                suggestions[0] = SecretNumber;
                suggestions[1] = attemptsLeft;
            }
            return suggestions; 
        }
        public static bool CheckGuess(int userInput, int secretNumber)
        {
            bool rightAns = false;
            
            if (userInput < secretNumber)
            {
                Console.WriteLine(ToLowResponse());
            }
            else if (userInput > secretNumber)
            {
                Console.WriteLine(ToHighResponse());
            }
            else
            {
                rightAns = true;
            }
            return rightAns;
        }
        private static string ToHighResponse()
        {
            Random rnd = new Random();
                        
            string[] negativeRespons = new string[5] { "Det var tyvärr inte rätt, lite lägre kan du", "Hoppsan, här vart det fel men försök med ett mindre tal!", "Åh nej, talet är mindre än så", "Fel fel fel.. mindre mindre mindre! Försök igen", "Inte riktigt rätt, försök igen fast med ett lite mindre tal denna gången" };

            int index = rnd.Next(negativeRespons.Length);
            string newNegative = negativeRespons[index];
            return newNegative;
        }
        private static string ToLowResponse()
        {
            Random rnd = new Random();

            string[] negativeRespons = new string[5] { "Det var tyvärr lite för lågt, försök igen", "Hoppsan här vart det fel, lite högre denna gången", "Åh nej detta var fel, högre! Försök igen", "Fel fel fel.. högre högre högre! Försök igen", "Inte riktigt rätt, försök igen men kanske lite högre" };

            int index = rnd.Next(negativeRespons.Length);
            string newNegative = negativeRespons[index];
            return newNegative;
        }
    }
}