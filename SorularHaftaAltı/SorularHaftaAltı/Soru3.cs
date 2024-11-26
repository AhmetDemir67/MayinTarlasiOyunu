using System;

class ZamanFarki
{
    // İlk metod: İki tarih arasındaki farkı gün olarak hesaplar.
    public int FarkHesapla(DateTime tarih1, DateTime tarih2)
    {
        TimeSpan fark = tarih2 - tarih1;  // Tarihler arasındaki farkı TimeSpan türünde hesaplıyoruz.
        return (int)fark.TotalDays;  // Farkı gün cinsinden döndürüyoruz (TotalDays kullanarak).
    }

    // İkinci metod: Tarihler arasındaki farkı saat cinsinden hesaplar.
    public double FarkHesapla(DateTime tarih1, DateTime tarih2, bool saatBazinda)
    {
        TimeSpan fark = tarih2 - tarih1;  // Tarihler arasındaki farkı TimeSpan türünde hesaplıyoruz.
        return fark.TotalHours;  // Farkı saat cinsinden döndürüyoruz (TotalHours kullanarak).
    }

    // Üçüncü metod: Tarihler arasındaki farkı yıl, ay ve gün cinsinden hesaplar.
    public (int yil, int ay, int gun) FarkHesapla(DateTime tarih1, DateTime tarih2)
    {
        int yilFarki = tarih2.Year - tarih1.Year;  // Yıl farkını hesaplıyoruz.
        int ayFarki = tarih2.Month - tarih1.Month;  // Ay farkını hesaplıyoruz.
        int gunFarki = tarih2.Day - tarih1.Day;  // Gün farkını hesaplıyoruz.

        // Eğer gün farkı negatifse, bir önceki ayı dikkate alarak düzeltme yapıyoruz.
        if (gunFarki < 0)
        {
            ayFarki--;  // Ay farkını bir azaltıyoruz.
            gunFarki += DateTime.DaysInMonth(tarih2.Year, tarih2.Month);  // Gün farkına, yeni ayın gün sayısını ekliyoruz.
        }

        // Eğer ay farkı negatifse, bir önceki yılı dikkate alarak düzeltme yapıyoruz.
        if (ayFarki < 0)
        {
            yilFarki--;  // Yıl farkını bir azaltıyoruz.
            ayFarki += 12;  // Ay farkına 12 ay ekliyoruz.
        }

        // Yıl, ay ve gün farklarını bir tuple (iki veya daha fazla değeri bir arada tutan veri yapısı) olarak döndürüyoruz.
        return (yilFarki, ayFarki, gunFarki);
    }
}

class Soru3
{
    static void Main(string[] args)
    {
        ZamanFarki zamanFarki = new ZamanFarki();  // ZamanFarki sınıfından bir nesne oluşturuyoruz.

        DateTime tarih1 = new DateTime(2020, 1, 1);  // İlk tarihi oluşturuyoruz (1 Ocak 2020).
        DateTime tarih2 = new DateTime(2023, 5, 15);  // İkinci tarihi oluşturuyoruz (15 Mayıs 2023).

        // İlk metodun kullanımı: Gün cinsinden farkı hesaplıyoruz.
        int gunFarki = zamanFarki.FarkHesapla(tarih1, tarih2);
        Console.WriteLine($"Gün cinsinden fark: {gunFarki} gün");  // Sonucu ekrana yazdırıyoruz.

        // İkinci metodun kullanımı: Saat cinsinden farkı hesaplıyoruz.
        double saatFarki = zamanFarki.FarkHesapla(tarih1, tarih2, true);
        Console.WriteLine($"Saat cinsinden fark: {saatFarki} saat");  // Sonucu ekrana yazdırıyoruz.

        // Üçüncü metodun kullanımı: Yıl, ay ve gün cinsinden farkı hesaplıyoruz.
        var tarihFarki = zamanFarki.FarkHesapla(tarih1, tarih2);
        Console.WriteLine($"Yıl, Ay, Gün cinsinden fark: {tarihFarki.yil} yıl, {tarihFarki.ay} ay, {tarihFarki.gun} gün");
        // Sonucu ekrana yazdırıyoruz. Tuple (yıl, ay, gün) formatında yazdırıyoruz.

        
        Console.ReadKey(); 
    }
}
