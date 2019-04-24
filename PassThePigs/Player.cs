using System;
using System.Collections.Generic;
using static PassThePigs.Pig;

namespace PassThePigs
{
    /// <summary>
    /// Represents a single player/human who will roll pigs.
    /// </summary>
    public class Player
    {
        #region constructors
        /// <summary>
        /// Base constructor for Player.
        /// </summary>
        public Player()
        {
            // TODO: check if pig values already populated
            
        }
        /// <summary>
        /// Constructs Player with an optional name. 
        /// </summary>
        /// <param name="name">Name of player. Defaults to Random player</param>
        public Player(string name = "Random player") : base() // TODO: make test that ensures this can be passed in as null
        {
            this.Name = name;
        }
        /// <summary>
        /// Constructs a Player with a name and two Pigs.
        /// </summary>
        /// <param name="name">Name of player</param>
        /// <param name="pig1">First pig that Player is rolling</param>
        /// <param name="pig2">Second pig that Player is rolling</param>
        public Player(string name, Pig pig1, Pig pig2) : base()
        {
            this.Name = name;
            this.Pig1 = pig1;
            this.Pig2 = pig2;
        }

        #endregion
        #region properties
        private Pig _pig1;

        public string Name { get; private set; }
        public Pig Pig1 { get => _pig1; set => _pig1 = value; }

        private Pig _pig2;
        // internal IEnumerable<Pig> PigsArray; //TODO: Change PigsArray to IEnumerable
        
        public Pig Pig2 {
            get
            {
                return _pig2;
            }
            set
            {
                _pig2 = value;
            }
        }

        public int color { get; private set; }

        #endregion
        #region functions
        /// <summary>
        /// Calculates the roll for the player's two pigs.
        /// </summary>
        /// <returns>Array of RollOutcomes[] (example: Leaning Jowler and Razorback)</returns>
        public RollOutcomes[] RollTwoPigs()
        {
            RollOutcomes[] rollArray = new RollOutcomes[2];
            try {
                rollArray[0] = Pig1.RollOnce();
                rollArray[1] = Pig2.RollOnce();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            
            return rollArray;
        }

        /// <summary>
        /// Calculates the points associated with roll outcomes
        /// </summary>
        /// <param name="rolls">Array of RollOutcomes, returned by Player.RollTwoPigs()</param>
        /// <returns>Points you gained on that roll</returns>
        public int PointValueOfRoll(RollOutcomes[] rolls)
        {

            Console.WriteLine("Roll {0}", rolls.GetValue(0).ToString());
            //if (rolls.GetValue(0)==rolls.GetValue(1)
            return 0;
        }
        #endregion
    }
}