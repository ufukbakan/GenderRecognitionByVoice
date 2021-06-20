using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Voice_Recognition
{
    public partial class Form1 : Form
    {
        Thread backgroundThread = new Thread(new ParameterizedThreadStart(PredictGenre));

        private delegate void voidDelegate();
        //static Semaphore semaph = new Semaphore(1, 1);
        static string predictThatFile;

        public Form1()
        {
            InitializeComponent();
            algoComboBox.SelectedIndex = 0;
        }

        // Ekranı sürüklemek için user32dll fonksiyonları:
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int IParam);

        // Ses kaydetmek için winmdll fonksiyonu:
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int record(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

        private bool recording = false;
        private static bool predicting = false;

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(base.Handle, 0x112, 0xf012, 0);
            }
        }

        private void centerButton_MouseEnter(object sender, EventArgs e)
        {
            if (!predicting){ 
                if (recording)
                    centerButton.Image = Properties.Resources.button_kaydi_durdur_hover;
                else
                    centerButton.Image = Properties.Resources.button_ses_kaydet_hover;
            }
        }

        private void centerButton_MouseLeave(object sender, EventArgs e)
        {
            if (!predicting)
            {
                if (recording)
                    centerButton.Image = Properties.Resources.button_kaydi_durdur;
                else
                    centerButton.Image = Properties.Resources.button_ses_kaydet;
                GC.Collect(0, GCCollectionMode.Forced);
            }
        }

        private void centerButton_Click(object sender, EventArgs e)
        {
            recording = !recording;
            if (recording)
            {
                // Kaydı başlat:
                centerButton.Image = Properties.Resources.button_kaydi_durdur_hover;
                record("open new Type waveaudio Alias recsound", "", 0, 0);
                record("record recsound", "", 0, 0);
            }
            else
            {
                // Kaydı durdur:
                centerButton.Image = Properties.Resources.button_ses_kaydet_hover;
                record("save recsound recorded.wav", "", 0, 0);
                record("close recsound", "", 0, 0);
                centerButton.Image = Properties.Resources.button_tahmin_yapiliyor;
                predictThatFile = "recorded.wav";
                // Tahmini başlat:
                if (backgroundThread.ThreadState == System.Threading.ThreadState.Stopped)
                {
                    backgroundThread.Abort();
                    backgroundThread = new Thread(new ParameterizedThreadStart(PredictGenre));
                }
                backgroundThread.Start(this); // Paramatre this formun kendisi formdaki elementleri invokelamak için
            }
        }

        private async static void PredictGenre(object form)
        {
            predicting = true;
            Process pythonSc = new Process();
            pythonSc.StartInfo.FileName = "powershell";
            pythonSc.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
            ((Form1)form).Invoke(new voidDelegate(() =>{
                if (((Form1)form).algoComboBox.SelectedItem.ToString() == "Lojistik Regresyon")
                {
                    pythonSc.StartInfo.Arguments = $"-windowstyle hidden -command python TahminEt.py '{predictThatFile}' lr";
                }
                else
                    pythonSc.StartInfo.Arguments = $"-windowstyle hidden -command python TahminEt.py '{predictThatFile}' rf";
            }));
            //pythonSc.StartInfo.Arguments = $"-windowstyle hidden -command python TahminEt.py '{predictThatFile}'";
            pythonSc.StartInfo.UseShellExecute = false;
            pythonSc.StartInfo.RedirectStandardOutput = true;
            pythonSc.StartInfo.RedirectStandardInput = true;
            pythonSc.Start();
            string consoleOutput = await Task<string>.Run(() =>
            {
                string output = pythonSc.StandardOutput.ReadToEnd();
                pythonSc.WaitForExit();
                return output;
            });
            ((Form1)form).Invoke(new voidDelegate(() => {
                    new DialogForm(consoleOutput).ShowDialog((Form1)form);                
            }));
            ((Form1)form).centerButton.Image = Properties.Resources.button_ses_kaydet;
            predicting = false;
            GC.Collect(0, GCCollectionMode.Forced);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void hideButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void hideButton_MouseEnter(object sender, EventArgs e)
        {
            hideButton.BackColor = Color.DarkGray;
        }

        private void hideButton_MouseLeave(object sender, EventArgs e)
        {
            hideButton.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.BackColor = Color.Red;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void creditsButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ufuk Bakan 181180011\nAlican Sucu 171180062", "Gazi Üniversitesi");
        }

        private void fileLoadButton_MouseEnter(object sender, EventArgs e)
        {
            if (!predicting)
            {
                fileLoadButton.Image = Properties.Resources.button_dosya_sec_hover;
            }
        }

        private void fileLoadButton_MouseLeave(object sender, EventArgs e)
        {
            if (!predicting)
            {
                fileLoadButton.Image = Properties.Resources.button_dosya_sec;
                GC.Collect(0, GCCollectionMode.Forced);
            }
        }

        private void fileLoadButton_Click(object sender, EventArgs e)
        {
            fileBrowser.ShowDialog();
        }

        private void fileBrowser_FileOk(object sender, CancelEventArgs e)
        {
            centerButton.Image = Properties.Resources.button_tahmin_yapiliyor;
            predictThatFile = fileBrowser.FileName;
            // Tahmini başlat:
            if (backgroundThread.ThreadState == System.Threading.ThreadState.Stopped)
            {
                backgroundThread.Abort();
                backgroundThread = new Thread(new ParameterizedThreadStart(PredictGenre));
            }
            backgroundThread.Start(this);
        }

        private void algoComboBox_MouseLeave(object sender, EventArgs e)
        {
            centerButton.Focus();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            centerButton.Focus();
        }
    }
}
