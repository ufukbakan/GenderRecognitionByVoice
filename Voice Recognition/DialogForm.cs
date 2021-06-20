using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Voice_Recognition
{
    public partial class DialogForm : Form
    {
        // Ekranı sürüklemek için user32dll fonksiyonları:
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int IParam);

        public DialogForm(string message)
        {
            InitializeComponent();
            if (message.Trim().ToLower() == "male")
                content.Text = "Sesinizin özellikleri sol tarafta gösterilmiştir. Tahminimize göre siz bir erkeksiniz.";
            else
                content.Text = "Sesinizin özellikleri sol tarafta gösterilmiştir. Tahminimize göre siz bir kadınsınız.";
            featuresPic.Image = Image.FromFile("Features.jpg");
        }

        private void DialogForm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.BackColor = Color.Red;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(base.Handle, 0x112, 0xf012, 0);
            }
        }
    }
}
