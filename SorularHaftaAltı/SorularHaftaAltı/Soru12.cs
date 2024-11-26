using System;

// Hava durumu enum'ı, hava durumu çeşitlerini tanımlar.
public enum HavaDurumu
{
    Gunesli,  // Güneşli
    Yogmurlu, // Yağmurlu
    Bulutlu,  // Bulutlu
    Firtinali  // Fırtınalı
}

// Hava durumu tavsiyeleri sınıfı, hava durumu durumlarına göre tavsiyeler sunar.
public class HavaDurumuTavsiyesi
{
    // Hava durumu parametresine göre tavsiye döndüren metod.
    public string TavsiyeVer(HavaDurumu durum)
    {
        // Durum parametresine göre farklı tavsiyeler verilmekte.
        switch (durum)
        {
            case HavaDurumu.Gunesli:
                return "Güneşli hava: Dışarıda vakit geçirmek için harika bir gün!";
            case HavaDurumu.Yogmurlu:
                return "Yağmurlu hava: Şemsiye almayı unutma!";
            case HavaDurumu.Bulutlu:
                return "Bulutlu hava: Dışarıda biraz serin olabilir, yanına bir mont al.";
            case HavaDurumu.Firtinali:
                return "Fırtınalı hava: Dışarı çıkmamaya çalış, güvenli bir yerde kal!";
            default:
                return "Geçersiz hava durumu!"; // Eğer geçersiz bir değer verilirse.
        }
    }
}

class Soru12
{
    static void Main(string[] args)
    {
        // HavaDurumuTavsiyesi sınıfından bir nesne oluşturuluyor.
        HavaDurumuTavsiyesi havaTavsiyesi = new HavaDurumuTavsiyesi();

        // Farklı hava durumu koşullarına göre tavsiyeler yazdırılıyor.
        Console.WriteLine(havaTavsiyesi.TavsiyeVer(HavaDurumu.Gunesli));  // Güneşli hava tavsiyesi
        Console.WriteLine(havaTavsiyesi.TavsiyeVer(HavaDurumu.Yogmurlu)); // Yağmurlu hava tavsiyesi
        Console.WriteLine(havaTavsiyesi.TavsiyeVer(HavaDurumu.Bulutlu));  // Bulutlu hava tavsiyesi
        Console.WriteLine(havaTavsiyesi.TavsiyeVer(HavaDurumu.Firtinali)); // Fırtınalı hava tavsiyesi

        
        Console.ReadKey();
    }
}
