// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cura.cs" company="AIE">
//   A
// </copyright>
// <summary>
//   The Cure Ability.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Abilities.ConcreteAbilities
{
    using System;

    /// <summary>
    /// The Cure Ability.
    /// </summary>
    public class Cura : IAbility, IDamager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cura"/> class.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="cost">
        /// TODO The cost.
        /// </param>
        public Cura(int value, int cost)
        {
            this.Amount = -value;
            this.Cost = cost;
        }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        public IDamageable Target { get; set; }

        /// <summary>
        /// TODO The do damage.
        /// </summary>
        /// <param name="damageable">
        /// TODO The damageable.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// TODO the exception
        /// </exception>
        public void DoDamage(IDamageable damageable)
        {
            damageable.TakeDamage(this);
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// you didn't implement it
        /// </exception>
        public void Execute()
        {
            Console.WriteLine("Healing for {0} damage @ {1} cost \n", this.Amount, this.Cost);
            this.DoDamage(this.Target);
        }
    }
}