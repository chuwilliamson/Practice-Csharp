// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBuffer.cs" company="AIE">
//   AIE
// </copyright>
// <summary>
//   TODO The Buffer interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Abilities
{
    /// <summary>
    /// TODO The Buffer interface.
    /// </summary>
    public interface IBuffer 
    {
        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        int Cost { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        IDamageable Target { get; set; }
    }
}