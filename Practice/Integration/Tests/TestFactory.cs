using System;


namespace Integration
{
 
    public enum TestType
    {
        ABILITY,
        STATS,
        COMBAT,
    }
    public class TestFactory
    { 
        public TestFactory(TestType t)
        { 
            switch(t)
            {
                case TestType.STATS: 
                    break;
                case TestType.ABILITY:        
                    break;
                case TestType.COMBAT:                    
                default:
                    break;
            }
        }

 
    }
}
