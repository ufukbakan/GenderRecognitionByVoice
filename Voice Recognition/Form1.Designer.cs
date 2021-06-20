
namespace Voice_Recognition
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.hideButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.creditsButton = new System.Windows.Forms.Button();
            this.fileBrowser = new System.Windows.Forms.OpenFileDialog();
            this.fileLoadButton = new System.Windows.Forms.PictureBox();
            this.centerButton = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.algoComboBox = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileLoadButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.centerButton)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.title);
            this.panel1.Controls.Add(this.hideButton);
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 24);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(3, -2);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(397, 22);
            this.title.TabIndex = 1;
            this.title.Text = "Gender Recognition by Voice by Ufuk and Alican";
            this.title.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // hideButton
            // 
            this.hideButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.hideButton.FlatAppearance.BorderSize = 0;
            this.hideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hideButton.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.hideButton.ForeColor = System.Drawing.Color.White;
            this.hideButton.Location = new System.Drawing.Point(727, -23);
            this.hideButton.Name = "hideButton";
            this.hideButton.Size = new System.Drawing.Size(38, 54);
            this.hideButton.TabIndex = 0;
            this.hideButton.Text = "_";
            this.hideButton.UseVisualStyleBackColor = false;
            this.hideButton.Click += new System.EventHandler(this.hideButton_Click);
            this.hideButton.MouseEnter += new System.EventHandler(this.hideButton_MouseEnter);
            this.hideButton.MouseLeave += new System.EventHandler(this.hideButton_MouseLeave);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(765, -10);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(38, 44);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "×";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.button1_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            // 
            // creditsButton
            // 
            this.creditsButton.Location = new System.Drawing.Point(727, 410);
            this.creditsButton.Name = "creditsButton";
            this.creditsButton.Size = new System.Drawing.Size(57, 28);
            this.creditsButton.TabIndex = 2;
            this.creditsButton.Text = "Credits";
            this.creditsButton.UseVisualStyleBackColor = true;
            this.creditsButton.Click += new System.EventHandler(this.creditsButton_Click);
            // 
            // fileBrowser
            // 
            this.fileBrowser.FileName = "openFileDialog1";
            this.fileBrowser.Filter = "Wav dosyası | *.wav";
            this.fileBrowser.Title = "Bir ses dosyası seçin";
            this.fileBrowser.FileOk += new System.ComponentModel.CancelEventHandler(this.fileBrowser_FileOk);
            // 
            // fileLoadButton
            // 
            this.fileLoadButton.Image = global::Voice_Recognition.Properties.Resources.button_dosya_sec;
            this.fileLoadButton.Location = new System.Drawing.Point(319, 386);
            this.fileLoadButton.Name = "fileLoadButton";
            this.fileLoadButton.Size = new System.Drawing.Size(162, 52);
            this.fileLoadButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fileLoadButton.TabIndex = 3;
            this.fileLoadButton.TabStop = false;
            this.fileLoadButton.Click += new System.EventHandler(this.fileLoadButton_Click);
            this.fileLoadButton.MouseEnter += new System.EventHandler(this.fileLoadButton_MouseEnter);
            this.fileLoadButton.MouseLeave += new System.EventHandler(this.fileLoadButton_MouseLeave);
            // 
            // centerButton
            // 
            this.centerButton.Image = global::Voice_Recognition.Properties.Resources.button_ses_kaydet;
            this.centerButton.Location = new System.Drawing.Point(300, 125);
            this.centerButton.Name = "centerButton";
            this.centerButton.Size = new System.Drawing.Size(200, 200);
            this.centerButton.TabIndex = 1;
            this.centerButton.TabStop = false;
            this.centerButton.Click += new System.EventHandler(this.centerButton_Click);
            this.centerButton.MouseEnter += new System.EventHandler(this.centerButton_MouseEnter);
            this.centerButton.MouseLeave += new System.EventHandler(this.centerButton_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(622, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Algoritma";
            // 
            // algoComboBox
            // 
            this.algoComboBox.FormattingEnabled = true;
            this.algoComboBox.Items.AddRange(new object[] {
            "Lojistik Regresyon",
            "Rastgele Ağaç Sınıflandırıcı"});
            this.algoComboBox.Location = new System.Drawing.Point(625, 47);
            this.algoComboBox.Name = "algoComboBox";
            this.algoComboBox.Size = new System.Drawing.Size(163, 21);
            this.algoComboBox.TabIndex = 5;
            this.algoComboBox.MouseLeave += new System.EventHandler(this.algoComboBox_MouseLeave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.algoComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileLoadButton);
            this.Controls.Add(this.creditsButton);
            this.Controls.Add(this.centerButton);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Gender Recognition by Voice";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileLoadButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.centerButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button hideButton;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button creditsButton;
        private System.Windows.Forms.PictureBox centerButton;
        private System.Windows.Forms.PictureBox fileLoadButton;
        private System.Windows.Forms.OpenFileDialog fileBrowser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox algoComboBox;
    }

}

