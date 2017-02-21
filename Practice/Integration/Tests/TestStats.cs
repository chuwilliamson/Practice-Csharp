using RPGStats;

namespace Integration.Tests
{
    public class TestStats
    {
        public TestStats()
        {
            Stat[] unit_stats = {
                            new Stat("str", 10),
                            new Stat("int", 10),
                            new Stat("spd", 10)
                        };

            RPGStats.Stats stats = new RPGStats.Stats(unit_stats);

            stats.AddModifier(2, new Modifier("mult", "int", 2));
            stats.RemoveModifier(2);
            stats.AddModifier(3, new Modifier("mult", "int", 2));
            stats.AddModifier(4, new Modifier("mult", "int", 2));
            stats.AddModifier(5, new Modifier("mult", "int", 5));
            stats.AddModifier(6, new Modifier("mult", "int", -5));
            stats.RemoveModifier(6);
            stats.ClearModifiers();
            stats.AddModifier(3, new Modifier("mult", "int", 2));
            stats.AddModifier(4, new Modifier("mult", "int", 2));
            stats.AddModifier(5, new Modifier("mult", "int", 5));
            stats.AddModifier(6, new Modifier("mult", "int", -5));
        }
    }
}
