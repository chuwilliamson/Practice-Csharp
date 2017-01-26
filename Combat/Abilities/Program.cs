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
            var guy = new Cactuar("Cactus guy", 125, 25);
            var girl = new Cactuar("Cactus girl", 80, 100);

            Console.WriteLine("Guy Status: " + guy.Status);
            Console.WriteLine("Girl Status: " + girl.Status);

            for (var input = Console.ReadLine(); !string.Equals(input, "q"); input = Console.ReadLine())
            {
                Console.Clear();

                Console.WriteLine("Guy Status: " + guy.Status);
                Console.WriteLine("Girl Status: " + girl.Status);

                switch (input)
                {
                    case "w":
                        girl.Add("ThousandNeedles", new ThousandNeedles(25, 28));
                        girl.Cast("ThousandNeedles", guy);
                        break;
                    case "a":
                        girl.Add("Grenade", new Grenade(5, 25));
                        girl.Cast("Grenade", guy);
                        break;
                    case "s":
                        guy.Add("GuyGrenade", new Grenade(5, 15));
                        guy.Cast("GuyGrenade", guy);
                        break;
                    case "d":
                        guy.Add("Cure", new Cura(5, 5));
                        guy.Cast("Cure", guy);
                        break;
                    default:
                        Console.WriteLine("NO...");
                        break;
                }
            }

            Console.WriteLine("Program Complete..");
        }
    }
}