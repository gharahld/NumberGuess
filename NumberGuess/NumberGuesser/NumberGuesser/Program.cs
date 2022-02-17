using System;
using System.Data;
using System.Data.SqlClient;


// Namespace
namespace NumberGuesser
{
    //Main Class
    class Program
    {
        public static string inputName;
        public static object input;
        //private static SqlDbType;



        // Entry point Method
        static void Main(string[] args)
        {
            GetAppInfo(); // Run GetAppInfo function to get info

            string playerName = GreetUser(); // ask for users and greet


            while (true)
            {

                // Create a new Random object
                Random random = new Random();

                // Init correct number
                int correctNumber = random.Next(1, 10);


                // Init guess var
                int guess = 0;
                int counter = 1;

                // Ask user for number
                Console.WriteLine("Guess a number between 1 and 10");
                while (guess != correctNumber)
                {

                    // Get user input
                    string input = Console.ReadLine();

                    //Make sure it's a number
                    if (!int.TryParse(input, out guess))
                    {
                        // Print error message
                        PrintColorMessage(ConsoleColor.DarkBlue, "Please use an actual number");
                        // Keep going
                        continue;


                    }


                    //Cast to int and put in guess
                    guess = Int32.Parse(input);

                    //Match guess to correct number
                    if (guess != correctNumber)
                    {
                        // Print error message
                        counter++;
                        PrintColorMessage(ConsoleColor.Yellow, "Wrong number, please try again");
                    }



                }
                
            

                // Change test color
                Console.ForegroundColor = ConsoleColor.DarkRed;
                // Reset text color
                Console.ResetColor();

                // Adding time
                var date = DateTime.Now;
                Console.WriteLine(date);
                // Initialize the connection

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ghara\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30;");
               //creating a command between the sql and c#
                SqlDataAdapter sda = new SqlDataAdapter("INSERT INTO Leaderboard (Name, Score, Date) VALUES ('" + playerName + "', '" + counter + "', '" + date + "');", con);
                //prepare a table
                DataTable dt = new DataTable();
                //Fill the table
                sda.Fill(dt);

                // Print success message

                PrintColorMessage(ConsoleColor.DarkMagenta, "CORRECT!!! "+ playerName + " YOU GUESSED IT " + counter + " time(s)");

                // Ask to save the game
                Console.WriteLine("Do you want to save the score? [S] or [N]");
                //Get answer
                string answer2 = Console.ReadLine().ToUpper();

                if (answer2 == "S")
                {
                    Console.WriteLine("Your score have been saved at {0}", date);
                }
                else if (answer2 == "N")
                {
                    Console.WriteLine("your score will not be saved {0}", date);
                }
                
              
                // Ask to play again
                Console.WriteLine("Play Again? [Y or N]");

                //Get answer
                string answer = Console.ReadLine().ToUpper();

                if (answer == "Y")
                {
                    continue;
                }
                else if (answer == "N")
                {
                    return;
                }
                else
                {
                    return;
                }


            }

        }
        static void GetAppInfo()
        {
            // Set up vars
            string appName = "Number Guesser";
            string appVersion = "1.0.0";
            string appAuthor = "Gharahld L. Bruno";

            // Change test color
            Console.ForegroundColor = ConsoleColor.Magenta;

            // write app info
            Console.WriteLine("{0}: Version {1} by {2}", appName, appVersion, appAuthor);

            // Reset text color
            Console.ResetColor();
        }

        static string GreetUser()
        {
            // Ask users name
            Console.WriteLine("What is your name?");

            // Get user input
            string inputName = Console.ReadLine();
            Console.WriteLine(" Hello {0}, let's play a game...", inputName);

            return inputName;
        }

        // Print Color Message
        static void PrintColorMessage(ConsoleColor color, string message)
        {
            // Change test color
            Console.ForegroundColor = color;

            // Tell user it is not a number
            Console.WriteLine(message);

            // Reset text color
            Console.ResetColor();
        }

        
    }
    
}
