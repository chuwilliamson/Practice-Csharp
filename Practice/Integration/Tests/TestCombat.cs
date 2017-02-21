using Combat;
using RPGStats;

namespace Integration.Tests
{
    public class TestCombat
    {
        public TestCombat()
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

            RPGStats.Stats stats = new RPGStats.Stats(unit_stats);

            Weapon club = new Club() { StatName = "Strength" };
            Weapon dagger = new Dagger() { Name = "dags", StatName = "Dexterity" };

            Unit u1 = new Unit() { Name = "Logan", Stats = stats, Level = 1, Weapon = club, Health = 100 };
            Unit u2 = new Unit() { Name = "Matthew", Stats = stats, Level = 1, Weapon = dagger, Health = 100 };
            Unit u3 = new Unit() { Name = "Dylan", Stats = stats, Level = 1, Weapon = dagger, Health = 100 };
            Unit u4 = new Unit() { Name = "BobRoss", Stats = stats, Level = 1, Weapon = club, Health = 1000 };
            Combat.Combat.Instance.AddParticipant(u1, u2, u3, u4);
            Combat.Combat.Instance.StartCombat();


            for(int i = 0; i < 120; i++)
            {
                Combat.Combat.Instance.Resolve();
                Combat.Combat.Instance.ShowCombatLog();
            }
        }
    }
}
