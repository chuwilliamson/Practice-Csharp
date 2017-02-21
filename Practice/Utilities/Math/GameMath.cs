using System;

namespace Utilities.Math
{
   public class Die
    {
        private Die()
        {
             generate = new Random();
        }

        public Die(int s)
        {
            sides = s;
        }

        public int Roll()
        {
            return generate.Next(1 , sides + 1);
        }

        private int sides;
        private Random generate;
    }
    
}
