using System;
using System.Collections.Generic;
using System.Text;

namespace PassThePigs
{
    public class Pig
    {
        private int color;
        static Random random = new Random();
        public Pig()
        {
            // Temporary default color
            this.color = 0;
        }

        public enum RollOutcomes
        {
            NoDot,
            Dot,
            Razorback,
            Trotter,
            Snouter,
            LeaningJowler                     
        }
        /// <summary>
        /// Calculates the roll, based on probability. 
        /// Shout-out to Dayne Batten for the probabilities - 
        ///     see http://daynebatten.com/2015/09/optimal-pass-the-pigs-strategy/
        /// </summary>
        /// <returns></returns>
        public RollOutcomes rollOnce()
        {
            double result;
            if ((result = random.NextDouble()) < 0.35)
            {
                return RollOutcomes.NoDot;
            }
            else if (result < .65)
            {
                return RollOutcomes.Dot;
            }
            else if (result < .85)
            {
                return RollOutcomes.Razorback;
            }
            else if (result < .95)
            {
                return RollOutcomes.Trotter;
            }
            else if (result < .99)
            {
                return RollOutcomes.Snouter;
            }
            else
            {
                return RollOutcomes.LeaningJowler;
            }
        }

        /*
         * Set pig color to int corresponding to color:
         * 0-Black, 1-White, 2-Pink, 3-Brown, 4-Yellow, 5-Blue, 6-Purple, 7-Green
         * Return true if successful color change
         */
        public bool changeColor(int color) {
            if (color >= 0 && color <= 7) {
                this.color = color;
                return true;
            }
            return false;
        }

        /* 
         * Fetch name of pig color
         * 0-Black, 1-White, 2-Pink, 3-Brown, 4-Yellow, 5-Blue, 6-Purple, 7-Green
         */
        public String getColor() {
            if (color == 0)
                return "Black";
            else if (color == 1)
                return "White";
            else if (color == 2)
                return "Pink";
            else if (color == 3)
                return "Brown";
            else if (color == 4)
                return "Yellow";
            else if (color == 5)
                return "Blue";
            else if (color == 6)
                return "Purple";
            else
                return "Green";
        }
    }
}
