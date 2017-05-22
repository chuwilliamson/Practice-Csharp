// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Entity.cs" company="AIE">
//   A
// </copyright>
// <summary>
//   The entity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Abilities
{
    using System.Collections.Generic;

    /// <summary>
    /// The entity.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="health">
        /// The health.
        /// </param>
        /// <param name="resource">
        /// The resource.
        /// </param>
        protected Entity(string name, int health, int resource)
        {
            this.Health = health;
            this.Resource = resource;
            this.Name = name;
        }

        /// <summary>
        /// Gets or sets the health.
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// Gets or sets the resource.
        /// </summary>
        public int Resource { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

       
    }
}