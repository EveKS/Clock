using Clock.Managers;
using Clock.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clock.Presenters
{
    class MainPresenter
    {
        private CancellationTokenSource _ctoken;

        private readonly ITimeManager _timeManager;
        private readonly IProcessInfoService _processInfoService;
        private readonly IMainForm _view;
        private readonly ILoggerFactory _loggerFactory;

        public MainPresenter(ITimeManager timeManager,
            IProcessInfoService processInfoService,
            IMainForm view,
            ILoggerFactory loggerFactory)
        {
            _timeManager = timeManager;
            _processInfoService = processInfoService;
            _view = view;
            _loggerFactory = loggerFactory;

            _ctoken = new CancellationTokenSource();

            _timeManager.Tick += _timeManager_Tick;
            _view.MainFormLoad += _view_MainFormLoad;
            _view.MainFormFormClosed += _view_MainFormFormClosed;
        }

        private void _view_MainFormFormClosed(object sender, EventArgs e)
        {
            try
            {
                _loggerFactory.CloseProgramLogged();

                if (_processInfoService != null)
                {
                    _processInfoService.Dispose();
                }

                if (_timeManager != null)
                {
                    _timeManager.Stop();
                    _timeManager.Dispose();
                }
            }
            catch (Exception ex)
            {
                _loggerFactory.ErrorLogged(ex);
            }
        }

        private void _view_MainFormLoad(object sender, EventArgs e)
        {
            try
            {
                TaskScheduler scheduler = TaskScheduler.FromCurrentSynchronizationContext();

                _processInfoService.LoadProcessesInfo(_ctoken)
                    .ContinueWith(ant =>
                    {
                        _view.AddGetNICLabel(_processInfoService.ProcessInfo);

                        _loggerFactory.RunProgramLogged();

                        _timeManager.Start();
                    }, CancellationToken.None,
                       TaskContinuationOptions.None,
                       scheduler);
            }
            catch (Exception ex)
            {
                _loggerFactory.ErrorLogged(ex);
            }

        }

        private void _timeManager_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_processInfoService.ProcessInfo != null)
                {
                    _view.ProcessInfo = _processInfoService.ProcessInfo;
                }

                _processInfoService.LoadProcessesInfo(_ctoken);

                _view.TimeText = DateTime.Now.ToString("HH:mm:ss");
            }
            catch (Exception ex)
            {
                _loggerFactory.ErrorLogged(ex);
            }
        }
    }
}
