using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleriSon
{

    internal class AracGerecler
    {
        public static bool PlakaMi(string veri)
        {
            int result;

            if (veri.Length > 6 && veri.Length < 10 &&
                int.TryParse(veri.Substring(0, 2), out result) &&
                AracGerecler.HarfMi(veri.Substring(2, 1)))
            {
                if (veri.Length == 7 && int.TryParse(veri.Substring(3), out result))
                {
                    return true;
                }
                else if (veri.Length < 9 && AracGerecler.HarfMi(veri.Substring(3, 1)) &&
                         int.TryParse(veri.Substring(4), out result))
                {
                    return true;
                }
                else if (AracGerecler.HarfMi(veri.Substring(3, 2)) &&
                         int.TryParse(veri.Substring(5), out result))
                {
                    return true;
                }
            }

            return false;

        }

        public static bool HarfMi(string veri)
        {
            veri = veri.ToUpper();
            for (int index = 0; index < veri.Length; ++index)
            {
                int num = (int)veri[index];
                if (num < 65 || num > 90)
                    return false;
            }
            return true;
        }

        public static string YaziAl(string yazi)
        {
            while (true)
            {
                try
                {
                    Console.Write(yazi);
                    string upper = Console.ReadLine().ToUpper();
                    if (int.TryParse(upper, out int _))
                        throw new Exception("Giriş tanımlanamadı. Tekrar deneyin.");
                    return upper == "X" ? upper : upper;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static int SayiAl(string mesaj)
        {
            while (true)
            {
                try
                {
                    Console.Write(mesaj);
                    string upper = Console.ReadLine().ToUpper();
                    int result;
                    if (int.TryParse(upper, out result))
                        return result;
                    if (upper == "X")
                        throw new Exception("Çıkış");
                    throw new Exception("Giriş tanımlanamadı. Tekrar deneyin.");
                }
                catch (Exception ex)
                {
                    if (ex.Message == "Çıkış")
                        throw new Exception("Çıkış");
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static string PlakaAl(string mesaj)
        {
            while (true)
            {
                try
                {
                    Console.Write(mesaj);
                    string upper = Console.ReadLine().ToUpper();
                    if (upper == "X")
                        return "X";
                    return AracGerecler.PlakaMi(upper) ? upper : throw new Exception("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static string AracTipiAl()
        {
            Console.WriteLine("Araç tipi: ");
            Console.WriteLine("SUV için 1");
            Console.WriteLine("Hatchback için 2");
            Console.WriteLine("Sedan için 3");
            while (true)
            {
                Console.Write("Araba Tipi: ");
                string upper = Console.ReadLine().ToUpper();
                if (!(upper == "X"))
                {
                    switch (upper)
                    {
                        case "1":
                            goto label_SUV;
                        case "2":
                            goto label_Hatchback;
                        case "3":
                            goto label_Sedan;
                        default:
                            Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                            continue;
                    }
                }
                else
                    break;
            }
            throw new Exception("Çıkış");
        label_SUV:
            return "SUV";
        label_Hatchback:
            return "Hatchback";
        label_Sedan:
            return "Sedan";
        }
    }
}
