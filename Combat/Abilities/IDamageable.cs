// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDamageable.cs" company="AIE">
//   AIE
// </copyright>
// <summary>
//   The Damageable interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Abilities
{
    /// <summary>
    /// The Damageable interface.
    /// </summary>
    public interface IDamageable
    {
        /// <summary>
        /// The take damage.
        /// </summary>
        /// <param name="damager">
        /// The damager.
        /// </param>
        void TakeDamage(IDamager damager);
    }
}