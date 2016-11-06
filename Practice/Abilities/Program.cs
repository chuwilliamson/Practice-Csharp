// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="AIE">
//   COPY
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Abilities
{
    using System; // Console.Writeline();

    using Abilities.ConcreteAbilities;
    using Abilities.ConcreteEntities;

    /// <summary>
    /// The program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        private static void Main()
        {
            var c = new Cactuar("Cactus guy", 125, 25);
            var d = new Cactuar("Cactus girl", 80, 100);
            c.Cast("grenade", d); 
            c.Cast("vanish"); 
            c.Cast("heal", c);
            d.Cast("grenade", c);
            d.Cast("grenade", c);
            d.Cast("grenade", c);
            d.Cast("grenade", c);
            
            for (var input = Console.ReadLine(); !string.Equals(input, "q"); input = Console.ReadLine())
            {
                d.Add(input, new ThousandNeedles(new Grenade(25, 28)));
                d.Cast(input, c);
            }

            Console.WriteLine("Program Complete..");
        }
    }
}