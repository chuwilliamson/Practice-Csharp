// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Vanish.cs" company="AIE">
//   A
// </copyright>
// <summary>
//   The vanish.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Abilities.ConcreteAbilities
{
    using System;

    /// <summary>
    /// The vanish.
    /// </summary>
    public class Vanish : IAbility
    {
        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// The execute.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("Vanish.... \n");
        }
    }
}