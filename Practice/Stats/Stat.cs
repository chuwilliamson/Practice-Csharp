using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stats
{
    public class Stat
    {
        public Stat(string n, int v)
        {
            name = n;
            value = v;
            base_value = v;
        }

        string name;
        int value;
        readonly int base_value;

        public string Name
        {
            get
            {
                return name;
            }
        }
        public int Value
        {
            get
            {
                return value;
            }
        }

        public void Apply(Modifier mod)
        {
            if(mod.type == "add")
                value += base_value + mod.value;
            if(mod.type == "mult")
                value += base_value * mod.value / 10;
        }

        public void Remove(Modifier mod)
        {
            if(mod.type == "add")
                value -= base_value + mod.value;
            if(mod.type == "mult")
                value -= base_value * mod.value / 10;
        }
    }
}
