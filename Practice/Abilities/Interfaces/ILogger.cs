using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abilities
{
    public interface ILogger
    {
        void Log(string value);
        void LogError(string value);
        void LogException(string value);
        void LogFormat(string value);
        void LogWarning(string value);        
        /*
IsLogTypeAllowed Check logging is enabled based on the LogType.
Log Logs message to the Unity Console using default logger.
LogError A variant of ILogger.Log that logs an error message.
LogException    A variant of ILogger.Log that logs an exception message.
LogFormat Logs a formatted message.
LogWarning A variant of Logger.Log that logs an warning message.
         */
    }
}
