using System;

namespace Utilities
{
   public class Die
    {
        private Die()
        {
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
        private Random generate = new Random();
    }
    
}
