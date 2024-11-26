using System;

// Karmaşık sayılarla işlem yapacak olan Karmaşık yapısı (struct) tanımlanıyor.
struct Karmaşık
{
    // Karmaşık sayının gerçek kısmı (Real) ve sanal kısmı (Imaginary) için özellikler (properties) tanımlanıyor.
    public double Real { get; set; }
    public double Imaginary { get; set; }

    // Yapıcı metod (constructor): Karmaşık sayıyı oluştururken gerçek ve sanal kısmı alır.
    public Karmaşık(double real, double imaginary)
    {
        Real = real;       // Gerçek kısmı alır.
        Imaginary = imaginary; // Sanal kısmı alır.
    }

    // Toplama operatörü (+) aşırı yükleniyor: Bu operatör iki karmaşık sayıyı toplar.
    public static Karmaşık operator +(Karmaşık a, Karmaşık b)
    {
        // Gerçek kısımlar toplanır, sanal kısımlar toplanır ve yeni bir karmaşık sayı döndürülür.
        return new Karmaşık(a.Real + b.Real, a.Imaginary + b.Imaginary);
    }

    // Çıkarma operatörü (-) aşırı yükleniyor: Bu operatör iki karmaşık sayıyı çıkarır.
    public static Karmaşık operator -(Karmaşık a, Karmaşık b)
    {
        // Gerçek kısımlar çıkarılır, sanal kısımlar çıkarılır ve yeni bir karmaşık sayı döndürülür.
        return new Karmaşık(a.Real - b.Real, a.Imaginary - b.Imaginary);
    }

    // ToString metodu: Karmaşık sayıyı yazdırmak için biçimlendirir.
    public override string ToString()
    {
        // Karmaşık sayıyı "gerçek kısmı + sanal kısmı i" formatında döndürür.
        return $"{Real} + {Imaginary}i";
    }
}

class Soru9
{
    static void Main(string[] args)
    {
        // Karmaşık sayılar oluşturuluyor. Birinci karmaşık sayı 3 + 4i, ikinci karmaşık sayı 1 + 2i.
        Karmaşık sayi1 = new Karmaşık(3, 4);  // 3 + 4i
        Karmaşık sayi2 = new Karmaşık(1, 2);  // 1 + 2i

        // Toplama işlemi: sayi1 ile sayi2 toplanıyor.
        Karmaşık toplam = sayi1 + sayi2;
        // Sonuç yazdırılıyor. Beklenen çıktı: "4 + 6i"
        Console.WriteLine($"Toplama: {toplam}");

        // Çıkarma işlemi: sayi1 ile sayi2 çıkarılıyor.
        Karmaşık fark = sayi1 - sayi2;
        // Sonuç yazdırılıyor. Beklenen çıktı: "2 + 2i"
        Console.WriteLine($"Çıkarma: {fark}");

       
        Console.ReadKey();
    }
}
