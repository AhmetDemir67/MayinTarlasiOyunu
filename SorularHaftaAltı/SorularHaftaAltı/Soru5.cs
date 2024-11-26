using System;
using System.Collections.Generic;

class OgrenciNotSistemi
{
    // Ders adı ve notlarını tutacak olan bir Dictionary oluşturuluyor.
    private Dictionary<string, int> derslerNotlar;

    // Yapıcı metod: OgrenciNotSistemi nesnesi oluşturulurken derslerNotlar sözlüğü başlatılıyor.
    public OgrenciNotSistemi()
    {
        derslerNotlar = new Dictionary<string, int>(); // Dersler ve notlar için boş bir Dictionary oluşturuluyor.
    }

    // Ders adlarına göre notlara erişim ve güncelleme sağlayan indexer.
    public int this[string dersAdi]
    {
        // Ders adının notunu almak için get metodu
        get
        {
            // Ders adı sözlükte varsa, ilgili notu döndür
            if (derslerNotlar.ContainsKey(dersAdi))
            {
                return derslerNotlar[dersAdi];
            }
            else
            {
                // Ders adı bulunmazsa, KeyNotFoundException hatası fırlat
                throw new KeyNotFoundException($"'{dersAdi}' adında bir ders bulunamadı.");
            }
        }
        // Ders notunu güncellemek için set metodu
        set
        {
            // Ders adı ile verilen yeni notu sözlüğe ekle veya mevcut notu güncelle
            derslerNotlar[dersAdi] = value;
        }
    }

    // Derslerin ve notların listelendiği metod
    public void DersleriListele()
    {
        Console.WriteLine("Dersler ve Notlar:");
        // Dictionary'nin her elemanını dolaşarak ders adı ve notları yazdırıyoruz.
        foreach (var ders in derslerNotlar)
        {
            Console.WriteLine($"{ders.Key}: {ders.Value}");  // Ders adı ve notu
        }
    }
}

class Soru5
{
    static void Main(string[] args)
    {
        // OgrenciNotSistemi sınıfından bir nesne oluşturuluyor
        OgrenciNotSistemi ogrenciNotSistemi = new OgrenciNotSistemi();

        // Derslere not ataması yapılıyor
        ogrenciNotSistemi["Matematik"] = 85;
        ogrenciNotSistemi["Fizik"] = 90;
        ogrenciNotSistemi["Kimya"] = 80;

        // Derslerin ve notların listelendiği metod çağrılıyor
        ogrenciNotSistemi.DersleriListele();

        // Matematik dersinin notunu sorgulama
        Console.WriteLine("\nMatematik Notu: " + ogrenciNotSistemi["Matematik"]);

        // Geçersiz bir ders adı ile sorgulama yapılıyor (Biyoloji dersi tanımlı değil)
        try
        {
            Console.WriteLine("\nBiyoloji Notu: " + ogrenciNotSistemi["Biyoloji"]);
        }
        catch (KeyNotFoundException ex)
        {
            // Hata mesajı yakalanıp ekrana yazdırılıyor
            Console.WriteLine(ex.Message);
        }

        // Matematik dersinin notu güncelleniyor
        ogrenciNotSistemi["Matematik"] = 95;
        Console.WriteLine("\nGüncellenmiş Matematik Notu: " + ogrenciNotSistemi["Matematik"]);

        // Güncellenmiş derslerin listesi tekrar yazdırılıyor
        ogrenciNotSistemi.DersleriListele();

        // Programın bitmesi için kullanıcıdan bir tuşa basması bekleniyor
        Console.WriteLine("\nÇıkmak için bir tuşa basın...");
        Console.ReadKey();
    }
}
