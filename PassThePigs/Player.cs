using System;
using static PassThePigs.Pig;

namespace PassThePigs
{
    public class Player
    {
       
        public Player()
        {
            //check if pig values already populated
            
        }

        public Player(string name = "Random player") : base() // TODO: make test that ensures this can be passed in as null
        {
            this.Name = name;
        }
        public Player(string name, Pig pig1, Pig pig2) : base()
        {
            this.Name = name;
            this.Pig1 = pig1;
            this.Pig2 = pig2;
        }
        private Pig _pig1;

        public string Name { get; private set; }
        public Pig Pig1 { get => _pig1; set => _pig1 = value; }

        private Pig _pig2;
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

        public RollOutcomes[] RollTwoPigs()
        {
            RollOutcomes[] rollArray = new RollOutcomes[2];
            try {
                rollArray[0] = Pig1.rollOnce();
                rollArray[1] = Pig2.rollOnce();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            
            return rollArray;
        }

        public int PointValueOfRoll(RollOutcomes[] rolls)
        {

            Console.WriteLine("in Pig.cs | rolls.GetValue(0) = {0}", rolls.GetValue(0).ToString());
            //if (rolls.GetValue(0)==rolls.GetValue(1)
            return 0;
        }
    }
}