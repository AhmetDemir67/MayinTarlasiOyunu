using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Oyunnn
{
    // Mayin_tarlasi (Mayın Tarlası) sınıfı, oyundaki mayın tarlasını temsil eder.
    class Mayin_tarlasi
    {
        // Mayın tarlasının boyutunu (genişlik ve yükseklik) tutar.
        Size buyukluk_;

        // Mayınların listesi.
        List<Mayin> mayinlar;

        // Mayın sayısını tutar.
        int dolu_mayin_sayisi;

        // Rastgele sayılar üretmek için kullanılan Random nesnesi.
        Random rnd = new Random();

        // Constructor (Yapıcı metod), mayın tarlasını verilen boyut ve mayın sayısı ile başlatır.
        public Mayin_tarlasi(Size buyukluk, int mayin_Sayisi)
        {
            // Mayınlar listesini başlat.
            mayinlar = new List<Mayin>();

            // Mayın sayısını ayarla.
            dolu_mayin_sayisi = mayin_Sayisi;

            // Mayın tarlasının boyutunu ayarla.
            buyukluk_ = buyukluk;

            // Mayın tarlasını 20x20'lik bir grid (ızgara) ile doldur.
            for (int x = 0; x < buyukluk.Width; x = x + 20)
            {
                for (int y = 0; y < buyukluk.Height; y = y + 20)
                {
                    // Her 20x20'lik noktada bir mayın oluştur.
                    Mayin m = new Mayin(new Point(x, y));
                    // Mayını mayınlar listesine ekle.
                    Mayin_ekle(m);
                }
            }

            // Mayınları rastgele yerleştir.
            Mayinlari_doldur();
        }

        // Bir mayını mayınlar listesine ekler.
        public void Mayin_ekle(Mayin m)
        {
            mayinlar.Add(m);
        }

        // Mayınları rastgele yerleştiren metod.
        private void Mayinlari_doldur()
        {
            int sayi = 0;
            while (sayi < dolu_mayin_sayisi)
            {
                // Listeden rastgele bir indeks seç.
                int i = rnd.Next(0, mayinlar.Count);
                Mayin item = mayinlar[i];

                // Eğer o noktada henüz mayın yoksa, mayın yerleştir ve sayacı artır.
                if (item.mayin_var_mi == false)
                {
                    item.mayin_var_mi = true;
                    sayi++;
                }
            }
        }

        // Mayın tarlasının boyutunu döndüren property (özellik).
        public Size buyuklugu
        {
            get
            {
                return buyukluk_;
            }
        }

        // Verilen lokasyonda bir mayın var mı diye bakar.
        public Mayin mayin_al_loc(Point loc)
        {
            // Mayınlar listesinde gezin ve verilen lokasyonda mayın arayarak bul.
            foreach (Mayin item in mayinlar)
            {
                if (item.konum_al == loc)
                {
                    return item;
                }
            }
            // Eğer verilen lokasyonda mayın yoksa, null döner.
            return null;
        }

        // Mayın tarlasındaki tüm mayınları döndüren property.
        public List<Mayin> GetAllMayin
        {
            get
            {
                return mayinlar;
            }
        }

        // Mayın tarlasındaki toplam mayın sayısını döndüren property.
        public int toplam_mayin_sayisi
        {
            get
            {
                return dolu_mayin_sayisi;
            }
        }

        // Mayın tarlasının toplam alanını hesaplar (toplam hücre sayısı).
        public int toplam_alan
        {
            get
            {
                // Tarlasındaki toplam hücre sayısını hesaplamak için genişlik * yükseklik / 400 (her hücre 20x20'dir).
                return (buyukluk_.Width * buyukluk_.Height) / 400;
            }
        }
    }
}
