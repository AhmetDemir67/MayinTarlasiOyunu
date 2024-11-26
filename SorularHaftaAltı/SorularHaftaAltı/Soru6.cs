using System;

class SatrancTahtasi
{
    // 8x8 boyutunda satranç tahtasını temsil eden bir 2D dizi (matris)
    private string[,] tahtadaKareler;

    // Yapıcı metod: Satranç tahtasını başlatan bir constructor
    public SatrancTahtasi()
    {
        // Tahtada her karenin başlangıçta "Boş" olduğunu belirtiyoruz.
        tahtadaKareler = new string[8, 8];
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                tahtadaKareler[i, j] = "Boş"; // Başlangıçta her kare boş.
            }
        }
    }

    // İndeksleyici: Satır ve sütun numarasına göre tahtadaki kareye erişim sağlanır.
    public string this[int satir, int sutun]
    {
        // Get metodu: Belirtilen satır ve sütun değeri geçerli mi kontrol edilir, geçerliyse ilgili kareyi döndürür.
        get
        {
            if (satir < 0 || satir >= 8 || sutun < 0 || sutun >= 8)
            {
                // Geçersiz bir kareye erişim yapılırsa hata fırlatılır.
                throw new IndexOutOfRangeException("Geçersiz kare! Satranç tahtası 0-7 arası indeksleri kabul eder.");
            }
            return tahtadaKareler[satir, sutun];
        }
        // Set metodu: Belirtilen satır ve sütuna taş yerleştirilir.
        set
        {
            if (satir < 0 || satir >= 8 || sutun < 0 || sutun >= 8)
            {
                // Geçersiz bir kareye taş yerleştirmeye çalışılırsa hata mesajı gösterilir.
                Console.WriteLine("Geçersiz kare! Taş yerleştirilemez.");
                return;
            }
            tahtadaKareler[satir, sutun] = value; // Taş belirtilen kareye yerleştirilir.
        }
    }

    // Satranç tahtasını ekrana yazdıran metod.
    public void TahtayiYazdir()
    {
        Console.WriteLine("Satranç Tahtası Durumu:");
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                // Her bir karenin durumunu tab ile ayırarak yazdırıyoruz.
                Console.Write(tahtadaKareler[i, j] + "\t");
            }
            Console.WriteLine(); // Her satırdan sonra yeni satıra geçilir.
        }
    }
}

class Soru6
{
    static void Main(string[] args)
    {
        // SatrancTahtasi sınıfından bir nesne oluşturuluyor.
        SatrancTahtasi tahtasi = new SatrancTahtasi();

        // Tahtanın başlangıç durumunu yazdırıyoruz.
        tahtasi.TahtayiYazdir();

        // Tahtada bazı taşları yerleştiriyoruz.
        tahtasi[0, 0] = "Beyaz Kale"; // (0,0) konumuna Beyaz Kale yerleştiriyoruz.
        tahtasi[0, 1] = "Beyaz At"; // (0,1) konumuna Beyaz At yerleştiriyoruz.
        tahtasi[7, 0] = "Siyah Kale"; // (7,0) konumuna Siyah Kale yerleştiriyoruz.
        tahtasi[7, 1] = "Siyah At"; // (7,1) konumuna Siyah At yerleştiriyoruz.

        // Güncellenmiş tahtayı yazdırıyoruz.
        Console.WriteLine("\nGüncellenmiş Satranç Tahtası:");
        tahtasi.TahtayiYazdir();

        // Geçersiz bir kareye taş yerleştirmeyi deniyoruz.
        Console.WriteLine("\nGeçersiz Kareye Taş Yerleştirme Denemesi:");
        tahtasi[9, 9] = "Beyaz Piyon"; // (9,9) geçersiz bir konumdur.

        // Geçersiz bir kareyi sorgulama denemesi.
        Console.WriteLine("\nGeçersiz Kareyi Sorgulama Denemesi:");
        try
        {
            // Geçersiz bir karenin taşını sorgulamaya çalışıyoruz.
            Console.WriteLine(tahtasi[9, 9]);
        }
        catch (IndexOutOfRangeException ex)
        {
            // Hata mesajı yakalanır ve ekrana yazdırılır.
            Console.WriteLine(ex.Message);
        }

        // Doğru bir kareyi sorgulama.
        Console.WriteLine("\nDoğru Kareyi Sorgulama:");
        Console.WriteLine(tahtasi[0, 0]); // (0,0) konumundaki "Beyaz Kale"yi yazdırıyoruz.

        
        Console.ReadKey();
    }
}
