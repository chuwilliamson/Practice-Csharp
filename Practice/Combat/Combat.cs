using System.Diagnostics;
using System;
using Stats;
using System.IO;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;

namespace Combat
{
    [DataContract]
    [KnownType(typeof(Dagger))]
    [KnownType(typeof(Club))]    
    public abstract class Weapon
    {
        protected Random seed;
        [DataMember]
        public string Stat { get; set; }
        public abstract int Roll();
    }
    [DataContract]    
    public class Dagger : Weapon
    {
        [DataMember]
        public string Name { get; set; }
        public Dagger()
        {
            seed = new Random();
        }
        //1d4 damages
        //then add the stat modifier
        //dmg is rolling the weapons dice and adding the attackers stat
        public override int Roll()
        {
            return seed.Next(1, 5);
        }
    }
    [DataContract]
    public class Club : Weapon
    {
        public Club()
        {
            seed = new Random();
        }
        //1d6 damages
        public override int Roll()
        {
            return seed.Next(1, 6);
        }
    }

    [DataContract]
    //chance to hit attack roll
    public class Unit
    {
     
        public Stats.Stats Stats { get; set; }
        [DataMember]
        public Weapon Weapon { get; set; }

        public int ArmorCount { get { return 10; } set { } }
        /// <summary>
        /// is a modifier value based on Level starting at 1 and increasing by 1 every 5 levels after the first 5
        /// </summary>        

        public int Proficiency
        {
            get { return (Level / 5) + 2; }
        }
        [DataMember]
        public int Health { get; set; }
        [DataMember]
        public int Level { get; set; }
        /// <summary>
        /// is a modifier value based on Dexterity
        /// </summary>
        [DataMember]
        public int Initiative { get; set; }

        public Tuple<bool, int> Attack(Unit defender)
        {
            return Combat.Instance.RollForAttack(this, defender);
        }
        public void TakeDamage(int amount)
        {
            Health -= amount;
        }
    }

    public class Combat
    {//roll for initiative
     //roll 20d and add dex mod
        Random InitiativeSeed;
        Random AttackSeed;
        public static Combat Instance = new Combat();
        public Combat()
        {
            InitiativeSeed = new Random();
            AttackSeed = new Random();
        }
        public int Round { get; set; }
        public int RollForInitiative(Unit u1)
        {
            int roll = InitiativeSeed.Next(1, 21);
            var dex = u1.Stats.GetStat("Dexterity");
            int value = dex.Value;
            return ((value - 10) / 2) + roll;
        }

        public Tuple<bool, int> RollForAttack(Unit attacker, Unit defender)
        {
            //chance to hit
            int roll = AttackSeed.Next(1, 21);
            Stat s1 = attacker.Stats.GetStat(attacker.Weapon.Stat);
            int s2 = defender.ArmorCount;
            int playerRoll = ((s1.Value - 10) / 2) + roll;
            int abilityMod = playerRoll - roll;
            int damage = abilityMod + attacker.Weapon.Roll();
            return new Tuple<bool, int>((playerRoll > s2), damage);
        }
    }
    public class Test
    {
        public static void Run()
        {
            Stat[] unit_stats = {
                            new Stat("Strength", 15),
                            new Stat("Charisma", 10),
                            new Stat("Consitution", 10),
                            new Stat("Wisdom", 10),
                            new Stat("Dexterity", 10),
                            new Stat("Intelligence", 10),
                        };

            Stats.Stats stats = new Stats.Stats(unit_stats);
            Weapon club = new Club() { Stat = "Strength" };
            Weapon dagger = new Dagger() { Name = "dags", Stat = "Dexterity" };
            Unit u1 = new Unit() { Stats = stats, Level = 1, Weapon = club, Health = 100 };
            Unit u2 = new Unit() { Stats = stats, Level = 1, Weapon = dagger, Health = 100 };
            Unit u3 = new Unit() { Stats = stats, Level = 1, Weapon = dagger, Health = 100 };
            Unit u4 = new Unit() { Stats = stats, Level = 1, Weapon = club, Health = 100 };


            u1.Initiative = Combat.Instance.RollForInitiative(u1);
            u2.Initiative = Combat.Instance.RollForInitiative(u2);
            List<Unit> combatParty = new List<Unit>() { u1, u2 };
            combatParty.Sort((a, b) => -1 *  a.Initiative.CompareTo(b.Initiative));
            for(int i = 0; i < 20; i++)
            {
                var attack = combatParty[0].Attack(combatParty[1]);
                
                Debug.WriteLine("Hit?::{0} with Damage {1}", attack.Item1, attack.Item2);
                if(attack.Item1)
                    combatParty[0].TakeDamage(attack.Item2);
                attack = combatParty[1].Attack(combatParty[0]);
                if(attack.Item1)
                    combatParty[1].TakeDamage(attack.Item2);
                
                Utilities.Serialization.Json.Save("round 1 party " + i.ToString(), combatParty);
                

            }

            //no speed when doing initiative


        }
    }
}
