using System;
using System.Collections.Generic;
using System.Text;

namespace Core.IServices
{
    public interface ILogService
    {
        void Info(string message);
        void Error(string message);
    }
}
