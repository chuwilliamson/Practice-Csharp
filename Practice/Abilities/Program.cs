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
    using System;

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
            var c = new Cactuar("cactus guy", 125, 25);
            c.Cast("grenade", c); 
            c.Cast("vanish"); 
            c.Cast("heal"); 
            Console.WriteLine("Program Complete..");
            Console.ReadLine();
        }
    }
}