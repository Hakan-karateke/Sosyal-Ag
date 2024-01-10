using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using static SosyalAg.Sosyal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Drawing.Drawing2D;
using System.Text;
using System.Reflection.Metadata;

namespace SosyalAg
{
    public partial class Form1 : Form
    {
        public static List<Button> buttonKisi = new List<Button>();
        public static string? SecilenKisi;

        private Dictionary<string, Button> buttons = new Dictionary<string, Button>(); //butonlar arasýnda çizgi iþlemi için sözlük yapýsý

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //gerekli iþlemler dosyadan verilerin çekilmesi
            Sosyal.KisileriOku();
            Sosyal.BegeniOku();
            Sosyal.YorumlarOku();
            Sosyal.IliskiOku();
            Sosyal.PaylasimlariEkle();

            IliskiPuaniHesapla();

            btnEnBegeni.Hide();
            btnEnYorum.Hide();
            btngenelSiralama.Hide();
        }

        //  Ýliþki puaný hesapla
        private void IliskiPuaniHesapla()
        {
            foreach (var kisi in Sosyal.Kisiler)
            {
                int iliskiPuani = 0;

                // Begeni tablosundan ilgili kiþinin aldýðý beðeni sayýsýný hesapla
                foreach (var begeni in Sosyal.Begeniler.Where(b => b.BegeniYapanId == kisi.ID))
                {
                    iliskiPuani += begeni.BegeniTur * 5;
                }

                // Yorum tablosundan ilgili kiþinin yaptýðý yorum sayýsýný hesapla
                foreach (var yorum in Sosyal.Yorumlar.Where(y => y.YorumYapanId == kisi.ID))
                {
                    iliskiPuani += yorum.YorumTur * 10;
                }

                // Hesaplanan iliskiPuani'ni Kisi nesnesine atayabilirsiniz.
                kisi.IliskiPuani = iliskiPuani;
            }
        }

        //Sosyal að görüntüle
        private void btnSosyal_Click(object sender, EventArgs e)
        {
            ButtonOlustur();
            btnSosyal.Enabled = false;
            btnSosyal.Hide();
            Form1.ActiveForm.BackColor = Color.DarkGreen;

            btnEnBegeni.Show();
            btnEnYorum.Show();
            btngenelSiralama.Show();

        }

        // kiþileri buton þeklinde gösterme
        private void ButtonOlustur()
        {
            System.Windows.Forms.ToolTip toolTip1 = new System.Windows.Forms.ToolTip();
            Random rand = new Random();
            foreach (Kisi kisi in Kisiler)
            {
                Button button = new Button();
                button.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                button.FlatStyle = FlatStyle.Popup;
                button.BackColor = Color.GhostWhite;
                button.Name = kisi.Ad;
                button.Text = kisi.Ad;
                button.Size = new Size(100, 50);

                // Yeni konumu belirlerken üst üste gelme kontrolü yap
                bool overlap;
                do
                {
                    overlap = false;
                    button.Location = new Point(rand.Next(50, 950), rand.Next(50, 500));

                    foreach (Button existingButton in buttonKisi)
                    {
                        if (existingButton.Bounds.IntersectsWith(button.Bounds))
                        {
                            overlap = true;
                            break;
                        }
                    }
                } while (overlap);

                button.Click += new EventHandler(Btnkisi_Click);
                toolTip1.SetToolTip(button, button.Name + " Ýliþki puaný:" + kisi.IliskiPuani);
                this.Controls.Add(button);
                buttonKisi.Add(button);
                buttons.Add(button.Name, button);
            }

            ConnectButtons();
        }

        //týklanýlan kiþi bilgilerini diðer forma ilet
        public void Btnkisi_Click(object sender, EventArgs e)
        {
            Button? ks = sender as Button;
            SecilenKisi = ks?.Text;
            KisiFormu kisiFormu = new KisiFormu();
            kisiFormu.ShowDialog();

        }

        //Butonlarý baðla
        private void ConnectButtons()
        {
            foreach (Kisi kisi in Kisiler)
            {
                string BasAd = kisi.Ad;
                foreach (Kisi kisiarkadas in kisi.Arkadaslar)
                {
                    string SonAd = kisiarkadas.Ad;

                    if (buttons.ContainsKey(BasAd) && buttons.ContainsKey(SonAd))
                    {
                        Button btnStart = buttons[BasAd];
                        Button btnEnd = buttons[SonAd];

                        DrawLineBetweenButtons(btnStart, btnEnd, 2, Color.Blue);
                    }
                }

                foreach (Kisi kisiarkadas in kisi.YakinArkadaslar)
                {
                    string SonAd = kisiarkadas.Ad;

                    if (buttons.ContainsKey(BasAd) && buttons.ContainsKey(SonAd))
                    {
                        Button btnStart = buttons[BasAd];
                        Button btnEnd = buttons[SonAd];

                        DrawLineBetweenButtons(btnStart, btnEnd, 4, Color.Red);
                    }
                }

            }
        }

        //butonlar arasýnda iliþkiye göre çizgi çek
        private void DrawLineBetweenButtons(Button btn1, Button btn2, int kalýnlýk, Color renk)
        {
            Point startPoint = new Point(btn1.Left + btn1.Width / 2, btn1.Top + btn1.Height / 2);
            Point endPoint = new Point(btn2.Left + btn2.Width / 2, btn2.Top + btn2.Height / 2);

            this.Paint += (sender, e) =>
            {
                Pen pen = new Pen(renk, kalýnlýk);
                e.Graphics.DrawLine(pen, startPoint, endPoint);
            };
            this.Invalidate();
        }

        private void btngenelSiralama_Click(object sender, EventArgs e)
        {
            // Kisiler listesini iliþki puanýna göre sýrala
            var siraliKisiler = Sosyal.Kisiler.OrderByDescending(k => k.IliskiPuani);

            // MessageBox'ta kiþilerin adlarýný ve iliþki puanlarýný göster
            StringBuilder message = new StringBuilder();
            foreach (var kisi in siraliKisiler)
            {
                message.AppendLine($"{kisi.Ad}: {kisi.IliskiPuani}");
            }

            MessageBox.Show(message.ToString(), "Genel Sýralama");
        }

        private void btnEnBegeni_Click(object sender, EventArgs e)
        {
            // Begeniler listesini beðeni sayýsýna göre grupla ve en çok beðeni alanlarý bul
            var enCokBegeniAlan = Sosyal.Begeniler
                .GroupBy(b => b.BegeniYapanId)
                .OrderByDescending(g => g.Count())
                .Take(3)
                .Select(g => new
                {
                    KisiId = g.Key,
                    BegeniSayisi = g.Count()
                });

            // MessageBox'ta en çok beðeni alan kiþilerin bilgilerini göster
            StringBuilder message = new StringBuilder();
            foreach (var begeniAlan in enCokBegeniAlan)
            {
                var kisi = Sosyal.Kisiler.FirstOrDefault(k => k.ID == begeniAlan.KisiId);
                message.AppendLine($"{kisi?.ID,-10} {kisi?.Ad,-20} {begeniAlan.BegeniSayisi}");
            }

            MessageBox.Show(message.ToString(), "En Çok Beðeni Alan Kiþiler (Top 3)");
        }

        private void btnEnYorum_Click(object sender, EventArgs e)
        {
            // Yorumlar listesini yorum sayýsýna göre grupla ve en çok yorum alanlarý bul
            var enCokYorumAlan = Sosyal.Yorumlar
                .GroupBy(y => y.YorumYapanId)
                .OrderByDescending(g => g.Count())
                .Take(3)
                .Select(g => new
                {
                    KisiId = g.Key,
                    YorumSayisi = g.Count()
                });

            // MessageBox'ta en çok yorum alan kiþilerin bilgilerini göster
            StringBuilder message = new StringBuilder();
            foreach (var yorumAlan in enCokYorumAlan)
            {
                var kisi = Sosyal.Kisiler.FirstOrDefault(k => k.ID == yorumAlan.KisiId);
                message.AppendLine($"{kisi?.ID,-10} {kisi?.Ad,-20} {yorumAlan.YorumSayisi}");
            }

            MessageBox.Show(message.ToString(), "En Çok Yorum Alan Kiþiler (Top 3)");
        }
    }
}

