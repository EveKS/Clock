using System.Threading;
using System.Threading.Tasks;
using Clock.Models;
using System;

namespace Clock.Services
{
    public interface IProcessInfoService : IDisposable
    {
        ProcessInfo ProcessInfo { get; }

        Task LoadProcessesInfo(CancellationTokenSource ctoken = null);
    }
}