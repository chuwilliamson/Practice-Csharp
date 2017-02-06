using Abilities;
using Stats;

namespace Integration
{
    class Program
    {
        static void Main(string[] args)
        {
            TestFactory test1 = new TestFactory(TestType.STATS);
            test1.Run();
            test1 = new TestFactory(TestType.ABILITY);
            test1.Run();
        }
    }
}
