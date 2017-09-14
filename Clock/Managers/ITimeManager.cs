using System;

namespace Clock.Managers
{
    public interface ITimeManager : IDisposable
    {
        event EventHandler Tick;

        void Start();
        void Stop();
    }
}