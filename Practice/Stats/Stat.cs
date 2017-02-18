using System.Runtime.Serialization;
using System;

namespace Stats
{
    [DataContract]
    public class Stat
    {
        public Stat() { }

        public Stat(string n, int v)
        {
            Name = n;
            Value = v;
            base_value = Value;
            OnStatAdd += Doit;
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Value { get; set; }

        [DataMember]
        private readonly int base_value;

        [IgnoreDataMember]
        public Action OnStatAdd;

        void Doit() { }

        public void Apply(Modifier mod)
        {
            if(mod.type == "add")
                Value += base_value + mod.value;
            if(mod.type == "mult")
                Value += base_value * mod.value / 10;
        }

        public void Remove(Modifier mod)
        {
            if(mod.type == "add")
                Value -= base_value + mod.value;
            if(mod.type == "mult")
                Value -= base_value * mod.value / 10;
        }
    }
}
