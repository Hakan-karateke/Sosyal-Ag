namespace SosyalAg
{
    partial class KisiFormu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelName = new Label();
            btnArkadasOner = new Button();
            btnArkadasGoster = new Button();
            button3 = new Button();
            btnArkadasEkle = new Button();
            dataGridPaylasimlar = new DataGridView();
            PaylasimId = new DataGridViewTextBoxColumn();
            BegeniSayisi = new DataGridViewTextBoxColumn();
            YorumSayisi = new DataGridViewTextBoxColumn();
            dataGridArkadas = new DataGridView();
            ArkadasId = new DataGridViewTextBoxColumn();
            PaylasımSayisi = new DataGridViewTextBoxColumn();
            ArkadasAdi = new DataGridViewTextBoxColumn();
            İliskiPuani = new DataGridViewTextBoxColumn();
            ArkadasTuru = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridPaylasimlar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridArkadas).BeginInit();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Viner Hand ITC", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelName.Location = new Point(62, 28);
            labelName.Name = "labelName";
            labelName.Size = new Size(92, 44);
            labelName.TabIndex = 0;
            labelName.Text = "label1";
            // 
            // btnArkadasOner
            // 
            btnArkadasOner.BackColor = Color.Coral;
            btnArkadasOner.Location = new Point(102, 80);
            btnArkadasOner.Name = "btnArkadasOner";
            btnArkadasOner.Size = new Size(96, 35);
            btnArkadasOner.TabIndex = 1;
            btnArkadasOner.Text = "Arkadaş Öner";
            btnArkadasOner.UseVisualStyleBackColor = false;
            btnArkadasOner.Click += btnArkadasOner_Click;
            // 
            // btnArkadasGoster
            // 
            btnArkadasGoster.BackColor = Color.Coral;
            btnArkadasGoster.Location = new Point(238, 80);
            btnArkadasGoster.Name = "btnArkadasGoster";
            btnArkadasGoster.Size = new Size(110, 35);
            btnArkadasGoster.TabIndex = 2;
            btnArkadasGoster.Text = "Arkadaş Göster";
            btnArkadasGoster.UseVisualStyleBackColor = false;
            btnArkadasGoster.Click += btnArkadasGoster_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Gold;
            button3.Location = new Point(400, 76);
            button3.Name = "button3";
            button3.Size = new Size(117, 43);
            button3.TabIndex = 3;
            button3.Text = "Arkadaş Çıkarma Öner";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // btnArkadasEkle
            // 
            btnArkadasEkle.BackColor = Color.YellowGreen;
            btnArkadasEkle.Location = new Point(564, 76);
            btnArkadasEkle.Name = "btnArkadasEkle";
            btnArkadasEkle.Size = new Size(117, 43);
            btnArkadasEkle.TabIndex = 4;
            btnArkadasEkle.Text = "Arkadaş Ekle";
            btnArkadasEkle.UseVisualStyleBackColor = false;
            btnArkadasEkle.Click += btnArkadasEkle_Click;
            // 
            // dataGridPaylasimlar
            // 
            dataGridPaylasimlar.AllowUserToAddRows = false;
            dataGridPaylasimlar.AllowUserToDeleteRows = false;
            dataGridPaylasimlar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridPaylasimlar.Columns.AddRange(new DataGridViewColumn[] { PaylasimId, BegeniSayisi, YorumSayisi });
            dataGridPaylasimlar.Location = new Point(34, 164);
            dataGridPaylasimlar.Name = "dataGridPaylasimlar";
            dataGridPaylasimlar.ReadOnly = true;
            dataGridPaylasimlar.Size = new Size(343, 150);
            dataGridPaylasimlar.TabIndex = 5;
            // 
            // PaylasimId
            // 
            PaylasimId.HeaderText = "Paylasım Id";
            PaylasimId.Name = "PaylasimId";
            PaylasimId.ReadOnly = true;
            // 
            // BegeniSayisi
            // 
            BegeniSayisi.HeaderText = "Beğeni Sayısı";
            BegeniSayisi.Name = "BegeniSayisi";
            BegeniSayisi.ReadOnly = true;
            // 
            // YorumSayisi
            // 
            YorumSayisi.HeaderText = "Yorum Sayısı";
            YorumSayisi.Name = "YorumSayisi";
            YorumSayisi.ReadOnly = true;
            // 
            // dataGridArkadas
            // 
            dataGridArkadas.AllowUserToAddRows = false;
            dataGridArkadas.AllowUserToDeleteRows = false;
            dataGridArkadas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridArkadas.Columns.AddRange(new DataGridViewColumn[] { ArkadasId, PaylasımSayisi, ArkadasAdi, İliskiPuani, ArkadasTuru });
            dataGridArkadas.Location = new Point(400, 164);
            dataGridArkadas.Name = "dataGridArkadas";
            dataGridArkadas.ReadOnly = true;
            dataGridArkadas.Size = new Size(537, 150);
            dataGridArkadas.TabIndex = 6;
            // 
            // ArkadasId
            // 
            ArkadasId.HeaderText = "Arkadaş Id";
            ArkadasId.Name = "ArkadasId";
            ArkadasId.ReadOnly = true;
            // 
            // PaylasımSayisi
            // 
            PaylasımSayisi.HeaderText = "PaylasimSayisi";
            PaylasımSayisi.Name = "PaylasımSayisi";
            PaylasımSayisi.ReadOnly = true;
            // 
            // ArkadasAdi
            // 
            ArkadasAdi.HeaderText = "Arkadaş Adı";
            ArkadasAdi.Name = "ArkadasAdi";
            ArkadasAdi.ReadOnly = true;
            // 
            // İliskiPuani
            // 
            İliskiPuani.HeaderText = "İlişki Puanı";
            İliskiPuani.Name = "İliskiPuani";
            İliskiPuani.ReadOnly = true;
            // 
            // ArkadasTuru
            // 
            ArkadasTuru.HeaderText = "Arkadaş Türü";
            ArkadasTuru.Name = "ArkadasTuru";
            ArkadasTuru.ReadOnly = true;
            // 
            // KisiFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(959, 492);
            Controls.Add(dataGridArkadas);
            Controls.Add(dataGridPaylasimlar);
            Controls.Add(btnArkadasEkle);
            Controls.Add(button3);
            Controls.Add(btnArkadasGoster);
            Controls.Add(btnArkadasOner);
            Controls.Add(labelName);
            Name = "KisiFormu";
            Text = "KisiFormu";
            Load += KisiFormu_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridPaylasimlar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridArkadas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelName;
        private Button btnArkadasOner;
        private Button btnArkadasGoster;
        private Button button3;
        private Button btnArkadasEkle;
        private DataGridView dataGridPaylasimlar;
        private DataGridViewTextBoxColumn PaylasimId;
        private DataGridViewTextBoxColumn BegeniSayisi;
        private DataGridViewTextBoxColumn YorumSayisi;
        private DataGridView dataGridArkadas;
        private DataGridViewTextBoxColumn ArkadasId;
        private DataGridViewTextBoxColumn PaylasımSayisi;
        private DataGridViewTextBoxColumn ArkadasAdi;
        private DataGridViewTextBoxColumn İliskiPuani;
        private DataGridViewTextBoxColumn ArkadasTuru;
    }
}