using Clock.Managers;
using Clock.Presenters;
using Clock.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Clock
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm form = new MainForm();
            ITimeManager timeManager = new TimeManager(1000);
            IProcessInfoService processInfoService = new ProcessInfoService();
            ILoggerFactory loggerFactory = new LoggerFactory();

            MainPresenter presenter = new MainPresenter(timeManager,
                processInfoService,
                form,
                loggerFactory);

            Application.Run(form);
        }
    }
}
