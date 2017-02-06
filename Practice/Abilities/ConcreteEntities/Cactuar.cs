// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cactuar.cs" company="AIE">
//   aa
// </copyright>
// <summary>
//   The Cactus man.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Abilities.ConcreteEntities
{
    using System;

    using Abilities.ConcreteAbilities;

    /// <summary>
    /// The Cactus man.
    /// </summary>
    public class Cactuar : Entity, IDamageable, ICaster
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cactuar"/> class.
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
        public Cactuar(string name, int health, int resource)
            : base(name, health, resource)
        {
            this.Add("vanish", new Vanish());
            this.Add("needle", new ThousandNeedles(1000, 1000));
            this.Add("grenade", new Grenade(5, 25));
            this.Add("heal", new Cura(100, 19));
        }

        /// <summary>
        /// TODO The status.
        /// </summary>
        public string Status => "Health::" + this.Health + " Resource::" + this.Resource + " ";

        /// <summary>
        /// add an ability to this Entities ability set
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="ability">
        /// TODO The ability.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Add(string name, IAbility ability)
        {
            if (this.Abilities.ContainsKey(name))
            {
                return false;
            }

            this.Abilities.Add(name, ability);

            return true;
        }

        /// <summary>
        /// The default cast.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public void Cast(string name)
        {
            this.Cast(name, null);
        }
        
        /// <summary>
        /// The cast.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// no value
        /// </exception>
        public void Cast(string name, IDamageable target)
        {
            Console.WriteLine("{0} is attempting to cast {1}... \n", this.Name, name);
            var ability = this.Abilities[name];
            if (ability == null)
            {
                throw new NotImplementedException();
            }

            // cast the ability as a damager if it's null then 
            // it is a default ability
            var damager = ability as IDamager;

            // is this a non-damaging/default Ability?
            if (damager == null)
            {
                ability.Execute();
                return;
            }

            damager.Target = target;

            var canCast = (this.Resource - damager.Cost) > -1;
            Console.WriteLine("{0} ... {1} : {2} \n", canCast, this.Resource, damager.Cost);

            // Is there enough resource associated with this ability
            if (!canCast)
            {
                return;
            }

            ability.Execute();
            this.Resource -= damager.Cost;
        }

        /// <summary>
        /// TODO The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return this.Name + " the Cactuar";
        }

        /// <summary>
        /// Take damage from a specific damager interface.
        /// </summary>
        /// <param name="damager">
        /// The damager.
        /// </param>
        public void TakeDamage(IDamager damager)
        {
            Console.WriteLine("{0} is taking damage {1}... \n", this.Name, damager.Amount);

            // Console.WriteLine(":{0}:==Before== Status {1} \n", this.Name, this.Status);
            this.Health -= damager.Amount;

            // Console.WriteLine(":{0}:Status {1} \n", this.Name, this.Status);
        }
    }
}