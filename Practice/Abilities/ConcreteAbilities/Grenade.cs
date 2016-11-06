// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Grenade.cs" company="AIE">
//   aq
// </copyright>
// <summary>
//   The grenade.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Abilities.ConcreteAbilities
{
    using System;

    /// <summary>
    /// The grenade.
    /// </summary>
    public class Grenade : IAbility, IDamager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Grenade"/> class.
        /// </summary>
        /// <param name="cost">
        /// The cost.
        /// </param>
        /// <param name="damage">
        /// The damage.
        /// </param>
        public Grenade(int cost, int damage)
        {
            this.Cost = cost;
            this.Amount = damage;
        }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        public IDamageable Target { get; set; }

        /// <summary>
        /// Gets or sets the cost.
        /// auto property?
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// Gets or sets the damage.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// TODO The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return "Grenade";
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <exception cref="NullReferenceException">
        /// the target did not get assigned
        /// </exception>
        public virtual void Execute()
        {
            if (this.Target == null)
            {
                throw new NullReferenceException();
            }

            this.DoDamage(this.Target);
        }

        /// <summary>
        /// Apply damage to a damageable object
        /// </summary>
        /// <param name="damageable">
        /// The damageable taking the damage.
        /// </param>
        public void DoDamage(IDamageable damageable)
        {
            Console.WriteLine("{0} :: Amount {1} -> {2} \n", this, this.Amount, this.Target);
            damageable.TakeDamage(this);
        }
    }
}