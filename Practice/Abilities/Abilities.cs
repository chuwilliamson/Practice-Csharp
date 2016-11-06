// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Abilities.cs" company="AIE">
//   COPY
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Abilities
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The Ability interface.
    /// </summary>
    public interface IAbility
    {
        /// <summary>
        /// The execute.
        /// </summary>
        void Execute();
    }

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

    /// <summary>
    /// The Damager interface.
    /// </summary>
    public interface IDamager
    {
        /// <summary>
        /// Gets or sets the damage.
        /// </summary>
        int Damage { get; set; }

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

        /// <summary>
        /// Gets or sets the abilities.
        /// </summary>
        protected Dictionary<string, IAbility> Abilities { get; set; } = new Dictionary<string, IAbility>();

        /// <summary>
        /// The cast.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public abstract void Cast(string name);
    }

    /// <summary>
    /// The thousand needles.
    /// </summary>
    public class ThousandNeedles : IAbility
    {
        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// The execute.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("Thousand needles!! \n");
        }
    }

    /// <summary>
    /// The vanish.
    /// </summary>
    public class Vanish : IAbility
    {
        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// The execute.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("Vanish.... \n");
        }
    }

    /// <summary>
    /// The Cure Ability.
    /// </summary>
    public class Cura : IAbility
    {
        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// you didn't implement it
        /// </exception>
        public void Execute()
        {
            Console.WriteLine("Healing for {0} \n", this.Cost);
        }
    }

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
            this.Damage = damage;
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
        public int Damage { get; set; }

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
        /// The do damage.
        /// </summary>
        /// <param name="damageable">
        /// The damageable.
        /// </param>
        public void DoDamage(IDamageable damageable)
        {
            Console.WriteLine("{0} :: Damage {1} -> {2} \n", this, this.Damage, this.Target);
            damageable.TakeDamage(this);
        }
    }

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
            this.Abilities.Add("needle", new ThousandNeedles());
            this.Abilities.Add("grenade", new Grenade(5, 25));
            this.Abilities.Add("heal", new Cura());
        }

        /// <summary>
        /// TODO The status.
        /// </summary>
        public string Status => "Health::" + this.Health + " Resource::" + this.Resource + " ";

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
            Console.WriteLine("{0} is attempting to cast {1} \n", this.Name, name);

            if (!this.Abilities.ContainsKey(name))
            {
                throw new NotImplementedException();
            }

            Console.WriteLine("==Before== Status {0} \n", this.Status);

            // cast the ability as a damager if it's null then 
            // it is a default ability
            var damager = this.Abilities[name] as IDamager;

            if (damager != null)
            {
                damager.Target = target;
                this.Abilities[name].Execute();
                this.Resource -= damager.Cost;
            }
            else
            {
                this.Abilities[name].Execute();
            }

            Console.WriteLine("==After== Status {0} \n", this.Status);
        }

        /// <summary>
        /// The take damage.
        /// </summary>
        /// <param name="damager">
        /// The damager.
        /// </param>
        public void TakeDamage(IDamager damager)
        {
            Console.WriteLine("{0} is taking damage \n", this.Name);
            this.Health -= damager.Damage;
        }
    }
}