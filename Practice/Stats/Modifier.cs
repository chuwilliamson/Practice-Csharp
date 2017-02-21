using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Runtime.Serialization;
namespace RPGStats
{
    [DataContract]
    public class Modifier
    {
        /// <summary>
        /// Modifier Object
        /// </summary>
        /// <param name="t">type of modifier mult or add</param>
        /// <param name="s">stat to modify</param>
        /// <param name="v">value to apply t to</param>
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
