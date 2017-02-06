using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abilities
{
    public class Logger : ILogger
    {        
        public Logger()
        {

        }
        
        public void Log(string value)
        {
            Console.WriteLine(value);            
        }

        public void LogError(string value)
        {
            throw new NotImplementedException();
        }

        public void LogException(string value)
        {
            throw new NotImplementedException();
        }

        public void LogFormat(string value)
        {
            throw new NotImplementedException();
        }

        public void LogWarning(string value)
        {
            throw new NotImplementedException();
        }

        public void Print(string value)
        {
            Console.WriteLine(value);
        }
    }
}
