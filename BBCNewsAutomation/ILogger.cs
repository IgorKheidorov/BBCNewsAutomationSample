using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBCNewsAutomation
{
    internal interface ILogger
    {
        void LogError(string error);
        void LogWarning(string warning);
        void LogMessage(string message);
    }
}
