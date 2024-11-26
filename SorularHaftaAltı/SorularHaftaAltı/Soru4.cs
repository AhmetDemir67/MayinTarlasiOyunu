using System;

class Kitaplik
{
    // Kitap koleksiyonunu tutacak bir dizi oluşturuyoruz.
    private string[] kitaplar;

    // Kitaplık sınıfı, kitap sayısını alarak kitaplar dizisini başlatan bir yapıcıya sahip.
    public Kitaplik(int kitapSayisi)
    {
        kitaplar = new string[kitapSayisi];  // Kitap sayısı kadar dizi boyutu oluşturuluyor.
    }

    // Kitaplar dizisine indeksleyici ile erişimi sağlıyoruz.
    // Hem get hem de set metodlarını içeriyor. 
    public string this[int indeks]
    {
        // Kitapları erişmek için get metodu
        get
        {
            // İndeks geçerli değilse hata mesajı döndürüyoruz
            if (indeks < 0 || indeks >= kitaplar.Length)
            {
                return "Geçersiz indeks!";  // Geçersiz indeks mesajı
            }
            return kitaplar[indeks];  // Geçerli indekste bulunan kitabı döndürüyoruz
        }
        // Kitapları değiştirmek için set metodu
        set
        {
            // İndeks geçerli değilse kullanıcıyı uyarıyoruz.
            if (indeks < 0 || indeks >= kitaplar.Length)
            {
                Console.WriteLine("Geçersiz indeks! Kitap adı değiştirilemez.");  // Geçersiz indeks mesajı
                return;  // Hiçbir şey yapmadan metottan çıkıyoruz.
            }
            kitaplar[indeks] = value;  // Geçerli indekse yeni kitabı atıyoruz
        }
    }

    // Kitap koleksiyonundaki kitapları listeleyen metod
    public void KitaplariListele()
    {
        Console.WriteLine("Kitap Koleksiyonu:");
        for (int i = 0; i < kitaplar.Length; i++)
        {
            Console.WriteLine($"{i}. {kitaplar[i]}");  // Kitap indeksini ve adını ekrana yazdırıyoruz
        }
    }
}

class Soru4
{
    static void Main(string[] args)
    {
        // Kitaplık nesnesi oluşturuluyor, 5 kitaplık bir koleksiyon.
        Kitaplik kitaplik = new Kitaplik(5);

        // Kitaplar dizisine kitap adları ekleniyor
        kitaplik[0] = "Harry Potter ve Felsefe Taşı";
        kitaplik[1] = "Yüzüklerin Efendisi";
        kitaplik[2] = "Suç ve Ceza";
        kitaplik[3] = "1984";
        kitaplik[4] = "Sefiller";

        // Kitap koleksiyonunu listeleme
        kitaplik.KitaplariListele();  // Bu metod kitapların adlarını ekrana yazdıracak.

        // Geçersiz bir indeksle erişim denemesi
        Console.WriteLine("\nGeçersiz indeksle kitap erişimi: ");
        Console.WriteLine(kitaplik[5]);  // Geçersiz indeks olduğu için hata mesajı gösterilecek

        // 2. indeksteki kitabın adını güncelleme
        kitaplik[2] = "Yeni Suç ve Ceza";  // Suç ve Ceza kitabı güncelleniyor.

        // Güncellenmiş kitap koleksiyonunu listeleme
        Console.WriteLine("\nKitap Koleksiyonu Güncellenmiş Haliyle:");
        kitaplik.KitaplariListele();  // Güncellenmiş kitap listesi yazdırılacak.

        // Geçersiz indeksle kitap ekleme denemesi
        kitaplik[10] = "Geçersiz Kitap";  // Geçersiz indeks olduğu için hata mesajı verilecek
    }
}
