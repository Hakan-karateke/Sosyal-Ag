using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SosyalAg.Sosyal;

namespace SosyalAg
{
    internal class Sosyal
    {

        public struct Begeni
        {
            public string BegeniId;
            public string BegeniYapanId;
            public int BegeniTur;
        }

        public struct Yorum
        {
            public string YorumId;
            public string YorumYapanId;
            public int YorumTur;
        }

        public class Kisi
        {
            public string? ID { get; set; }
            public string? Ad { get; set; }
            public string? Cinsiyet { get; set; }

            private int iliskiPuani;

            public int IliskiPuani
            {
                get { return iliskiPuani; }
                set { iliskiPuani = value; }
            }

            public List<Kisi> Arkadaslar = new List<Kisi>();
            public List<Kisi> YakinArkadaslar = new List<Kisi>();
            public List<Paylasım> Paylasımlar= new List<Paylasım> { };

        }

        public class Paylasım
        {
            public string? ID { get; set; }
            //begeni ve yorumları tutmak için listeler oluşturulmuştur
            public List<Begeni> Begenenler = new List<Begeni>();
            public List<Yorum> Yorumlar = new List<Yorum>();

            public Paylasım(string id)
            {
                ID = id;
            }

        }


        public static List<Kisi> Kisiler=new List<Kisi>();
        public static List<Begeni> Begeniler=new List<Begeni>();
        public static List<Yorum> Yorumlar=new List<Yorum>();
        public static List<Paylasım> Paylasımlar =new List<Paylasım>();
        public static void KisileriOku()
        {
            // Kisiler.txt dosyasından verileri oku ve Kisiler listesine ekle
            string[] lines = File.ReadAllLines("Kisiler.txt");
            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                Kisi kisi = new Kisi
                {
                    ID = data[0],
                    Ad = data[1],
                    Cinsiyet = data[2]
                };
                Kisiler.Add(kisi);
            }
        }

        public static void YorumlarOku()
        {
            // Yorumlar.txt dosyasından verileri oku ve Yorumlar listesine ekle
            string[] lines = File.ReadAllLines("Yorum.txt");
            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                Yorum yorum = new Yorum
                {
                    YorumId = data[0],
                    YorumYapanId = data[1],
                    YorumTur = int.Parse(data[2])
                };
                Yorumlar.Add(yorum);
            }

            for (int i = 0; i < Yorumlar.Count; i++)
            {
                string paylasimId = Yorumlar[i].YorumId;

                // Eğer aynı ID ile paylaşım yoksa yeni bir paylaşım oluştur
                if (!Sosyal.Paylasımlar.Any(p => p.ID == paylasimId))
                {
                    Paylasım paylasim = new Paylasım(paylasimId);
                    Sosyal.Paylasımlar.Add(paylasim);
                }

                // Yorum, ilgili paylaşıma eklenir
                Sosyal.Paylasımlar.First(p => p.ID == paylasimId).Yorumlar.Add(Yorumlar[i]);
            }
        }

        public static void IliskiOku()
        {
            // Iliski.txt dosyasından verileri oku ve ilgili ilişkileri oluştur
            string[] lines = File.ReadAllLines("Iliski.txt");
            for (int i = 1; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');
                Kisi kisi = Kisiler[i - 1];

                for (int j = 1; j < data.Length; j++)
                {
                    string iliskiTur = data[j];
                    if (iliskiTur == "1")
                        kisi.Arkadaslar.Add(Kisiler[j - 1]);
                    else if (iliskiTur == "2")
                        kisi.YakinArkadaslar.Add(Kisiler[j - 1]);
                }
            }
        }

        public static void BegeniOku()
        {
            // Begeni.txt dosyasından verileri oku ve Begeniler listesine ekle
            string[] lines = File.ReadAllLines("Begeni.txt");
            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                Begeni begeni = new Begeni
                {
                    BegeniId = data[0],
                    BegeniYapanId = data[1],
                    BegeniTur = int.Parse(data[2])
                };
                Begeniler.Add(begeni);
            }

            // Paylasımları oluştur
            for (int i = 0; i < Begeniler.Count; i++)
            {
                string paylasimId = Begeniler[i].BegeniId;

                // Eğer aynı ID ile paylaşım yoksa yeni bir paylaşım oluştur
                if (!Sosyal.Paylasımlar.Any(p => p.ID == paylasimId))
                {
                    Paylasım paylasim = new Paylasım(paylasimId);
                    Sosyal.Paylasımlar.Add(paylasim);
                }

                // Beğeni, ilgili paylaşıma eklenir
                Sosyal.Paylasımlar.First(p => p.ID == paylasimId).Begenenler.Add(Begeniler[i]);
            }
        }

        public static void PaylasimlariEkle()
        {
            foreach(Paylasım paylasım in Paylasımlar)
            {
                string paylasimYapanId = paylasım.ID.Substring(0, 3);
                var paylasimYapanKisi = Kisiler.FirstOrDefault(k => k.ID == paylasimYapanId);

                paylasimYapanKisi?.Paylasımlar.Add(paylasım);
            }
        }

    }
}
