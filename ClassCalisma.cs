using System;
using System.IO;
using System.Text.RegularExpressions;


namespace class_calisma
{

    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            string secim;
            do
            {
                Console.WriteLine("\nKaydetmek için          --> c");
                Console.WriteLine("Okumak&Arama için       --> r");
                Console.WriteLine("Güncelleme için         --> u");
                Console.WriteLine("Silmek için             --> d");
                Console.WriteLine("\nProgramdan çıkmak için  --> Q/q\n");

                Console.Write("İşleminizi seçiniz : ");
                secim = Console.ReadLine().ToLower();
                Console.WriteLine();

                if (secim == "c")
                {
                    string dosya = "MyText.txt";
                    FileStream fs = new FileStream(dosya, FileMode.Append);

                    Kisi kisi = new Kisi();
                    

                    Kisi ahmet = new Kisi();
                    

                    //string newKisi = "";

                    StreamWriter sw = new StreamWriter(fs);
                    Console.Write("\nAdı : ");
                    ahmet.Adi = Console.ReadLine().Trim();
                    sw.WriteLine($"Adı : {ahmet.Adi}");
                    // newKisi += $"{ahmet.Adi};";

                    Console.Write("\nSoyadı : ");
                    ahmet.Soyadi = Console.ReadLine().Trim();
                    sw.WriteLine($"Soyadı : {ahmet.Soyadi}");
                    // newKisi += $"{ahmet.Soyadi};";


                    bool mailGecerliMi = true;
                    do
                    {
                        Console.Write("\nMail adresinizi giriniz :");
                        ahmet.Mail = Console.ReadLine().Trim();
                        sw.WriteLine($"Mail : {ahmet.Mail}");
                        // newKisi += $"{ahmet.Mail};";
                        mailGecerliMi = !String.IsNullOrEmpty(ahmet.Mail);

                    } while (!mailGecerliMi);


                    bool sifreGecerliMi = true;
                    do
                    {
                        Console.Write("\nLütfen Şifrenizi Oluşturunuz :");
                        ahmet.Sifre = Console.ReadLine().Trim();
                        sw.WriteLine($"Sifre : {ahmet.Sifre}");
                        sifreGecerliMi = !String.IsNullOrEmpty(ahmet.Sifre);

                    } while (!sifreGecerliMi);

                    Console.WriteLine($"Sifreniz oluşturuldu : {ahmet.Sifre}");


                    bool sifreYanlisMi = true;
                    do
                    {
                        Console.Write("\nLütfen Şifrenizi Giriniz :");
                        string girilenSifre = Console.ReadLine().Trim();
                        sifreYanlisMi = !ahmet.SifreKontrol(girilenSifre);
                        if (!sifreYanlisMi)
                        { Console.WriteLine("Şifre eşleşti."); }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Şifre eşleşmedi.");

                        }
                    } while (sifreYanlisMi);


                    Console.Write("\nDoğum Tarihini Griniz :");
                    //ahmet.DogumTarihi = new DateTime(1980, 05, 01);
                    ahmet.DogumTarihi = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine();
                    //Console.WriteLine("Doğum Tarihiniz :" + ahmet.DogumTarihi);
                    Console.WriteLine("Yaşınız         :" + ahmet.Yas);
                    string dogumTarihi = Convert.ToString(ahmet.DogumTarihi);


                    bool telGecerli = true;
                    do
                    {
                        Console.Write("\nTelefon numaranızı giriniz : ");
                        ahmet.Tel = Console.ReadLine().Trim();
                        sw.WriteLine($"Tel No : {ahmet.Tel}");
                        // newKisi += $"{ahmet.Tel};";
                        sw.WriteLine();
                        telGecerli = (!String.IsNullOrEmpty(ahmet.Tel) && ahmet.TelDogrulama(ahmet.Tel));



                    } while (!telGecerli);
                    Console.WriteLine("Telefon numaranız başarı ile girilmiştir.");


                    sw.Flush();
                    sw.Close();


                    // string dosya1 = "MyText1.txt";
                    // FileStream fs3 = new FileStream(dosya1, FileMode.Append);
                    // StreamWriter sw1 = new StreamWriter(fs3);
                    // sw1.WriteLine(newKisi);
                    // sw1.Flush();
                    // sw1.Close();

                    ahmet.KisiKaydet("MyText2.txt");
                }

                //Console.Clear();

                // FileStream fs1 = new FileStream(dosya, FileMode.Open);
                // StreamReader sr = new StreamReader(fs1);

                // string lines;
                // while ((lines = sr.ReadLine()) != null)
                //     Console.WriteLine(lines);
                // fs1.Close();
                else if (secim == "r")
                {
                    Kisi kisiOkunan = new Kisi();
                    Kisi[] kisiListesi = kisiOkunan.KisileriOku("MyText2.txt");
                    // foreach (Kisi i in kisiListesi)
                    //     Console.WriteLine(i);

                    

                    Console.Write("Aramayı Gririniz :");
                    string adi = Console.ReadLine().Trim();
                    Kisi bulunanKisi = kisiOkunan.KisiyiGetir(kisiListesi, adi);
                    if (bulunanKisi != null)
                        Console.WriteLine(bulunanKisi);
                    else
                        Console.WriteLine("Kişi bulunamadı");

                }
                else if (secim == "d")
                {
                    Kisi kisiOkunan1 = new Kisi();
                    Console.Write("\nSilinecek Kişiyi Gririniz :");
                    string adi1 = Console.ReadLine().Trim();

                    kisiOkunan1.KisiSil(adi1, "MyText2.txt");

                }









                // bool bulunduMu = false;
                // while ((lines = sr1.ReadLine()) != null)
                // {
                //     if (lines == $"Adı : {adi}")
                //     //if (lines == "Bilal")
                //     {
                //         Console.WriteLine($"\nArama sonucu : {lines} bulundu.\n");
                //         bulunduMu = true;
                //         break;
                //     }

                // }
                // if (!bulunduMu)
                //     Console.WriteLine("\nArama sonucu bulunmadı.\n");

                // fs2.Close();



                //**************************String*******************************
                //***************************************************************   
                // Kisi oktay = new Kisi();
                // Console.WriteLine(oktay.TelDogrulama("05325321211"));

                // char[] dizi = { '1', '2', '3', '4' };
                // string strg = new string(dizi);
                // //strg = "12345";
                // Console.WriteLine(strg);

                // string st = new string(dizi, 2, 2);
                // Console.WriteLine(st);
                // int x = 5;
                // String s = new string('5', x);
                // Console.WriteLine(s);

                // String con = string.Concat(5, 'c');
                // Console.WriteLine(con);
                // Console.WriteLine("ali" + " bak");

                // Console.WriteLine(String.Compare("gmail", "Gmail", false));
                // Console.WriteLine(Convert.ToInt32(ahmet.Mail.IndexOf("@")));
                // cConsole.WriteLine(String.Compare(ahmet.Mail, Convert.ToInt32(ahmet.Mail.IndexOf("@")) + 1, "Gmail", 0, 5, true));
                // string yazi = "Pek yakında sinemalarda";
                // // Console.WriteLine(yazi.IndexOf("akın"));
                // // Console.WriteLine(yazi.IndexOf("k"));
                // Console.WriteLine(yazi.LastIndexOf("k"));

                // Console.Write("şifrenizi giriniz :");
                // string sifre = Console.ReadLine().Trim();
                // //string sifre = " sifre ";
                // Console.WriteLine(sifre);
                // Console.WriteLine(sifre.Trim());
                // Console.WriteLine(sifre.Trim().Length);
                // string str1 = "Oktay";
                // Console.WriteLine(str1.PadLeft(10));
                // Console.WriteLine(str1.PadLeft(10,'*'));

                // Console.WriteLine(str1.PadRight(10));
                // Console.WriteLine(str1.PadRight(10,'*'));
                // Console.WriteLine(str1.PadRight(6,','));


                // string str2 = " :Ali, :Ahmet, :Mehmet, :Orhan, :Serhat, Fuat, Osman";

                // char[] ayirici = { ',' };
                // string[] isimler = str2.Split(ayirici);
                // //string[] istenlenAdlar = str2.Split(ayirici, 4);

                // foreach (string i in isimler)
                //     Console.WriteLine(i);

                // foreach (string i in istenlenAdlar)
                //     Console.WriteLine(i);
                // Console.Clear();
                // Kisi human = new Kisi();


                // string[] isim = { "Ali", "ata bak.", "Oya", "topu tut.", "Bak", "Ali", "bak" };
                // string jn = String.Join(",", isim);
                // Console.WriteLine(jn.Replace(',',' '));

                // // string str4 = Console.ReadLine();

                // //Console.Clear();
                // string str3 = "Akşam eve geç geleceğim, merak etmeyin.";
                // Console.WriteLine(str3.ToLower().Insert(0, "Bu ").Replace("geç","erken"));
                // // Console.WriteLine(str3.ToLower());
                // // string str5 = str3.ToLower();
                // // Console.WriteLine(str5.Insert(0, "Bu "));
                // Console.WriteLine(str3.Substring(5));

                // Console.WriteLine("Adı :{0,12}","ahmetkabak");
                // Console.WriteLine("Adı :{0,-12}","ahmetkabak");
                // Console.WriteLine();

                // float f = 568.87f;
                // int a = 105;
                // Console.WriteLine("==>{0:C3}",a);
                // Console.WriteLine("==>{0:D5}",a);
                // Console.WriteLine("==>{0:E4}",f);
                // Console.WriteLine("==>{0:F3}",f);
                // Console.WriteLine("==>{0:G5}",a);
                // Console.WriteLine("==>{0:N1}",f);
                // Console.WriteLine("==>{0:P}",a);
                // Console.WriteLine("==>{0:X5}",a);

                // int t = 50;
                // string s = String.Format("{0:c3}",t);
                // Console.WriteLine(s);
                // string s1 = t.ToString("c2");
                // Console.WriteLine(s1);

                // DateTime dt = DateTime.Now;

                // Console.WriteLine("d--> {0:d}",dt);
                // Console.WriteLine("d--> {0:D}\n",dt);

                // Console.WriteLine("d--> {0:#,###}\n",1555000);
                // Console.WriteLine("d--> {0:#,###.##}\n",15550.156);
                // Console.WriteLine("d--> {0:#%}\n",0.2);



























































            } while (secim.ToLower() != "q");
        }
    }
}
