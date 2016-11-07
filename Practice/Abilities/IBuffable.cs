// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBuffable.cs" company="AIE">
//   AIE
// </copyright>
// <summary>
//   Defines the IBuffable type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Abilities
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// TODO The Buffable interface.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public interface IBuffable
    {
        /// <summary>
        /// TODO The take buff.
        /// </summary>
        /// <param name="buffer">
        /// The buffer.
        /// </param>
        void TakeBuff(IBuffer buffer);
    }
}