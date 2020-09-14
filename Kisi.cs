using System;
using System.IO;
using System.Collections;
//using class_calisma1;

namespace class_calisma
{
    class Kisi
    {
        private string adi;
        private string soyadi;
        private string tel;
        private string mail;
        private string sifre;
        DateTime dogumTarihi;
        public string Adi
        {
            get
            {

                return adi;
            }
            set
            {
                if (!Helper.KarakterSayisi(value, 3))
                    return;

                adi = value;
            }
        }

        public string Soyadi
        {
            get
            {
                return soyadi;
            }
            set
            {
                if (!Helper.KarakterSayisi(value, 2))
                    return;
                soyadi = value;
            }
        }

        public string Tel
        {
            get
            {
                return tel;
            }
            set
            {
                if (!Helper.KarakterSayisi(value, 11) || !Helper.IlkKarakter(value))
                    return;

                tel = value;
            }
        }

        public string Mail
        {
            get
            {
                return mail;
            }
            set
            {
                if (!Helper.KarakterVarMi(value, '@'))
                    return;
                mail = value;
            }
        }

        public string Sifre
        {
            get
            {
                string gecici = "";
                if (!String.IsNullOrEmpty(sifre))
                    for (int i = 0; i < sifre.Length; ++i)
                    {
                        gecici += "*";
                    }
                return gecici;
            }
            set
            {
                if (!Helper.KarakterSayisi(value, 6) | !Helper.DigitKarakter(value) | !Helper.SembolKarakter(value) | !Helper.HarfKarakter(value))
                    return;
                sifre = value;

            }
        }
        public int Yas
        {
            get
            {
                TimeSpan fark = DateTime.Today - dogumTarihi;
                return fark.Days / 365;
            }

        }
        public DateTime DogumTarihi
        {
            get
            {

                return dogumTarihi;
            }
            set
            {
                dogumTarihi = value;
            }

        }

        public bool SifreKontrol(string girilenSifre)
        {
            if (girilenSifre.Length != sifre.Length)
                return false;

            for (int i = 0; i < sifre.Length; ++i)
            {

                if (girilenSifre[i] != sifre[i])
                {

                    return false;
                }
            }

            return true;
        }
        public bool TelDogrulama(string telNo)
        {
            for (int i = 0; i < telNo.Length; ++i)
            {

                if (!Char.IsDigit(telNo[i]))
                {
                    Console.WriteLine("Lütfen Tel No olarak rakam giriniz.");

                    return false;
                }

            }
            return true;
        }

        public void KisiKaydet(string dosya)
        {
            FileStream fs = new FileStream(dosya, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine($"{Adi};{Soyadi};{Mail};{Tel};{sifre};{Convert.ToString(DogumTarihi)};{Yas};");

            //sw.Flush();
            sw.Close();
            Console.WriteLine(">> Kaydetme işleminiz başarı ile gerçekleştirilmiştir.");
        }

        public Kisi[] KisileriOku(string dosya)
        {
            Kisi[] kisiler = { };
            FileStream fs1 = new FileStream(dosya, FileMode.Open);
            StreamReader sr = new StreamReader(fs1);

            string lines;
            while ((lines = sr.ReadLine()) != null)
            {
                string[] kisiÖzellik = lines.Split(';');

                Kisi kisi = new Kisi();
                if (kisiÖzellik.Length >= 1)
                    kisi.Adi = kisiÖzellik[0];
                if (kisiÖzellik.Length >= 2)
                    kisi.Soyadi = kisiÖzellik[1];
                if (kisiÖzellik.Length >= 3)
                    kisi.Mail = kisiÖzellik[2];
                if (kisiÖzellik.Length >= 4)
                    kisi.Tel = kisiÖzellik[3];
                if (kisiÖzellik.Length >= 5)
                    kisi.sifre = kisiÖzellik[4];
                if (kisiÖzellik.Length >= 6)
                    kisi.DogumTarihi = Convert.ToDateTime(kisiÖzellik[5]);

                // Array.Resize(ref kisiler, kisiler.Length + 1);

                // kisiler[kisiler.GetUpperBound(0)] = kisi;

                ArrayList alist = new ArrayList(0);
                alist.Add(kisi);


            }
            return kisiler;
        }

        public ArrayList KisileriOku1(string dosya)
        {
            
            FileStream fs1 = new FileStream(dosya, FileMode.Open);
            StreamReader sr = new StreamReader(fs1);

            ArrayList alist = new ArrayList(0);

            string lines;
            while ((lines = sr.ReadLine()) != null)
            {
                string[] kisiÖzellik = lines.Split(';');

                Kisi kisi = new Kisi();
                if (kisiÖzellik.Length >= 1)
                    kisi.Adi = kisiÖzellik[0];
                if (kisiÖzellik.Length >= 2)
                    kisi.Soyadi = kisiÖzellik[1];
                if (kisiÖzellik.Length >= 3)
                    kisi.Mail = kisiÖzellik[2];
                if (kisiÖzellik.Length >= 4)
                    kisi.Tel = kisiÖzellik[3];
                if (kisiÖzellik.Length >= 5)
                    kisi.sifre = kisiÖzellik[4];
                if (kisiÖzellik.Length >= 6)
                    kisi.DogumTarihi = Convert.ToDateTime(kisiÖzellik[5]);

                // Array.Resize(ref kisiler, kisiler.Length + 1);

                // kisiler[kisiler.GetUpperBound(0)] = kisi;


                alist.Add(kisi);


            }
            return alist;
        }

        public Kisi KisiyiGetir(Kisi[] kisiler, string parametre)
        {
            foreach (Kisi kisi in kisiler)
            {
                if (kisi.Adi.ToLower() == parametre.ToLower() || kisi.Soyadi.ToLower() == parametre.ToLower())
                    return kisi;
            }
            return null; //new Kisi();
        }
         public Kisi KisiyiGetir1(ArrayList kisiler, string parametre)
        {
            foreach (Kisi kisi in kisiler)
            {
                if (kisi.Adi.ToLower() == parametre.ToLower() || kisi.Soyadi.ToLower() == parametre.ToLower())
                    return kisi;
            }
            return null; //new Kisi();
        }

        public override string ToString()
        {
            return $"Adi :{Adi}\nSoyadi :{Soyadi}\nMail :{Mail}\nTel :{Tel}\nSifre :{sifre}\nDoğum Tarihi :{DogumTarihi}\nYas :{Yas}\n\n"; //Doğum Tarihi :{DogumTarihi}\n
        }
        public void KisiGuncelle(string dosya)
        {
            FileStream fs = new FileStream(dosya, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine($"{Adi};{Soyadi};{Mail};{Tel};{sifre};{Convert.ToString(DogumTarihi)};{Yas};");

            //sw.Flush();
            sw.Close();
            Console.WriteLine(">>Güncelleme işleminiz başarı ile gerçekleştirilmiştir.\n");

        }

        public void KisiSil(string adi, string yol)
        {
            string tempFile = Path.GetTempFileName();

            using (var sr = new StreamReader(yol))
            using (var sw = new StreamWriter(tempFile))
            {

                string line;
                bool silindiMi = false;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] kisiÖz = line.Split(';');
                    if (kisiÖz[0].ToLower() != adi.ToLower())
                        sw.WriteLine(line);
                    if (kisiÖz[0].ToLower() == adi.ToLower())
                    {
                        Console.WriteLine(">>Silme işlemi başarı ile gerçekleştirildi...");
                        silindiMi = true;
                        continue;
                    }
                }
                if (!silindiMi)
                    Console.WriteLine("Silinecek kişi bulunamadı ya da başarı ile silinemedi...");

            }

            File.Delete(yol);
            File.Move(tempFile, yol);

        }

    }

}