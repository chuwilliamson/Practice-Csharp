using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abilities
{
    interface ICaster
    {
        /// <summary>
        /// The cast.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        void Cast(string name);
    }
}
