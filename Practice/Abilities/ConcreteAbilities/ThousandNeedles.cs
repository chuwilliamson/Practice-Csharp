// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThousandNeedles.cs" company="AIE">
//   A
// </copyright>
// <summary>
//   The thousand needles.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Abilities.ConcreteAbilities
{
    using System;

    /// <summary>
    /// The thousand needles.
    /// </summary>
    public class ThousandNeedles : IAbility, IDamager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ThousandNeedles"/> class.
        /// </summary>
        /// <param name="amount">
        /// TODO The amount.
        /// </param>
        /// <param name="cost">
        /// TODO The cost.
        /// </param> 
        public ThousandNeedles(int amount, int cost)
        {
            this.Amount = amount;
            this.Cost = cost;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThousandNeedles"/> class.
        /// </summary>
        /// <param name="damager">
        /// TODO The damager.
        /// </param>
        public ThousandNeedles(IDamager damager)
        {
            this.Amount = damager.Amount;
            this.Cost = damager.Cost;
            this.Target = damager.Target;
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
        /// TODO The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return "Core Ability";
        }

        /// <summary>
        /// Execute this ability from the IAbility interface
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("Thousand needles!! \n");
            this.DoDamage(this.Target);
        }

        /// <summary>
        /// TODO The do damage.
        /// </summary>
        /// <param name="damageable">
        /// TODO The damageable.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// TODO The damageable.
        /// </exception>
        public void DoDamage(IDamageable damageable)
        {
            Console.WriteLine("{0} :: Amount {1} -> {2} \n", this, this.Amount, this.Target);
            damageable.TakeDamage(this);
        }
    }
}