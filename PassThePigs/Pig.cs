using System;
using System.Collections.Generic;
using System.Text;

namespace PassThePigs
{
    public class Pig
    {
        static Random random = new Random();
        public Pig()
        {

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
    }
}
