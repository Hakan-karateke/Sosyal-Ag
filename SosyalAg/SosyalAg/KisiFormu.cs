using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SosyalAg.Sosyal;

namespace SosyalAg
{
    public partial class KisiFormu : Form
    {
        Kisi? SecilenKisi = null;
        public KisiFormu()
        {
            InitializeComponent();
        }

        private void KisiFormu_Load(object sender, EventArgs e)
        {
            labelName.Text = Form1.SecilenKisi;
            
            foreach (Kisi kisi in Sosyal.Kisiler)
            {
                if (kisi.Ad == Form1.SecilenKisi)
                {
                    SecilenKisi = kisi;
                }
            }

            foreach(Kisi ark in SecilenKisi.YakinArkadaslar)
            {
                dataGridArkadas.Rows.Add(ark.ID.ToString(),ark.Paylasımlar.Count.ToString(),ark.Ad,ark.IliskiPuani.ToString(),"Yakın Arkadaş");
            }
            foreach (Kisi ark in SecilenKisi.Arkadaslar)
            {
                dataGridArkadas.Rows.Add(ark.ID, ark.Paylasımlar.Count.ToString(), ark.Ad, ark.IliskiPuani.ToString(), "Normal Arkadaş");
            }

            foreach(Paylasım paylasım in SecilenKisi.Paylasımlar)
            {
                dataGridPaylasimlar.Rows.Add(paylasım.ID,paylasım.Begenenler.Count.ToString(),paylasım.Yorumlar.Count.ToString());
            }




        }

        private void btnArkadasOner_Click(object sender, EventArgs e)
        {

            if (SecilenKisi != null)
            {
                // Kullanıcının arkadaşları listesi
                List<Kisi> kullaniciArkadaslari = SecilenKisi.Arkadaslar;

                // Arkadaşların arkadaşları listesi
                List<Kisi> arkadaslarinArkadaslari = new List<Kisi>();

                // Kullanıcının arkadaşlarının arkadaşlarından arkadaş önerisi yap
                foreach (Kisi arkadas in kullaniciArkadaslari)
                {
                    arkadaslarinArkadaslari.AddRange(arkadas.Arkadaslar);
                }

                // Kullanıcının zaten arkadaşı olanları ve kendisini çıkar
                arkadaslarinArkadaslari.RemoveAll(k => kullaniciArkadaslari.Contains(k) || k == SecilenKisi);

                // Önerilen arkadaşları kullanıcıya göster
                StringBuilder message = new StringBuilder("Arkadaş Önerileri:\n");
                foreach (Kisi onerilenArkadas in arkadaslarinArkadaslari)
                {
                    message.AppendLine(onerilenArkadas.Ad);
                }

                MessageBox.Show(message.ToString(), "Arkadaş Önerileri");
            }
        }

        private void btnArkadasGoster_Click(object sender, EventArgs e)
        {

            if (SecilenKisi != null)
            {
                // Kullanıcının yakın arkadaşlarını ve arkadaşlarını göster
                StringBuilder message = new StringBuilder($"Yakın Arkadaşlar ({SecilenKisi.Ad}):\n");
                foreach (Kisi yakınArkadas in SecilenKisi.YakinArkadaslar)
                {
                    message.AppendLine(yakınArkadas.Ad);
                }

                message.AppendLine("\nDiğer Arkadaşlar:");
                foreach (Kisi arkadas in SecilenKisi.Arkadaslar)
                {
                    message.AppendLine(arkadas.Ad);
                }

                MessageBox.Show(message.ToString(), "Arkadaş Listesi");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (SecilenKisi != null)
            {
                // Kullanıcının arkadaşlarını göster
                StringBuilder message = new StringBuilder($"Arkadaşlar ({SecilenKisi.Ad}):\n");
                foreach (Kisi arkadas in SecilenKisi.Arkadaslar)
                {
                    message.AppendLine(arkadas.Ad);
                }

                // Kullanıcıya arkadaş seçme şansı ver
                string secilenArkadasAdi = Interaction.InputBox("Çıkarmak istediğiniz arkadaşın adını girin:", "Arkadaş Çıkarma", "");

                // Seçilen arkadaşı bul
                Kisi? secilenArkadas = SecilenKisi.Arkadaslar.FirstOrDefault(k => k.Ad == secilenArkadasAdi);

                // Arkadaş çıkarma işlemi
                if (secilenArkadas != null)
                {
                    SecilenKisi.Arkadaslar.Remove(secilenArkadas);
                    secilenArkadas.Arkadaslar.Remove(SecilenKisi);

                    MessageBox.Show($"{secilenArkadasAdi} arkadaşlıktan çıkarıldı.", "Arkadaş Çıkarma");
                }
                else
                {
                    MessageBox.Show($"Belirtilen isimde bir arkadaş bulunamadı.", "Hata");
                }
            }
        }

        private void btnArkadasEkle_Click(object sender, EventArgs e)
        {
            string secilenArkadasAdi = Interaction.InputBox("Eklemek istediğiniz arkadaşın adını girin:", "Arkadaş Ekle", "");

            Kisi? eklenenarkadas = SecilenKisi.Arkadaslar.FirstOrDefault(k => k.Ad == secilenArkadasAdi);
            if (eklenenarkadas == null)
            {
                eklenenarkadas = SecilenKisi.YakinArkadaslar.FirstOrDefault(k => k.Ad == secilenArkadasAdi);
            }

            if (eklenenarkadas != null)
            {
                MessageBox.Show("Bu kişi zaten arkadaşınız");
            }
            else
            {
                eklenenarkadas = Sosyal.Kisiler.FirstOrDefault(k => k.Ad == secilenArkadasAdi);
                if (eklenenarkadas == null)
                {
                    MessageBox.Show($"Belirtilen isimde bir arkadaş bulunamadı.", "Hata");
                }
                else
                {
                    SecilenKisi.Arkadaslar.Add(eklenenarkadas);
                    dataGridArkadas.Rows.Add(eklenenarkadas.ID, eklenenarkadas.Paylasımlar.Count.ToString(), eklenenarkadas.Ad, eklenenarkadas.IliskiPuani.ToString(), "Normal Arkadaş");
                }
            }


        }
    }
}
