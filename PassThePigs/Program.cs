using System;

namespace PassThePigs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Would you like to play Pass the Pigs?");

            Console.Write("What is your name: ");
            string name = Console.ReadLine();
            while (!IsName(name))
            {
                Console.WriteLine("Please enter your name using only alphabetic characters.");
                Console.Write("What is your name:");
                name = Console.ReadLine();
            }
            Player player1 = new Player(name);
            Pig pig1 = new Pig();
            Pig pig2 = new Pig();
            player1.Pig1 = pig1;
            player1.Pig2 = pig2;
            Player[] players =
            {
                player1
            };
            try
            {
                ChoosePigColors(players[0]);
                Game(players);
            }
            catch (Exception e)
            {
                Console.WriteLine("There was an error playing the game. \n" +
                    "\tSorry, we made a mis-steak.");
            }
            finally
            {
                Console.WriteLine("Thanks for playing!");
                Console.ReadKey();
            }
        }

        private static bool IsName(string v)
        {
            if (String.IsNullOrWhiteSpace(v))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Prompts for choosing the color of the pig
        /// </summary>
        /// <param name="currentPlayer">The player choosing pig color</param>
        private static void ChoosePigColors(Player currentPlayer)
        {
            if (currentPlayer == null|| currentPlayer.Name == null)
            {
                throw new ArgumentNullException(nameof(currentPlayer));
            }
            else if (currentPlayer.Pig1==null || currentPlayer.Pig2 == null)
            {
                throw new Exception(String.Format("Exception in Program: your Player {0} should have a pig.", currentPlayer.Name));
            }

            Console.WriteLine("Please select a pig color for {0}: \n" +
            "\t(0-Black, 1-White, 2-Pink, 3-Brown, 4-Yellow, 5-Blue, 6-Purple, 7-Green)",nameof(currentPlayer.Pig1));
            
            SetOnePigColor(currentPlayer.Pig1);

            Console.WriteLine("Please select a pig color for {0}: \n" +
            "\t(0-Black, 1-White, 2-Pink, 3-Brown, 4-Yellow, 5-Blue, 6-Purple, 7-Green)", nameof(currentPlayer.Pig2));

            SetOnePigColor(currentPlayer.Pig2);
        }

        private static void SetOnePigColor(Pig currentPig)
        {
            bool setColor = false;
            while (!setColor)
            {
                setColor = int.TryParse(Console.ReadLine(), out int color);

                if (setColor && color >= 0 && color <= 7)
                {
                    try
                    {
                        if ((setColor = currentPig.SetPigColor(color)))
                        {
                            Console.WriteLine("You have set {0}'s color to: " + currentPig.Color, nameof(currentPig)); // TODO: Use pig name property here
                        }
                    }
                    catch (Exception e)
                    {
                        setColor = false;
                        Console.WriteLine("Setting pig color was unsuccessful.");
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    setColor = false;
                    Console.WriteLine("Please enter a color in the range 0 to 7.");
                }

            }
        }

        private static void Game(Player[] players)
        {
            Display disp = new Display();
            if (players == null || players[0] == null)
            {
                throw new Exception("Player array was null");
            }
            Console.WriteLine(disp.PreRoll());
            bool keepPlaying = true;
            int i = 0;
            for (Player currentPlayer = players[i]; keepPlaying; i = ++i % (players.Length))
            {
                Console.WriteLine("current player #{0}: {1} ", i, currentPlayer.Name);
                Console.WriteLine("Your current pigs are " + currentPlayer.Pig1.Color 
                    + " and " 
                    + currentPlayer.Pig2.Color);

                try
                {
                    Pig.RollOutcomes[] rolls = currentPlayer.RollTwoPigs();
                    foreach (Pig.RollOutcomes roll in rolls)
                    {
                        Console.WriteLine
                            ("Player {0} | Pig {1} rolled a {2}",
                            currentPlayer.Name, currentPlayer.Pig1, roll);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("There was an exception...");
                    Console.WriteLine(e.ToString());
                }
                Console.WriteLine("Press any key to roll again, or Q to quit");
                char userInput = Console.ReadKey().KeyChar;
                if (userInput == 'Q' || userInput == 'q')
                {
                    break;
                }

            }
            //Console.WriteLine(disp.QuestionKeepRolling());
            Console.Write(disp.QuestionEndTournament());
            string answer = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(answer) 
                || answer.StartsWith("N") || answer.StartsWith("n"))
            {
                keepPlaying = false;
            }
        }
    }
}
