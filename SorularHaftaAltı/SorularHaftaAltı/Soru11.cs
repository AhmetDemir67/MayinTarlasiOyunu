using System;

// Trafik ışığının olası durumlarını temsil eden enum (sıralı değerler)
public enum TrafikIsigiDurumu
{
    Red,    // Kırmızı ışık
    Yellow, // Sarı ışık
    Green   // Yeşil ışık
}

// Trafik ışığı sınıfı, ışığın durumu ile ilgili açıklamalar içeriyor
public class TrafikIsigi
{
    // Trafik ışığının durumuna göre açıklama döndüren metod
    public string DurumAciklama(TrafikIsigiDurumu durum)
    {
        // Durum parametresine göre açıklama döndürülür.
        switch (durum)
        {
            case TrafikIsigiDurumu.Red:
                // Kırmızı ışık durumu
                return "Kırmızı ışık: Araçlar durmalı!";
            case TrafikIsigiDurumu.Yellow:
                // Sarı ışık durumu
                return "Sarı ışık: Dikkat et, hazırlıklı ol!";
            case TrafikIsigiDurumu.Green:
                // Yeşil ışık durumu
                return "Yeşil ışık: Geçebilirsiniz!";
            default:
                // Geçersiz bir durum girildiğinde
                return "Geçersiz ışık durumu!";
        }
    }
}

class Soru11
{
    static void Main(string[] args)
    {
        // Trafik ışığı nesnesi oluşturuluyor
        TrafikIsigi trafikIsigi = new TrafikIsigi();

        // Farklı trafik ışığı durumları için açıklamalar ekrana yazdırılıyor
        Console.WriteLine(trafikIsigi.DurumAciklama(TrafikIsigiDurumu.Red));    // Kırmızı ışık açıklaması
        Console.WriteLine(trafikIsigi.DurumAciklama(TrafikIsigiDurumu.Yellow)); // Sarı ışık açıklaması
        Console.WriteLine(trafikIsigi.DurumAciklama(TrafikIsigiDurumu.Green));  // Yeşil ışık açıklaması

        
        Console.ReadKey();
    }
}
