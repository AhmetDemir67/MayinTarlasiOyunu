using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Oyunnn
{
    // Mayin (Mayın) sınıfı, mayınları temsil eder. 
    // Her bir mayın, bir konum (lokasyon), dolu olup olmadığı durumu ve bakılıp bakılmadığı bilgisini tutar.
    public class Mayin
    {
        // Mayının bulunduğu konum.
        Point loc;

        // Mayının dolu olup olmadığı durumu (gerçek mayın mı, yoksa boş bir hücre mi).
        bool dolu;

        // Mayına bakılıp bakılmadığını gösteren durum (gerçekten üzerine tıklanıp bakıldı mı).
        bool bakildi;

        // Yapıcı metod, mayının konumunu alır ve mayının dolu olup olmadığını başlatır (false).
        public Mayin(Point loca)
        {
            dolu = false; // Başlangıçta mayın yok (dolu değil).
            loc = loca;   // Mayının konumunu ayarla.
        }

        // Mayının konumunu döndüren property (özellik).
        public Point konum_al
        {
            get { return loc; }
        }

        // Mayının dolu olup olmadığını (gerçek mayın olup olmadığını) belirten property.
        public bool mayin_var_mi
        {
            get
            {
                return dolu; // Gerçek mayın varsa true, yoksa false döner.
            }
            set
            {
                dolu = value; // Dolu (gerçek mayın) olup olmadığını ayarlar.
            }
        }

        // Mayına bakılıp bakılmadığını belirten property.
        public bool bakildi_
        {
            get
            {
                return bakildi; // Mayına bakılıp bakılmadığına göre true/false döner.
            }
            set
            {
                bakildi = value; // Mayına bakıldıysa true, bakılmadıysa false olarak ayarlanır.
            }
        }
    }
}
