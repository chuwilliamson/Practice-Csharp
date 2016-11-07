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
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The vanish.
    /// </summary>
    public class Vanish : IAbility, IBuffer
    {
        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        public IDamageable Target { get; set; }

        /// <summary>
        /// TODO The apply buff.
        /// </summary>
        /// <param name="buffable">
        /// TODO The buffable.
        /// </param>
        public void ApplyBuff(IBuffable buffable)
        {
        }

        /// <summary>
        /// The execute.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("Vanish.... \n");
        }
    }
}