using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.logging
{
    public interface ILogger
    {
        void Debug(DateTime time, string message, string additionalInfo);
        void Info(DateTime time, string message, string additionalInfo);
        void Warn(DateTime time, string message, string additionalInfo);
        void Error(DateTime time, string message, string additionalInfo);
        void Fatal(DateTime time, string message, string additionalInfo);
    }
}
