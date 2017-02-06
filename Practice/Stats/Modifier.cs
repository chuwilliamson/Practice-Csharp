using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Stats
{
    public class Modifier
    {
        public Modifier(string t, string s, int v)
        {
            type = t;
            stat = s;
            value = v;
        }
        public int value;
        public string type;
        public string stat;
    }
}
