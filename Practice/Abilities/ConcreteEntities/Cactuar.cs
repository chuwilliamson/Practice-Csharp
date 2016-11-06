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
    public class Cactuar : Entity, IDamageable
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
            this.Abilities.Add("vanish", new Vanish());
            this.Abilities.Add("needle", new ThousandNeedles(1000, 1000));
            this.Abilities.Add("grenade", new Grenade(5, 25));
            this.Abilities.Add("heal", new Cura(100, 19));
        }

        /// <summary>
        /// TODO The status.
        /// </summary>
        public string Status => "Health::" + this.Health + " Resource::" + this.Resource + " ";

        /// <summary>
        /// TODO The add.
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
        public override void Cast(string name)
        {
            this.Cast(name, null);
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
            if (!this.Abilities.ContainsKey(name))
            {
                throw new NotImplementedException();
            }

            // Console.WriteLine(":{0}:==Before== Status {1} \n", this.Name, this.Status);

            // cast the ability as a damager if it's null then 
            // it is a default ability
            var damager = this.Abilities[name] as IDamager;
            var buffer = this.Abilities[name] as IBuffer;
            if (damager == null)
            {
                this.Abilities[name].Execute();
                return;
            }

            damager.Target = target;
            var canCast = (this.Resource - damager.Cost) > 0;

            if (!canCast)
            {
                return;
            }

            this.Abilities[name].Execute();
            this.Resource -= damager.Cost;


            // Console.WriteLine(":{0}:==After== Status {1} \n", this.Name, this.Status);
        }

        /// <summary>
        /// The take damage.
        /// </summary>
        /// <param name="damager">
        /// The damager.
        /// </param>
        public void TakeDamage(IDamager damager)
        {
            Console.WriteLine("{0} is taking damage {1}... \n", this.Name, damager.Amount);

            // Console.WriteLine(":{0}:==Before== Status {1} \n", this.Name, this.Status);
            this.Health -= damager.Amount;

            Console.WriteLine(":{0}:Status {1} \n", this.Name, this.Status);
        }
    }
}