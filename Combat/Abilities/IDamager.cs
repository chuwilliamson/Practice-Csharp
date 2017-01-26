// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDamager.cs" company="AIE">
//   A
// </copyright>
// <summary>
//   The Damager interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Abilities
{
    /// <summary>
    /// The Damager interface.
    /// </summary>
    public interface IDamager
    {
        /// <summary>
        /// Gets or sets the damage.
        /// </summary>
        int Amount { get; set; }

        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        int Cost { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        IDamageable Target { get; set; }

        /// <summary>
        /// The do damage.
        /// </summary>
        /// <param name="damageable">
        /// The damageable.
        /// </param>
        void DoDamage(IDamageable damageable);
    }
}