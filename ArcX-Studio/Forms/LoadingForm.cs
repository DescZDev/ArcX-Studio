using DarkModeForms;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ArcX_Studio
{
    public partial class LoadingForm : Form
    {
        private ProgressBar pb = null;
        const int DWMWA_BORDER_COLOR = 34;
        const int DWMWA_SYSTEMBACKDROP_TYPE = 38;
        private DarkModeCS ng = null;

        public LoadingForm(string message)
        {
            InitializeComponent();
            SetBorderColor(Color.FromArgb(0, 122, 204));
            mica();

            loadingLabel.Text = message;
            flatProgressBar1.MarqueeAnimationSpeed = 25;

            ng = new DarkModeCS(this)
            {
                ColorMode = DarkModeCS.DisplayMode.DarkMode
            };
        }

        public void UpdateStatus(string message, int percent)
        { 
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateStatus(message, percent)));
                return;
            }
            loadingLabel.Text = message;
            flatProgressBar1.Value = Math.Max(0, Math.Min(100, percent));
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {

        }

        private void flatProgressBar1_Click(object sender, EventArgs e)
        {
          
        }

        private void ShowFakeProgress() 
        {
            flatProgressBar1.Value = 0;
            flatProgressBar1.Minimum = 0;
            flatProgressBar1.Maximum = 100;
            flatProgressBar1.Step = 1;

            Timer t = new Timer();
            t.Interval = 50; // ms (speed of fill)
            t.Tick += (s, e) =>
            {
                if (flatProgressBar1.Value < 100)
                    flatProgressBar1.PerformStep();
                else
                    t.Stop(); // stop when done
            };
            t.Start();
        }


        public void UpdateProgress(int value)
        {
            if (value >= pb.Minimum && value <= pb.Maximum)
            {
                pb.Value = value;
            }
        }

        private void loadingLabel_Click(object sender, EventArgs e)
        {

        }

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int dwAttribute, ref int pvAttribute, int cbAttribute);
        private enum DWM_SYSTEMBACKDROP_TYPE
        {
            DWMSBT_AUTO = 0,
            DWMSBT_NONE = 1,
            DWMSBT_MAINWINDOW = 2,
            Acrylic = 3,
            Tabbed = 4
        }

        void SetBorderColor(Color color)
        {
            int colorRef = ColorTranslator.ToWin32(color);
            DwmSetWindowAttribute(this.Handle, DWMWA_BORDER_COLOR, ref colorRef, sizeof(int));
        }

        void mica()
        {
            int backdrop = (int)DWM_SYSTEMBACKDROP_TYPE.DWMSBT_MAINWINDOW;
            DwmSetWindowAttribute(this.Handle, DWMWA_SYSTEMBACKDROP_TYPE, ref backdrop, sizeof(int));
        }
    }
}
