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
            Sider,
            Razorback,
            Trotter,
            Snouter,
            LeaningJowler                     
        }

        public RollOutcomes rollOnce()
        {
            if (random.NextDouble() < 0.5)
            {
                return RollOutcomes.Sider;
            }
            return RollOutcomes.Razorback;
        }

    }
}
