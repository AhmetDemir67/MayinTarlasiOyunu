using System;

class Otopark
{
    // Otopark sınıfı, katları ve park yerlerini temsil eden bir 2D dizi kullanır.
    private string[][] katlar;

    // Yapıcı metod: Otoparkın kat sayısını ve park yeri sayısını belirler.
    public Otopark(int katSayisi, int parkYeriSayisi)
    {
        // Katlar dizisini, belirtilen kat sayısı kadar başlatıyoruz.
        katlar = new string[katSayisi][];
        for (int i = 0; i < katSayisi; i++)
        {
            // Her katın park yerlerini başlatıyoruz.
            katlar[i] = new string[parkYeriSayisi];
            for (int j = 0; j < parkYeriSayisi; j++)
            {
                // Başlangıçta her park yeri "Empty" (boş) olarak ayarlanır.
                katlar[i][j] = "Empty";
            }
        }
    }

    // İndeksleyici: Kat ve park yeri numarasına göre park yerinin durumunu sorgulama ve değiştirme.
    public string this[int kat, int parkYeri]
    {
        get
        {
            // Geçersiz kat veya park yeri sorgulanırsa hata fırlatılır.
            if (kat < 0 || kat >= katlar.Length || parkYeri < 0 || parkYeri >= katlar[kat].Length)
            {
                throw new IndexOutOfRangeException("Geçersiz kat veya park yeri!");
            }
            return katlar[kat][parkYeri];
        }
        set
        {
            // Geçersiz kat veya park yeri sorgulanırsa hata fırlatılır.
            if (kat < 0 || kat >= katlar.Length || parkYeri < 0 || parkYeri >= katlar[kat].Length)
            {
                throw new IndexOutOfRangeException("Geçersiz kat veya park yeri!");
            }
            katlar[kat][parkYeri] = value; // Park yerine araç plakası ya da yeni değer yerleştirilir.
        }
    }

    // Otoparkın tüm durumunu ekrana yazdıran metod.
    public void OtoparkDurumunuYazdir()
    {
        // Her katı ve park yerlerini ekrana yazdırıyoruz.
        for (int i = 0; i < katlar.Length; i++)
        {
            Console.WriteLine($"Kat {i + 1}:");
            for (int j = 0; j < katlar[i].Length; j++)
            {
                Console.WriteLine($"Park Yeri {j + 1}: {katlar[i][j]}");
            }
            Console.WriteLine(); // Katlar arasında boşluk bırakmak için.
        }
    }
}

class Soru7
{
    static void Main(string[] args)
    {
        // Otopark sınıfından bir nesne oluşturuluyor, 3 kat ve 5 park yeri ile.
        Otopark otopark = new Otopark(3, 5);

        // Başlangıç durumunu yazdırıyoruz.
        otopark.OtoparkDurumunuYazdir();

        // Kat 1, Park Yeri 2'ye araç plakasını yerleştiriyoruz.
        otopark[0, 1] = "34ABC123";

        // Kat 2, Park Yeri 4'e başka bir araç plakası yerleştiriyoruz.
        otopark[1, 3] = "42XYZ456";

        // Güncellenmiş durumu yazdırıyoruz.
        Console.WriteLine("\nGüncellenmiş Otopark Durumu:");
        otopark.OtoparkDurumunuYazdir();

        // Geçersiz bir park yeri sorgulaması yapılırsa hata mesajı gösterilir.
        Console.WriteLine("\nGeçersiz Sorgulama:");
        try
        {
            // Kat 3, Park Yeri 6'ya sorgulama yapıyoruz (geçersiz bir yer).
            Console.WriteLine(otopark[2, 5]);
        }
        catch (IndexOutOfRangeException ex)
        {
            // Hata mesajı yakalanır ve ekrana yazdırılır.
            Console.WriteLine(ex.Message);
        }

        
        Console.ReadKey();
    }
}
