using System;

// Çalışan rollerini tanımlayan enum (numaralandırma).
public enum CalisanRol
{
    Müdür,    // Yönetici
    Geliştirici, // Yazılım Geliştirici
    Tasarımcı,  // Tasarımcı
    TestUzmanı  // Test Uzmanı
}

// Calisan sınıfı, çalışanla ilgili bilgileri yönetir ve maaş hesaplamaları yapar.
public class Calisan
{
    // Çalışanın rolüne göre maaş hesaplama fonksiyonu
    public decimal MaasHesapla(CalisanRol rol)
    {
        decimal maas = 0; // Maaş başlangıçta 0 olarak belirlenir.

        // Çalışan rolüne göre maaş belirlemek için switch case yapısı kullanılır.
        switch (rol)
        {
            case CalisanRol.Müdür:
                maas = 8000m; // Yönetici maaşı
                break;
            case CalisanRol.Geliştirici:
                maas = 6000m; // Yazılım geliştirici maaşı
                break;
            case CalisanRol.Tasarımcı:
                maas = 5000m; // Tasarımcı maaşı
                break;
            case CalisanRol.TestUzmanı:
                maas = 4000m; // Test uzmanı maaşı
                break;
            default:
                maas = 0m; // Geçersiz bir rol durumunda maaş 0 olarak döndürülür.
                break;
        }

        // Hesaplanan maaş geri döndürülür.
        return maas;
    }
}

class Soru13
{
    static void Main(string[] args)
    {
        // Calisan sınıfından bir nesne oluşturuluyor.
        Calisan calisan = new Calisan();

        // Çalışanların maaşları, ilgili roller için hesaplanıp ekrana yazdırılıyor.
        Console.WriteLine("Müdür maaşı: " + calisan.MaasHesapla(CalisanRol.Müdür));   // Yönetici maaşı
        Console.WriteLine("Geliştirici maaşı: " + calisan.MaasHesapla(CalisanRol.Geliştirici)); // Yazılım geliştirici maaşı
        Console.WriteLine("Tasarımcı maaşı: " + calisan.MaasHesapla(CalisanRol.Tasarımcı));  // Tasarımcı maaşı
        Console.WriteLine("Test Uzmanı maaşı: " + calisan.MaasHesapla(CalisanRol.TestUzmanı));     // Test uzmanı maaşı

        // Programın sonunda, kullanıcının çıkış yapması için bir tuşa basması beklenir.
        Console.WriteLine("\nÇıkmak için bir tuşa basın...");
        Console.ReadKey();
    }
}
