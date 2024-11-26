using System;

struct Zaman
{
    // Zaman yapısının saat ve dakika özellikleri
    public int Hour { get; set; }
    public int Minute { get; set; }

    // Yapıcı metod: Geçerli saat ve dakika değerlerini ayarlar.
    // Eğer değerler geçersizse (saat 0-23, dakika 0-59 olmalı), varsayılan olarak sıfır atanır.
    public Zaman(int hour, int minute)
    {
        // Saat değerinin geçerli olup olmadığını kontrol et
        if (hour < 0 || hour > 23)
            Hour = 0; // Geçersizse, saati sıfırla
        else
            Hour = hour; // Geçerliyse, verilen saati ata

        // Dakika değerinin geçerli olup olmadığını kontrol et
        if (minute < 0 || minute > 59)
            Minute = 0; // Geçersizse, dakikayı sıfırla
        else
            Minute = minute; // Geçerliyse, verilen dakikayı ata
    }

    // Bu metod, saati ve dakikayı toplam dakikaya dönüştürür
    // Örneğin: 2 saat 30 dakika -> 2*60 + 30 = 150 dakika
    public int ToplamDakika()
    {
        return Hour * 60 + Minute; // Saatin dakikaya çevrilmesi ve dakikaların eklenmesi
    }

    // Statik metod: İki zaman arasındaki farkı hesaplar
    // Farkın mutlak değeri alınır, yani negatif farklar pozitif hale gelir
    public static int ZamanFark(Zaman zaman1, Zaman zaman2)
    {
        // Her iki zamanın toplam dakika değerlerini hesapla
        int toplamDakika1 = zaman1.ToplamDakika();
        int toplamDakika2 = zaman2.ToplamDakika();

        // Zaman farkının mutlak değerini döndür
        return Math.Abs(toplamDakika1 - toplamDakika2);
    }
}

class Soru8
{
    static void Main(string[] args)
    {
        // Zaman nesnelerinin oluşturulması
        Zaman zaman1 = new Zaman(14, 30); // Geçerli bir zaman: 14:30
        Zaman zaman2 = new Zaman(10, 15); // Geçerli bir zaman: 10:15
        Zaman zaman3 = new Zaman(25, 90); // Geçersiz zaman: 25 saat ve 90 dakika, fakat yapıcıda 0:0 olacak

        // Zamanların saat, dakika ve toplam dakika değerlerini yazdırma
        Console.WriteLine($"Zaman 1: {zaman1.Hour}:{zaman1.Minute} -> Toplam Dakika: {zaman1.ToplamDakika()}");
        Console.WriteLine($"Zaman 2: {zaman2.Hour}:{zaman2.Minute} -> Toplam Dakika: {zaman2.ToplamDakika()}");
        Console.WriteLine($"Zaman 3: {zaman3.Hour}:{zaman3.Minute} -> Toplam Dakika: {zaman3.ToplamDakika()}");

        // Zaman 1 ile Zaman 2 arasındaki farkı hesapla
        int fark = Zaman.ZamanFark(zaman1, zaman2);

        // Hesaplanan farkı ekrana yazdır
        Console.WriteLine($"\nZaman 1 ile Zaman 2 arasındaki fark: {fark} dakika.");

        Console.ReadKey();
    }
}
