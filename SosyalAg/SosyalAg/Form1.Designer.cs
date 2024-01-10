namespace SosyalAg
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSosyal = new Button();
            btngenelSiralama = new Button();
            btnEnBegeni = new Button();
            btnEnYorum = new Button();
            SuspendLayout();
            // 
            // btnSosyal
            // 
            btnSosyal.BackColor = Color.DarkOrange;
            btnSosyal.Location = new Point(23, 12);
            btnSosyal.Name = "btnSosyal";
            btnSosyal.Size = new Size(127, 43);
            btnSosyal.TabIndex = 0;
            btnSosyal.Text = "Sosyal Ağı Görüntüle";
            btnSosyal.UseVisualStyleBackColor = false;
            btnSosyal.Click += btnSosyal_Click;
            // 
            // btngenelSiralama
            // 
            btngenelSiralama.BackColor = Color.DarkMagenta;
            btngenelSiralama.ForeColor = SystemColors.Info;
            btngenelSiralama.Location = new Point(218, 16);
            btngenelSiralama.Name = "btngenelSiralama";
            btngenelSiralama.Size = new Size(114, 35);
            btngenelSiralama.TabIndex = 1;
            btngenelSiralama.Text = "Genel Sıralama";
            btngenelSiralama.UseVisualStyleBackColor = false;
            btngenelSiralama.Click += btngenelSiralama_Click;
            // 
            // btnEnBegeni
            // 
            btnEnBegeni.BackColor = Color.DarkMagenta;
            btnEnBegeni.ForeColor = SystemColors.Info;
            btnEnBegeni.Location = new Point(360, 16);
            btnEnBegeni.Name = "btnEnBegeni";
            btnEnBegeni.Size = new Size(98, 39);
            btnEnBegeni.TabIndex = 2;
            btnEnBegeni.Text = "En Çok Beğeni Alan";
            btnEnBegeni.UseVisualStyleBackColor = false;
            btnEnBegeni.Click += btnEnBegeni_Click;
            // 
            // btnEnYorum
            // 
            btnEnYorum.BackColor = Color.DarkMagenta;
            btnEnYorum.ForeColor = SystemColors.Info;
            btnEnYorum.Location = new Point(505, 16);
            btnEnYorum.Name = "btnEnYorum";
            btnEnYorum.Size = new Size(98, 39);
            btnEnYorum.TabIndex = 3;
            btnEnYorum.Text = "En Çok Yorum Alan";
            btnEnYorum.UseVisualStyleBackColor = false;
            btnEnYorum.Click += btnEnYorum_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(1037, 571);
            Controls.Add(btnEnYorum);
            Controls.Add(btnEnBegeni);
            Controls.Add(btngenelSiralama);
            Controls.Add(btnSosyal);
            ForeColor = SystemColors.ControlText;
            Name = "Form1";
            Text = "Sosyal";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnSosyal;
        private Button btngenelSiralama;
        private Button btnEnBegeni;
        private Button btnEnYorum;
    }
}
