namespace Clock
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbMain = new System.Windows.Forms.Label();
            this.sSStatusBar = new System.Windows.Forms.StatusStrip();
            this.tSCPU = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSRAM = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSPage = new System.Windows.Forms.ToolStripStatusLabel();
            this.sSStatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbMain
            // 
            this.lbMain.AutoSize = true;
            this.lbMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMain.Font = new System.Drawing.Font("Tahoma", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.lbMain.ForeColor = System.Drawing.Color.White;
            this.lbMain.Location = new System.Drawing.Point(0, 0);
            this.lbMain.Name = "lbMain";
            this.lbMain.Size = new System.Drawing.Size(0, 72);
            this.lbMain.TabIndex = 1;
            this.lbMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sSStatusBar
            // 
            this.sSStatusBar.BackColor = System.Drawing.Color.Black;
            this.sSStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSCPU,
            this.tSRAM,
            this.tSPage});
            this.sSStatusBar.Location = new System.Drawing.Point(0, 67);
            this.sSStatusBar.Name = "sSStatusBar";
            this.sSStatusBar.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.sSStatusBar.ShowItemToolTips = true;
            this.sSStatusBar.Size = new System.Drawing.Size(300, 22);
            this.sSStatusBar.SizingGrip = false;
            this.sSStatusBar.TabIndex = 5;
            this.sSStatusBar.Text = "statusStrip";
            // 
            // tSCPU
            // 
            this.tSCPU.AutoSize = false;
            this.tSCPU.AutoToolTip = true;
            this.tSCPU.BackColor = System.Drawing.SystemColors.Control;
            this.tSCPU.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tSCPU.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tSCPU.ForeColor = System.Drawing.Color.White;
            this.tSCPU.Name = "tSCPU";
            this.tSCPU.Size = new System.Drawing.Size(40, 17);
            this.tSCPU.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tSCPU.ToolTipText = "CPU Utilization";
            // 
            // tSRAM
            // 
            this.tSRAM.AutoSize = false;
            this.tSRAM.AutoToolTip = true;
            this.tSRAM.BackColor = System.Drawing.SystemColors.Control;
            this.tSRAM.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tSRAM.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tSRAM.ForeColor = System.Drawing.Color.White;
            this.tSRAM.Name = "tSRAM";
            this.tSRAM.Size = new System.Drawing.Size(65, 17);
            this.tSRAM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tSRAM.ToolTipText = "Commit Charge";
            // 
            // tSPage
            // 
            this.tSPage.AutoSize = false;
            this.tSPage.BackColor = System.Drawing.SystemColors.Control;
            this.tSPage.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tSPage.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tSPage.ForeColor = System.Drawing.Color.White;
            this.tSPage.Name = "tSPage";
            this.tSPage.Size = new System.Drawing.Size(40, 17);
            this.tSPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tSPage.ToolTipText = "Page File Usage";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(300, 89);
            this.Controls.Add(this.sSStatusBar);
            this.Controls.Add(this.lbMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "MainForm";
            this.sSStatusBar.ResumeLayout(false);
            this.sSStatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMain;
        private System.Windows.Forms.StatusStrip sSStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel tSCPU;
        private System.Windows.Forms.ToolStripStatusLabel tSRAM;
        private System.Windows.Forms.ToolStripStatusLabel tSPage;
    }
}

