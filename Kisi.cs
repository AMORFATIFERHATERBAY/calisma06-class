using System;
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
                if (!Helper.KarakterSayisi(value, 3))
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
                if (!Helper.KarakterSayisi(value, 11) || !Helper.IlkKarakter(value))// Helper.HarfKarakter(value)) // && Kisi.TelDogrulama(value)
                
                    //Console.WriteLine("Telefon numaranız 11 haneli olmalı ve hafr karakter içermemelidir.");
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
                // if (Char.Equals(telNo[0], '0'))
                // {
                if (!Char.IsDigit(telNo[i]))
                {
                    Console.WriteLine("Lütfen Tel No olarak rakam giriniz.");

                    return false;
                }
                //}
                // else
                // {
                //     Console.WriteLine("Telefon numaranızın ilk karateri '0' ile başlamalı.");
                //     return false;
                // }
            }
            return true;
        }

        // public bool MailKontrol(string girilenMail)
        // {
        //     if (!String.IsNullOrEmpty(girilenMail))
        //     {

        //     }
        // }

    }


}

