using System;
using Clock.Models;

namespace Clock.Services
{
    interface ILoggerFactory
    {
        void CloseProgramLogged();
        void ErrorLogged(Exception ex);
        void RunProgramLogged();
    }
}