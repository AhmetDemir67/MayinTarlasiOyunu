using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Oyunnn
{
    public partial class Form1 : Form
    {
        // Constructor: Form1 sınıfı oluşturulurken çalışacak olan metod
        public Form1()
        {
            InitializeComponent(); // Formun bileşenlerini başlatır
        }

        // Mayın tarlası nesnesi
        Mayin_tarlasi mayin_tarla;

        // Mayın resmi
        Image mayin_Resmi = Image.FromFile(@"mayin.png");

        // Mayınlar listesi
        List<Mayin> mayinlar;

        // Bulunan temiz alan sayısı
        int bulunan_temiz_alan;

        // Form yüklendiğinde çağrılan metod
        private void Form1_Load(object sender, EventArgs e)
        {
            yeni_oyun_baslat(); // Yeni bir oyun başlatır
            //Mayinlari_goster(); // (Yorumda bırakılmış: Mayınları gösterme)
        }

        // Yeni bir oyun başlatan metod
        private void yeni_oyun_baslat()
        {
            lbl_durum.Text = ""; // Durum etiketini temizler
            mayin_tarla = new Mayin_tarlasi(new Size(400, 400), 60); // Yeni bir mayın tarlası nesnesi oluşturur
            panel1.Size = mayin_tarla.buyuklugu; // Panelin boyutlarını mayın tarlasının boyutuna ayarlar
            bulunan_temiz_alan = 0; // Temiz alan sayısını sıfırlar
            Mayin_ekle(); // Mayınları ekler
        }

        // Mayınları panel üzerine yerleştiren metod
        public void Mayin_ekle()
        {
            for (int x = 0; x < panel1.Width; x = x + 20) // Panelin genişliği boyunca
            {
                for (int y = 0; y < panel1.Height; y = y + 20) // Panelin yüksekliği boyunca
                {
                    Button_ekle(new Point(x, y)); // Her 20 piksellik alana buton ekler
                }
            }
        }

        // Belirtilen koordinatlara buton ekleyen metod
        public void Button_ekle(Point loc)
        {
            Button btn = new Button(); // Yeni bir buton oluşturur
            btn.Name = loc.X + "" + loc.Y; // Butonun ismini koordinatlarla belirler
            btn.Size = new Size(20, 20); // Butonun boyutunu 20x20 olarak ayarlar
            btn.Location = loc; // Butonun panel üzerindeki konumunu ayarlar
            btn.Click += new EventHandler(btn_Click); // Butona tıklama olayı ekler
            btn.MouseUp += new MouseEventHandler(btn_MouseUp); // Fare bırakma olayı ekler
            panel1.Controls.Add(btn); // Butonu panel üzerine ekler
        }

        // Fare sağ tuşuna basıldığında çağrılan metod
        void btn_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = (sender as Button); // Gönderen butonu al
            if (e.Button == MouseButtons.Right) // Sağ tıklama
            {
                btn.Text = "!"; // Butona '!' işareti ekler
            }
        }

        // Butona tıklama işlemi gerçekleştiğinde çağrılan metod
        public void btn_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button); // Gönderen butonu al
            Mayin myn = mayin_tarla.mayin_al_loc(btn.Location); // Butonun konumunda bir mayın olup olmadığını kontrol eder
            mayinlar = new List<Mayin>(); // Mayınlar listesini sıfırlar

            if (myn.mayin_var_mi) // Eğer mayın varsa
            {
                MessageBox.Show("Kaybettin"); // Kaybettin mesajı göster
                Mayinlari_goster(); // Mayınları göster
            }
            else
            {
                int s = etrafta_kac_mayin_var(myn); // Etrafında kaç mayın olduğunu bulur
                if (s == 0) // Etrafında mayın yoksa
                {
                    mayinlar.Add(myn); // Mayını ekler
                    for (int i = 0; i < mayinlar.Count; i++) // Etrafındaki her mayını kontrol eder
                    {
                        Mayin item = mayinlar[i];
                        if (item != null)
                        {
                            if (item.bakildi_ == false && item.mayin_var_mi == false)
                            {
                                Button btnx = (Button)panel1.Controls.Find(item.konum_al.X + "" + item.konum_al.Y, false)[0];
                                if (etrafta_kac_mayin_var(mayinlar[i]) == 0) // Etrafında mayın yoksa
                                {
                                    btnx.Enabled = false; // Butonu devre dışı bırak
                                    cevresindekileri_ekle(item); // Etrafındaki butonları ekle
                                }
                                else
                                {
                                    btnx.Text = etrafta_kac_mayin_var(item).ToString(); // Etrafındaki mayın sayısını yaz
                                }
                                bulunan_temiz_alan++; // Temiz alan sayısını artır
                                item.bakildi_ = true; // Bu mayına bakıldığını işaretle
                            }
                        }
                    }
                }
                else
                {
                    btn.Text = s.ToString(); // Etrafındaki mayın sayısını butona yaz
                    bulunan_temiz_alan++; // Temiz alan sayısını artır
                }
            }

            // Eğer temizlenen alan sayısı, toplam alandan mayın sayısı çıkarıldığında elde edilen alana eşitse kazanılmıştır
            if (bulunan_temiz_alan >= mayin_tarla.toplam_alan - mayin_tarla.toplam_mayin_sayisi)
            {
                lbl_durum.Text = "Kazandınız"; // Kazandınız mesajı göster
            }
        }

        // Etrafındaki mayın sayısını hesaplayan metod
        public int etrafta_kac_mayin_var(Mayin m)
        {
            int sayi = 0; // Mayın sayısını başlat

            // 8 yönlü kontrol: sol, sağ, yukarı, aşağı, ve köşeler
            if (m.konum_al.X > 0) // Sol
            {
                if (mayin_tarla.mayin_al_loc(new Point(m.konum_al.X - 20, m.konum_al.Y)).mayin_var_mi)
                {
                    sayi++;
                }
            }
            if (m.konum_al.Y < panel1.Height - 20 && m.konum_al.X < panel1.Width - 20) // Sağ alt
            {
                if (mayin_tarla.mayin_al_loc(new Point(m.konum_al.X + 20, m.konum_al.Y + 20)).mayin_var_mi)
                {
                    sayi++;
                }
            }
            if (m.konum_al.X < panel1.Width - 20) // Sağ
            {
                if (mayin_tarla.mayin_al_loc(new Point(m.konum_al.X + 20, m.konum_al.Y)).mayin_var_mi)
                {
                    sayi++;
                }
            }
            if (m.konum_al.X > 0 && m.konum_al.Y > 0) // Sol üst
            {
                if (mayin_tarla.mayin_al_loc(new Point(m.konum_al.X - 20, m.konum_al.Y - 20)).mayin_var_mi)
                {
                    sayi++;
                }
            }
            if (m.konum_al.Y > 0) // Üst
            {
                if (mayin_tarla.mayin_al_loc(new Point(m.konum_al.X, m.konum_al.Y - 20)).mayin_var_mi)
                {
                    sayi++;
                }
            }
            if (m.konum_al.X > 0 && m.konum_al.Y < panel1.Height - 20) // Sol alt
            {
                if (mayin_tarla.mayin_al_loc(new Point(m.konum_al.X - 20, m.konum_al.Y + 20)).mayin_var_mi)
                {
                    sayi++;
                }
            }
            if (m.konum_al.Y < panel1.Height - 20) // Aşağı
            {
                if (mayin_tarla.mayin_al_loc(new Point(m.konum_al.X, m.konum_al.Y + 20)).mayin_var_mi)
                {
                    sayi++;
                }
            }
            if (m.konum_al.X > panel1.Width - 20 && m.konum_al.Y > 0) // Sağ üst
            {
                if (mayin_tarla.mayin_al_loc(new Point(m.konum_al.X + 20, m.konum_al.Y - 20)).mayin_var_mi)
                {
                    sayi++;
                }
            }

            return sayi; // Etrafındaki mayın sayısını döndürür
        }

        // Mayının etrafındaki butonları ekleyen metod
        public void cevresindekileri_ekle(Mayin m)
        {
            bool b1 = false; // Sol kontrolü
            bool b2 = false; // Üst kontrolü
            bool b3 = false; // Sağ kontrolü
            bool b4 = false; // Alt kontrolü

            // Sol
            if (m.konum_al.X > 0)
            {
                mayinlar.Add(mayin_tarla.mayin_al_loc(new Point(m.konum_al.X - 20, m.konum_al.Y)));
                b1 = true;
            }

            // Üst
            if (m.konum_al.Y > 0)
            {
                mayinlar.Add(mayin_tarla.mayin_al_loc(new Point(m.konum_al.X, m.konum_al.Y - 20)));
                b2 = true;
            }

            // Sağ
            if (m.konum_al.X < panel1.Width)
            {
                mayinlar.Add(mayin_tarla.mayin_al_loc(new Point(m.konum_al.X + 20, m.konum_al.Y)));
                b3 = true;
            }

            // Alt
            if (m.konum_al.Y < panel1.Height)
            {
                mayinlar.Add(mayin_tarla.mayin_al_loc(new Point(m.konum_al.X, m.konum_al.Y + 20)));
                b4 = true;
            }

            // Sol ve Üst köşe
            if (b1 && b2)
            {
                mayinlar.Add(mayin_tarla.mayin_al_loc(new Point(m.konum_al.X - 20, m.konum_al.Y - 20)));
            }

            // Sol ve Alt köşe
            if (b1 && b4)
            {
                mayinlar.Add(mayin_tarla.mayin_al_loc(new Point(m.konum_al.X - 20, m.konum_al.Y + 20)));
            }

            // Sağ ve Üst köşe
            if (b2 && b3)
            {
                mayinlar.Add(mayin_tarla.mayin_al_loc(new Point(m.konum_al.X + 20, m.konum_al.Y - 20)));
            }

            // Sağ ve Alt köşe
            if (b2 && b4)
            {
                mayinlar.Add(mayin_tarla.mayin_al_loc(new Point(m.konum_al.X + 20, m.konum_al.Y + 20)));
            }
        }

        // Mayınları panel üzerinde gösteren metod
        public void Mayinlari_goster()
        {
            foreach (Mayin item in mayin_tarla.GetAllMayin) // Tüm mayınları döngüyle gez
            {
                if (item.mayin_var_mi) // Mayın varsa
                {
                    Button btn = (Button)panel1.Controls.Find(item.konum_al.X + "" + item.konum_al.Y, false)[0]; // Mayının butonunu bulur
                    btn.BackgroundImage = mayin_Resmi; // Mayın resmi ekler
                    btn.BackgroundImageLayout = ImageLayout.Stretch; // Resmi butona sığdırır
                }
            }
        }

        // Yeni oyun başlatan butona tıklama olayını işleyen metod
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear(); // Paneldeki tüm kontrolleri temizler
            yeni_oyun_baslat(); // Yeni bir oyun başlatır
        }
    }
}

