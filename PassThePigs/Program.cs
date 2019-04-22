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
            while (!isName(name))
            {
                Console.WriteLine("Please enter your name using only alphabetic characters.");
                Console.Write("What is your name:");
                name = Console.ReadLine();
            }
            Player player1 = new Player(name);
            Player[] players =
            {
                player1
            };
            Game(players);
            Console.WriteLine("Thanks for playing!");

        }

        private static bool isName(string v)
        {
            if (String.IsNullOrWhiteSpace(v))
            {
                return false;
            }
            return true;
        }

        private static void Game(Player[] players)
        {
            Display disp = new Display();
            Pig pig1 = new Pig();
            pig1.changeColor();
            Pig pig2 = new Pig();
            pig2.changeColor();
            Console.WriteLine("Your current pigs are " + pig1.getColor() + " and " + pig2.getColor());
            if (players == null || players[0] == null)
            {
                throw new Exception("Player array was null");
            }
            foreach (Player p in players)
            {
                p.Pig1 = pig1;
                p.Pig2 = pig2;
            }
            Console.WriteLine(disp.PreRoll());
            bool keepPlaying = true;
            int i = 0;
            for (Player currentPlayer = players[i]; keepPlaying; i = ++i % (players.Length))
            {
                Console.WriteLine("current player #{0}: {1} ", i, currentPlayer.Name);

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

                Console.WriteLine(disp.QuestionKeepRolling());
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
}
