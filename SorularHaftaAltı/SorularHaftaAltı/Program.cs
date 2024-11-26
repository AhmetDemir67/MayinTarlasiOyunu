using System;

class Geometri
{
    // İlk sürüm: Karenin alanını hesaplar (bir kenar uzunluğu verilerek)
    public double AlanHesapla(double kenar)
    {
        return kenar * kenar;  // Karenin alanı: kenar * kenar
    }

    // İkinci sürüm: Dikdörtgenin alanını hesaplar (iki kenar uzunluğu verilerek)
    public double AlanHesapla(double uzunluk, double genislik)
    {
        return uzunluk * genislik;  // Dikdörtgenin alanı: uzunluk * genişlik
    }

    // Üçüncü sürüm: Dairenin alanını hesaplar (yarıçap verilerek)
    public double AlanHesapla(double yaricap)
    {
        return Math.PI * yaricap * yaricap;  // Dairenin alanı: π * yarıçap²
    }
}

class Program
{
    static void Main(string[] args)
    {
        Geometri geometri = new Geometri();

        // Karenin alanını hesapla (Kenarı 5 birim)
        double kareAlani = geometri.AlanHesapla(5);
        Console.WriteLine($"Karenin alanı: {kareAlani}");

        // Dikdörtgenin alanını hesapla (Uzunluğu 8, genişliği 4)
        double dikdortgenAlani = geometri.AlanHesapla(8, 4);
        Console.WriteLine($"Dikdörtgenin alanı: {dikdortgenAlani}");

        // Dairenin alanını hesapla (Yarıçapı 7 birim)
        double daireAlani = geometri.AlanHesapla(7);
        Console.WriteLine($"Dairenin alanı: {daireAlani}");

       
        Console.ReadKey();
    }
}
