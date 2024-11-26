using System;

class Matematik
{
    // İki sayıyı toplayan metod
    public int Topla(int sayi1, int sayi2)
    {
        return sayi1 + sayi2;  // Sayıları toplayıp sonucu döndürüyoruz
    }

    // Üç sayıyı toplayan metod
    public int Topla(int sayi1, int sayi2, int sayi3)
    {
        return sayi1 + sayi2 + sayi3;  // Üç sayıyı toplayıp sonucu döndürüyoruz
    }

    // Bir dizi sayı alıp tüm sayıların toplamını döndüren metod
    public int Topla(int[] sayilar)
    {
        int toplam = 0;  // Toplam değişkenini 0'a başlatıyoruz
        foreach (int sayi in sayilar)  // Sayılar dizisindeki her bir sayıyı döngü ile alıyoruz
        {
            toplam += sayi;  // Her sayıyı toplam değişkenine ekliyoruz
        }
        return toplam;  // Sonunda toplam değeri döndürüyoruz
    }
}

class Soru1
{
    static void Main(string[] args)
    {
        Matematik matematik = new Matematik();  // Matematik sınıfının bir nesnesini oluşturuyoruz

        // İki sayıyı toplamak için Topla metodunu çağırıyoruz
        int sonuc1 = matematik.Topla(5, 10);
        Console.WriteLine($"5 + 10 = {sonuc1}");  // Sonucu ekrana yazdırıyoruz

        // Üç sayıyı toplamak için Topla metodunu çağırıyoruz
        int sonuc2 = matematik.Topla(3, 7, 2);
        Console.WriteLine($"3 + 7 + 2 = {sonuc2}");  // Sonucu ekrana yazdırıyoruz

        // Bir dizi sayıyı toplamak için Topla metodunu çağırıyoruz
        int[] sayilar = { 1, 2, 3, 4, 5 };  // Bir dizi oluşturuyoruz
        int sonuc3 = matematik.Topla(sayilar);  // Diziyi Topla metoduna veriyoruz
        Console.WriteLine($"1 + 2 + 3 + 4 + 5 = {sonuc3}");  // Sonucu ekrana yazdırıyoruz

        Console.ReadKey();  
    }
}
