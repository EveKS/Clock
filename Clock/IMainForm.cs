using System;
using Clock.Models;

namespace Clock
{
    public interface IMainForm
    {
        ProcessInfo ProcessInfo { set; }
        string TimeText { set; }

        event EventHandler MainFormFormClosed;
        event EventHandler MainFormLoad;

        void AddGetNICLabel(ProcessInfo processInfo);
    }
}