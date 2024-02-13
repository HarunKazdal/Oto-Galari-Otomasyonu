using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleriSon
{
    internal class Proje
    {
        private Galeri OtoGaleri = new Galeri();
        static bool devamMi = true;
        private int sayac = 0;
        public void Uygulama()
        {
            this.Menu();
            while (true)
            {
                string str1 = this.SecimAl();
                Console.WriteLine();
                string str2 = str1;
                if (str2 != null)
                {
                    switch (str2.Length)
                    {
                        case 1:
                            switch (str2[0])
                            {
                                case '1':
                                case 'K':
                                    this.ArabaKirala();
                                    goto label_SON;
                                case '2':
                                case 'T':
                                    this.ArabaTeslimi();
                                    goto label_SON;
                                case '3':
                                case 'R':
                                    this.ArabalariListele("Kirada");
                                    goto label_SON;
                                case '4':
                                case 'M':
                                    this.ArabalariListele("Galeride");
                                    goto label_SON;
                                case '5':
                                case 'A':
                                    this.ArabalariListele("ArabaYok");
                                    goto label_SON;
                                case '6':
                                case 'I':
                                    this.KiralamaIptal();
                                    goto label_SON;
                                case '7':
                                case 'Y':
                                    this.YeniAraba();
                                    goto label_SON;
                                case '8':
                                case 'S':
                                    this.ArabaSil();
                                    goto label_SON;
                                case '9':
                                case 'G':
                                    this.BilgileriGoster();
                                    goto label_SON;
                                case 'X':
                                    goto label_SON;
                            }
                            break;
                        case 5:
                            if (str2 == "ÇIKIŞ")
                            {
                                this.Cikis();
                                goto label_SON;
                            }
                            else
                                break;
                    }
                }
                Console.WriteLine("Hatalı işlem gerçekleştirildi. Tekrar deneyin.");
                ++this.sayac;
            label_SON:;
            }
        }
        public void Menu()
        {
            Console.WriteLine("Galeri Otomasyon                    ");
            Console.WriteLine("1- Araba Kirala (K)                 ");
            Console.WriteLine("2- Araba Teslim Al (T)              ");
            Console.WriteLine("3- Kiradaki Arabaları Listele (R)   ");
            Console.WriteLine("4- Galerideki Arabaları Listele (M) ");
            Console.WriteLine("5- Tüm Arabaları Listele (A)        ");
            Console.WriteLine("6- Kiralama İptali (I)              ");
            Console.WriteLine("7- Araba Ekle (Y)                   ");
            Console.WriteLine("8- Araba Sil (S)                    ");
            Console.WriteLine("9- Bilgileri Göster (G)             ");
        }

        public string SecimAl()
        {
            if (this.sayac != 10)
            {
                Console.WriteLine();
                Console.Write("Seçiminiz: ");
                return Console.ReadLine().ToUpper();
            }
            Console.WriteLine();
            Console.WriteLine("Üzgünüm sizi anlayamıyorum. Program sonlandırılıyor.");
            return "ÇIKIŞ";
        }

        public void Cikis() => Environment.Exit(0);

        public void ArabaKirala()
        {
            Console.WriteLine("-Araba Kirala-");
            Console.WriteLine();
            try
            {
                if (this.OtoGaleri.Arabalar.Count == 0)
                    throw new Exception("Galeride hiç araba yok.");
                if (this.OtoGaleri.GaleridekiAracSayisi == 0)
                    throw new Exception("Tüm araçlar kirada.");
                string plaka;
                while (true)
                {
                    plaka = AracGerecler.PlakaAl("Kiralanacak arabanın plakası: ");
                    if (!(plaka == "X"))
                    {
                        switch (this.OtoGaleri.DurumGetir(plaka))
                        {
                            case "Kirada":
                                Console.WriteLine("Araba şu anda kirada. Farklı araba seçiniz.");
                                break;
                            case "ArabaYok":
                                Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                                break;
                            default:
                                goto label_KiralanmaSüresi;
                        }
                    }
                    else
                        break;
                }
                return;
                label_KiralanmaSüresi:
                int sure = AracGerecler.SayiAl("Kiralanma süresi: ");
                this.OtoGaleri.ArabaKirala(plaka, sure);
                Console.WriteLine();
                Console.WriteLine(plaka.ToUpper() + " plakalı araba " + sure.ToString() + " saatliğine kiralandı.");
            }
            catch (Exception ex)
            {
                if (ex.Message == "Çıkış")
                    return;
                Console.WriteLine(ex.Message);
            }
        }

        public void ArabaTeslimi()
        {
            Console.WriteLine("-Araba Teslim Al-");
            Console.WriteLine();
            try
            {
                if (this.OtoGaleri.Arabalar.Count == 0)
                    throw new Exception("Galeride hiç araba yok.");
                if (this.OtoGaleri.KiradakiAracSayisi == 0)
                    throw new Exception("Kirada hiç araba yok.");
                string plaka;
                while (true)
                {
                    plaka = AracGerecler.PlakaAl("Teslim edilecek arabanın plakası: ");
                    if (!(plaka == "X"))
                    {
                        switch (this.OtoGaleri.DurumGetir(plaka))
                        {
                            case "Galeride":
                                Console.WriteLine("Hatalı giriş yapıldı. Araba zaten galeride.");
                                break;
                            case "ArabaYok":
                                Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                                break;
                            default:
                                goto label_ArabaTeslimAl;
                        }
                    }
                    else
                        break;
                }
                return;
                label_ArabaTeslimAl:
                this.OtoGaleri.ArabaTeslimAl(plaka);
                Console.WriteLine();
                Console.WriteLine("Araba galeride beklemeye alındı.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ArabalariListele(string durum)
        {
            switch (durum)
            {
                case "Kirada":
                    Console.WriteLine("-Kiradaki Arabalar-");
                    break;
                case "Galeride":
                    Console.WriteLine("-Galerideki Arabalar-");
                    break;
                default:
                    Console.WriteLine("-Tüm Arabalar-");
                    break;
            }
            Console.WriteLine();
            this.ArabaListele(this.OtoGaleri.ArabaListesiGetir(durum));
        }

        public void ArabaListele(List<Araba> liste)
        {
            if (liste.Count == 0)
            {
                Console.WriteLine("Listelenecek araç yok.");
            }
            else
            {
                Console.WriteLine("Plaka".PadRight(14) + "Marka".PadRight(12) + "K. Bedeli".PadRight(12) + "Araba Tipi".PadRight(12) + "K. Sayısı".PadRight(12) + "Durum");
                Console.WriteLine("".PadRight(70, '-'));
                foreach (Araba araba in liste)
                    Console.WriteLine(araba.Plaka.PadRight(14) + araba.Marka.PadRight(12) + araba.KiralamaBedeli.ToString().PadRight(12) + araba.AracTipi.ToString().PadRight(12) + araba.KiralamaSayisi.ToString().PadRight(12) + araba.Durum);
            }
        }

        public void KiralamaIptal()
        {
            Console.WriteLine("-Kiralama İptali-");
            Console.WriteLine();
            try
            {
                if (this.OtoGaleri.KiradakiAracSayisi == 0)
                    throw new Exception("Kirada araba yok.");
                string plaka;
                while (true)
                {
                    plaka = AracGerecler.PlakaAl("Kiralaması iptal edilecek arabanın plakası: ");
                    if (!(plaka == "X"))
                    {
                        switch (this.OtoGaleri.DurumGetir(plaka))
                        {
                            case "Galeride":
                                Console.WriteLine("Hatalı giriş yapıldı. Araba zaten galeride.");
                                break;
                            case "ArabaYok":
                                Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                                break;
                            default:
                                goto label_Kiralamaİptali;
                        }
                    }
                    else
                        break;
                }
                return;
                label_Kiralamaİptali:
                this.OtoGaleri.KiralamaIptal(plaka);
                Console.WriteLine();
                Console.WriteLine("İptal gerçekleştirildi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void YeniAraba()
        {
            Console.WriteLine("-Araba Ekle-");
            Console.WriteLine();
            try
            {
                string plaka;
                while (true)
                {
                    plaka = AracGerecler.PlakaAl("Plaka: ");
                    if (!(plaka == "X"))
                    {
                        if (this.OtoGaleri.DurumGetir(plaka) == "Kirada" || this.OtoGaleri.DurumGetir(plaka) == "Galeride")
                            Console.WriteLine("Aynı plakada araba mevcut. Girdiğiniz plakayı kontrol edin.");
                        else
                            goto label_ArabaEkle;
                    }
                    else
                        break;
                }
                return;
                label_ArabaEkle:
                string marka = AracGerecler.YaziAl("Marka: ");
                if (marka == "X")
                    return;
                float kiralamaBedeli = (float)AracGerecler.SayiAl("Kiralama bedeli: ");
                string aracTipi = AracGerecler.AracTipiAl();
                this.OtoGaleri.ArabaEkle(plaka, marka, kiralamaBedeli, aracTipi);
                Console.WriteLine();
                Console.WriteLine("Araba başarılı bir şekilde eklendi.");
            }
            catch (Exception ex)
            {
                if (ex.Message == "Çıkış")
                    return;
                Console.WriteLine(ex.Message);
            }
        }

        public void ArabaSil()
        {
            Console.WriteLine("-Araba Sil-");
            Console.WriteLine();
            try
            {
                if (this.OtoGaleri.Arabalar.Count == 0)
                    throw new Exception("Galeride silinecek araba yok.");
                string plaka;
                while (true)
                {
                    plaka = AracGerecler.PlakaAl("Silmek istediğiniz arabanın plakasını giriniz: ");
                    if (!(plaka == "X"))
                    {
                        if (this.OtoGaleri.DurumGetir(plaka) == "ArabaYok")
                            Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                        else if (this.OtoGaleri.DurumGetir(plaka) == "Kirada")
                            Console.WriteLine("Araba kirada olduğu için silme işlemi gerçekleştirilemedi.");
                        else
                            goto label_ArabaSil;
                    }
                    else
                        break;
                }
                return;
                label_ArabaSil:
                this.OtoGaleri.ArabaSil(plaka);
                Console.WriteLine();
                Console.WriteLine("Araba silindi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void BilgileriGoster()
        {
            Console.WriteLine("-Galeri Bilgileri-");
            Console.WriteLine("Toplam araba sayısı: " + this.OtoGaleri.ToplamAracSayisi.ToString());
            Console.WriteLine("Kiradaki araba sayısı: " + this.OtoGaleri.KiradakiAracSayisi.ToString());
            Console.WriteLine("Bekleyen araba sayısı: " + this.OtoGaleri.GaleridekiAracSayisi.ToString());
            Console.WriteLine("Toplam araba kiralama süresi: " + this.OtoGaleri.ToplamAracKiralamaSuresi.ToString());
           Console.WriteLine("Toplam araba kiralama adedi: " + this.OtoGaleri.ToplamAracKiralamaAdedi.ToString());
            Console.WriteLine("Ciro: " + this.OtoGaleri.Ciro.ToString());
        }
    }
}
