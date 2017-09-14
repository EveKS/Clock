using Clock.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Clock
{
    public partial class MainForm : Form, IMainForm
    {
        #region Head
        private const int LABEL_WIDTH = 60;
        #endregion

        public MainForm()
        {
            InitializeComponent();

            this.Load += MainForm_Load;
            this.FormClosed += MainForm_FormClosed;

            lbMain.MouseMove += LbMain_MouseMove;
        }

        #region IMain
        public event EventHandler MainFormLoad;
        public event EventHandler MainFormFormClosed;

        public ProcessInfo ProcessInfo
        {
            set
            {
                var settextCPU = new Action(() => { tSCPU.Text = value.ProcessCPU; });
                var settextRAM = new Action(() => { tSRAM.Text = value.ProcessRAM; });
                var settextPage = new Action(() => { tSPage.Text = value.ProcessPage; });

                if (sSStatusBar.InvokeRequired)
                {
                    sSStatusBar.Invoke(settextCPU);
                    sSStatusBar.Invoke(settextRAM);
                    sSStatusBar.Invoke(settextPage);
                }
                else
                {
                    settextCPU();
                    settextRAM();
                    settextPage();
                }

                for (int i = 0; i < value.ProcessNics.Count; i++)
                {
                    var settextAction = new Action(() => { sSStatusBar.Items[String.Format("tSNIC{0}", i)].Text = value.ProcessNics[i].Value; });
                    if (sSStatusBar.InvokeRequired)
                    {
                        sSStatusBar.Invoke(settextAction);
                    }
                    else
                    {
                        settextAction();
                    }
                }
            }
        }

        public string TimeText
        {
            set
            {
                var settextTime = new Action(() => { lbMain.Text = value; });

                if (lbMain.InvokeRequired)
                {
                    lbMain.Invoke(settextTime);
                }
                else
                {
                    settextTime();
                }
            }
        }

        public void AddGetNICLabel(ProcessInfo processInfo)
        {
            var count = processInfo.ProcessNics.Count;
            for (int i = 0; i < count; i++)
            {
                sSStatusBar.Items.Add(GetNICLabel(processInfo.ProcessNics[i].Name, i));
            }
        }
        #endregion

        #region events
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MainFormFormClosed != null)
            {
                MainFormFormClosed.Invoke(this, EventArgs.Empty);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (MainFormLoad != null)
            {
                MainFormLoad.Invoke(this, EventArgs.Empty);
            }
        }

        private void LbMain_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove(e);
        }
        #endregion

        #region Transparency
        [DllImport("dwmapi.dll", PreserveSig = false)]
        static extern void DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS margins);

        [DllImport("dwmapi.dll", PreserveSig = false)]
        static extern bool DwmIsCompositionEnabled();

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (DwmIsCompositionEnabled())
            {
                // Paint the glass effect.
                var margins = new MARGINS
                {
                    Top = 10000,
                    Left = 10000
                };

                DwmExtendFrameIntoClientArea(this.Handle, ref margins);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        struct MARGINS
        {
            public int Left;
            public int Right;
            public int Top;
            public int Bottom;
        }

        #endregion

        #region Bottommost
        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,
            int X, int Y, int cx, int cy, uint uFlags);

        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 SWP_NOACTIVATE = 0x0010;

        void ToBack()
        {
            SetWindowPos(Handle, HWND_BOTTOM, 0, 0, 0, 0,
                SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ToBack();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            ToBack();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            ToBack();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            ToBack();
        }

        #endregion

        #region Move
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                return;
            }

            base.OnMouseMove(e);
        }
        #endregion

        #region Services
        private void SetAppName()
        {
            this.Text = String.Format("{0} [{1}]", Application.ProductName, Environment.MachineName);
        }

        private ToolStripStatusLabel GetNICLabel(string instanceName, int index)
        {
            ToolStripStatusLabel newLabel = new ToolStripStatusLabel
            {
                AutoSize = false,
                Width = LABEL_WIDTH,
                ToolTipText = instanceName,
                Text = string.Empty,
                BackColor = SystemColors.Control,
                ForeColor = Color.White,
                Name = String.Format("tSNIC{0}", index),
                TextAlign = ContentAlignment.MiddleRight,
                BorderSides = ToolStripStatusLabelBorderSides.All,
                BorderStyle = Border3DStyle.SunkenInner,
                Height = sSStatusBar.Items[0].Height
            };

            return newLabel;
        }
        #endregion
    }
}
