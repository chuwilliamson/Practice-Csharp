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

        public string Name { get; set; }
        public Stats.Stats Stats { get; set; }
        [DataMember]
        public Weapon Weapon { get; set; }
        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }
        public override int GetHashCode()
        {
            return Weapon.GetHashCode() + Name.GetHashCode();
        }
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
        private Random InitiativeSeed;
        private Random AttackSeed;
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
            int damage = playerRoll - roll + attacker.Weapon.Roll();
            return new Tuple<bool, int>((playerRoll > s2), damage);
        }

        public void StartCombat()
        {
            foreach(var unit in Participants)
                unit.Initiative = RollForInitiative(unit);
            Participants.Sort((a, b) => -1 * a.Initiative.CompareTo(b.Initiative));
        }
        public void Resolve()
        {
            Random r = new Random();
            
            foreach(var unit in Participants)
            {
                var target = Participants[r.Next(0, Participants.Count)];
                if(unit.Health > 0 )
                {
                    while(target == unit || target.Health <= 0)                    
                        target = Participants[r.Next(0, Participants.Count)];
                    
                    var attack = unit.Attack(target);

                    if(attack.Item1)
                    {
                        target.TakeDamage(attack.Item2);
                        Debug.WriteLine("{0} Hit?::{1} {2} with Damage {3}", unit.Name, target.Name, attack.Item1, attack.Item2);
                    }
                    else                    
                        Debug.WriteLine("{0} MISS!!{1} ", unit.Name, target.Name, attack.Item1);
                    
                }                
            }
        }

        public void ShowCombatLog()
        {
            Debug.WriteLine("\n=========COMBAT LOG==============");
            foreach(var u in Participants)
            {
                Debug.WriteLine(string.Format("Name: {0} Health: {1} ", u.Name, u.Health));
            }
            Debug.WriteLine("=========COMBAT LOG==============\n");
        }

        

        public void AddParticipant(params Unit[] u)
        {
            if(Participants == null)
                Participants = new List<Unit>();
            Participants.AddRange(u);
        }
        List<Unit> Participants { get; set; }
    }
    public class Test
    {
        public static void Run()
        {
            Stat[] unit_stats = 
            {
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

            Unit u1 = new Unit() { Name = "Logan", Stats = stats, Level = 1, Weapon = club, Health = 100 };
            Unit u2 = new Unit() { Name = "Matthew", Stats = stats, Level = 1, Weapon = dagger, Health = 100 };
            Unit u3 = new Unit() { Name = "Dylan", Stats = stats, Level = 1, Weapon = dagger, Health = 100 };
            Unit u4 = new Unit() { Name = "BobRoss", Stats = stats, Level = 1, Weapon = club, Health = 1000 };
            Combat.Instance.AddParticipant(u1, u2, u3, u4);
            Combat.Instance.StartCombat();


            for(int i = 0; i < 120; i++)
            {
                Combat.Instance.Resolve();
                Combat.Instance.ShowCombatLog();
            }
        }
    }
}
