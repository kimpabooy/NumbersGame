using System.Collections.Generic;
using System.Reflection;

namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Getting SecretNumber[0] and attemptsLeft[1] from method
            int[] secretNumbAndAttempts = Settings(Menu());
            
            Console.WriteLine();
            Console.WriteLine($"\"Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får {secretNumbAndAttempts[1]} försök.\"\n");
            Console.WriteLine("Tryck på en valfri tangent när du är redo att börja!");
            Console.ReadKey();
            Console.Clear();

            bool guess = false;
            while (guess == false)
            {
                int attempts = 0;
                Console.WriteLine($"Hemliga talet: {secretNumbAndAttempts[0]}");
                Console.Write($"Du har #{secretNumbAndAttempts[1]} försök kvar \n");
                Console.Write("Gissa nummer: ");
                int playerGuess = Convert.ToInt32(Console.ReadLine());

                // Checking the input and returning true or false.
                bool checkedGuess = CheckGuess(playerGuess, secretNumbAndAttempts[0]);
                
                attempts++;
                secretNumbAndAttempts[1]--;

                // checks if user guessed to many times.
                if (secretNumbAndAttempts[1] == 0)
                {
                    Console.Clear();
                    Console.WriteLine($"\nTyvärr du lyckades inte gissa talet på fem försök, det hemliga talet var {secretNumbAndAttempts[0]} :( \n");
                    guess = true;
                }

                // If the answer is right.
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
            Console.ReadLine();
        }
        public static int Menu()
        {
            Console.WriteLine("              Välj svårighetsgrad");
            Console.WriteLine();
            Console.WriteLine("1.Easy");
            Console.WriteLine("2.Medium");
            Console.WriteLine("3.Hard");
            Console.WriteLine("4.Expert");
            Console.WriteLine("5.Impossible");
            Console.WriteLine("6.Avsluta programmet\n");
            int menu = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine();
            
            switch (menu)
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
            return menu;
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
            return suggestions; 
        }
        
        // The method takes in userInput and the secretNumber and returns a boolean.
        public static bool CheckGuess(int userInput, int secretNumber)
        {
            bool rightAns = false;
            
            if (userInput < secretNumber)
            {
                Console.WriteLine("Tyvärr du gissade för lågt!");
                //Console.WriteLine("Tyvärr du gissade för lågt!" + NegativeResponse());
            }
            else if (userInput > secretNumber)
            {
                Console.WriteLine("Tyvärr du gissade för högt!\n");
            }
            else
            {
                rightAns = true;
            }
            return rightAns;
        }

        public static string NegativeResponse()
        {
            Random rnd = new Random();

            string[] negativeRespons = new string[]{ "Nej det var fel", "hej", "hej då", "halloj!", "ja" }.;
            string negative = negativeRespons(rnd.Next[rnd.Next]);
            return negative;
        }
    }
}


/*
 
{
        static void Main(string[] args)
        {
            // Getting SecretNumber[0] and attemptsLeft[1] from method
            int[] secretNumbAndAttempts = Settings(Menu());

            Console.WriteLine();
            Console.WriteLine($"\"Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får {secretNumbAndAttempts[1]} försök.\"\n");
            Console.WriteLine("Tryck på en valfri tangent när du är redo att börja!");
            Console.ReadKey();
            Console.Clear();

            bool guess = false;
            while (guess == false)
            {
                int attempts = 0;
                Console.WriteLine($"Hemliga talet: {secretNumbAndAttempts[0]}");
                Console.Write($"Du har #{secretNumbAndAttempts[1]} försök kvar \n");
                Console.Write("Gissa nummer: ");
                int playerGuess = Convert.ToInt32(Console.ReadLine());

                // Checking the input and returning true or false.
                bool checkedGuess = CheckGuess(playerGuess, secretNumbAndAttempts[0]);
                
                attempts++;
                secretNumbAndAttempts[1]--;

                // checks if user guessed to many times.
                if (secretNumbAndAttempts[1] == 0)
                {
                    Console.Clear();
                    Console.WriteLine($"\nTyvärr du lyckades inte gissa talet på fem försök, det hemliga talet var {secretNumbAndAttempts} :( \n");
                    guess = true;
                }

                // If the answer is right.
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
            Console.ReadLine();
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
            return suggestions; 
        }
        public static int Menu()
        {
            Console.WriteLine("              Välj svårighetsgrad");
            Console.WriteLine();
            Console.WriteLine("1.Easy");
            Console.WriteLine("2.Medium");
            Console.WriteLine("3.Hard");
            Console.WriteLine("4.Expert");
            Console.WriteLine("5.Impossible");
            Console.WriteLine("6.Avsluta programmet\n");
            int menu = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine();
            
            switch (menu)
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
            return menu;
        }
        
        // The method takes in userInput and the secretNumber and returns a boolean.
        public static bool CheckGuess(int userInput, int secretNumber)
        {
            bool rightAns = false;
            
            if (userInput < secretNumber)
            {
                Console.WriteLine("Tyvärr du gissade för lågt!\n");
            }
            else if (userInput > secretNumber)
            {
                Console.WriteLine("Tyvärr du gissade för högt!\n");
            }
            else
            {
                rightAns = true;
            }
            return rightAns;
        }
    }


 */