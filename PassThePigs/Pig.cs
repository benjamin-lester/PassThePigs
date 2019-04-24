using System;
using System.Collections.Generic;
using System.Text;

namespace PassThePigs
{
    /// <summary>
    /// Contains properties and functions about the beloved pigs.
    /// </summary>
    public class Pig
    {
        static Random random = new Random();
        public Pig()
        {
            // Temporary default color = Black
            this._color = 0;
            
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
        /// <returns>A single enum value of RollOutcomes, based on chance (probability)</returns>
        public RollOutcomes RollOnce()
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

        /// <summary>
        /// Set pig color to int corresponding to color:
        ///    0-Black, 1-White, 2-Pink, 3-Brown, 4-Yellow, 5-Blue, 6-Purple, 7-Green
        /// </summary>
        /// <returns>True if successful color change</returns>
        internal bool SetPigColor(int color)
        {
            if (color >= 0 && color <= 7)
            {
                this._color = color;
                return true;
            }
            return false;
        }

        private int _color;        
        public String Color
        {
            get
            {
                if (_color == 0)
                {
                    return "Black";
                }
                else if (_color == 1)
                {
                    return "White";
                }
                else if (_color == 2)
                {
                    return "Pink";
                }
                else if (_color == 3)
                {
                    return "Brown";
                }
                else if (_color == 4)
                {
                    return "Yellow";
                }
                else if (_color == 5)
                {
                    return "Blue";
                }
                else if (_color == 6)
                {
                    return "Purple";
                }
                return "Green";
            }
        }
        
    }
}
