using Clock.Managers;
using Clock.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace ClockTests
{
    [TestClass]
    public class UtilityTests
    {
        #region ProcessInfoService
        [TestMethod()]
        public void ProcessInfoServiceDispose()
        {
            using (IProcessInfoService processInfoService = new ProcessInfoService())
            {
                Assert.IsInstanceOfType(processInfoService, typeof(IDisposable));
            }
        }

        [TestMethod()]
        public void ProcessInfoServiceNotNull()
        {
            using (IProcessInfoService processInfoService = new ProcessInfoService())
            {
                processInfoService.LoadProcessesInfo().Wait();
                Assert.IsNotNull(processInfoService.ProcessInfo);
            }
        }
        #endregion

        #region ProcessInfoService with Params
        private string GetProcess()
        {
            return Process.GetProcesses().FirstOrDefault().ProcessName;
        }

        [TestMethod()]
        public void ProcessInfoServiceWithParamDispose()
        {
            var process = GetProcess();

            using (IProcessInfoService processInfoService = new ProcessInfoService(process))
            {
                Assert.IsInstanceOfType(processInfoService, typeof(IDisposable));
            }
        }

        [TestMethod()]
        public void ProcessInfoServiceWithParamNotNull()
        {
            var process = GetProcess();

            using (IProcessInfoService processInfoService = new ProcessInfoService(process))
            {
                processInfoService.LoadProcessesInfo().Wait();
                Assert.IsNotNull(processInfoService.ProcessInfo);
            }
        }
        #endregion

        #region TimeManager
        [TestMethod()]
        public void TimeManagerIsDisposable()
        {
            using (ITimeManager timeManager = new TimeManager())
            {
                Assert.IsInstanceOfType(timeManager, typeof(IDisposable));
            }
        }

        [TestMethod()]
        public void TimeManagerEvent()
        {
            int timeOut = 25;
            using (ITimeManager timeManager = new TimeManager(timeOut / 2))
            {
                ManualResetEvent eventRaised = new ManualResetEvent(false);
                timeManager.Start();

                var isTrue = false;
                timeManager.Tick += (sender, e) =>
                {
                    eventRaised.Set();
                    isTrue = true;
                };
                eventRaised.WaitOne(timeOut);

                Assert.IsTrue(isTrue);
            }
        }
        #endregion
    }
}
