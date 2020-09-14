using System;

namespace class_calisma
{
    public static class Helper
    {
        public static bool KarakterSayisi(string imput, int boyut)
        {
            if (imput.Length < boyut)
            {
                Console.WriteLine($"Girdiğiniz karakter sayısı en az {boyut} karakterli olmalıdır.");
                return false;
            }
            return true;
        }

        public static bool KarakterVarMi(string karakter, char ch)
        {

            bool karakterVarM = false;
            //for (int i = 0; i < karakter.Length; )//++i)
            for (int i = 0; i < karakter.Length; ++i)
            {
                if (Char.Equals(karakter[i], ch))
                {
                    karakterVarM = true;

                    break;
                }
            }
            if (!karakterVarM)
                Console.WriteLine($"Mail adresinizde mutlaka {ch} karakteri olmalıdır");
            return karakterVarM;

        }

        public static bool DigitKarakter(string input)
        {
            bool rakamMi = false;
            for (int i = 0; i < input.Length; ++i)
            {
                if (Char.IsDigit(input[i])) //&& Char.IsSymbol(input[i]))

                {
                    rakamMi = true;
                    break;
                }

            }

            if (!rakamMi)
            {
                //Console.Clear();
                Console.WriteLine("Şifreniz en az bir rakam  içermelidir.");
            }
            return rakamMi;

        }


        public static bool SembolKarakter(string input)
        {
            bool sembolMi = false;
            for (int i = 0; i < input.Length; ++i)
            {
                if (Char.IsSymbol(input[i]))
                {
                    sembolMi = true;
                    break;
                }
            }
            if (!sembolMi)
            {
                //Console.Clear();
                Console.WriteLine("Şifreniz en az bir adet sembol karakter içermelidir. ");
            }
            return sembolMi;
        }
        public static bool HarfKarakter(string input)
        {
            bool harfMi = false;
            for (int i = 0; i < input.Length; ++i)
            {
                if (Char.IsLetter(input[i]))
                {

                    harfMi = true;
                    break;
                }
            }
            if (!harfMi)
            {
                // Console.Clear();
                Console.WriteLine("Şifreniz en az bir adet harf karakter içermelidir.");
            }
            return harfMi;
        }
        public static bool IlkKarakter(string firtsCharakter)
        {
            if (!Char.Equals(firtsCharakter[0], '0'))
            {
                Console.WriteLine("İlk karakter '0' sıfır ile başlamalıdır");
                return false;
            }
            return true;
        }



    }



}

