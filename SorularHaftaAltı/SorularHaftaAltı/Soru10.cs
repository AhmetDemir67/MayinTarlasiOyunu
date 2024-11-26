using System;

// GPS konumu temsil eden struct (yapı) tanımlanıyor.
struct GPSKonum
{
    // Latitude (enlem) ve Longitude (boylam) için özellikler (properties) tanımlanıyor.
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    // Yapıcı metod (constructor): Latitude ve Longitude değerlerini alır.
    public GPSKonum(double latitude, double longitude)
    {
        Latitude = latitude;  // Latitude (enlem) değeri atanır.
        Longitude = longitude; // Longitude (boylam) değeri atanır.
    }

    // Mesafe hesaplama metodu: İki GPS konumu arasındaki mesafeyi hesaplar.
    public static double MesafeHesapla(GPSKonum konum1, GPSKonum konum2)
    {
        const double R = 6371; // Dünya'nın yarıçapı kilometre cinsinden. Haversine formülünde kullanılır.

        // GPS koordinatlarını derece cinsinden radyana dönüştürmek için DereceyeGonvert metodunu çağırıyoruz.
        double lat1Rad = DereceyeGonvert(konum1.Latitude); // konum1'in enlemi (Latitude) radiana çevriliyor.
        double lon1Rad = DereceyeGonvert(konum1.Longitude); // konum1'in boylamı (Longitude) radiana çevriliyor.
        double lat2Rad = DereceyeGonvert(konum2.Latitude); // konum2'nin enlemi (Latitude) radiana çevriliyor.
        double lon2Rad = DereceyeGonvert(konum2.Longitude); // konum2'nin boylamı (Longitude) radiana çevriliyor.

        // Enlem ve boylam farkları hesaplanıyor.
        double deltaLat = lat2Rad - lat1Rad; // Enlem farkı (radyan cinsinden)
        double deltaLon = lon2Rad - lon1Rad; // Boylam farkı (radyan cinsinden)

        // Haversine formülünün ilk kısmı (a) hesaplanıyor.
        double a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                   Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
                   Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);

        // Haversine formülünün ikinci kısmı (c) hesaplanıyor.
        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        // Dünya'nın yarıçapı ile mesafe hesaplanıyor.
        double mesafe = R * c;

        return mesafe; // Hesaplanan mesafe döndürülüyor.
    }

    // Dereceyi radiana dönüştüren metod. Dereceyi 180 ile böler ve pi ile çarpar.
    private static double DereceyeGonvert(double derece)
    {
        return Math.PI * derece / 180.0; // Dereceyi radiana dönüştürme formülü.
    }
}

class Soru10
{
    static void Main(string[] args)
    {
        // İki GPS konumu oluşturuluyor:
        // Birinci konum: 40.748817, -73.985428 (New York, Empire State Building)
        GPSKonum konum1 = new GPSKonum(40.748817, -73.985428);

        // İkinci konum: 51.5074, -0.1278 (Londra)
        GPSKonum konum2 = new GPSKonum(51.5074, -0.1278);

        // GPS konumları arasındaki mesafe hesaplanıyor.
        double mesafe = GPSKonum.MesafeHesapla(konum1, konum2);

        // Hesaplanan mesafe ekrana yazdırılıyor. Format: 2 ondalıklı
        Console.WriteLine($"İki konum arasındaki mesafe: {mesafe:F2} kilometre");

      
        Console.ReadKey(); 
    }
}
