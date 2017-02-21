using System;


using System.Runtime.Serialization;
namespace Combat
{
    [DataContract]
    [KnownType(typeof(Dagger))]
    [KnownType(typeof(Club))]
    public abstract class Weapon
    {
        [DataMember]
        public string StatName { get; set; }

        protected Random seed;

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
}
