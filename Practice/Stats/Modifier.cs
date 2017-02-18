using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Runtime.Serialization;
namespace Stats
{
    [DataContract]
    public class Modifier
    {
        public Modifier(string t, string s, int v)
        {
            type = t;
            stat = s;
            value = v;
        }
        [DataMember]
        public int value;
        [DataMember]
        public string type;
        [DataMember]
        public string stat;
    }
}
