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
    using System.Diagnostics.CodeAnalysis;

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

        /// <summary>
        /// TODO The apply buff.
        /// </summary>
        /// <param name="buffable">
        /// TODO The buffable.
        /// </param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        void ApplyBuff(IBuffable buffable);
    }
}