using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleriSon
{
    internal class Galeri
    {
        public List<Araba> Arabalar = new List<Araba>();

        public Galeri() => this.SahteVeriGir();

        public int GaleridekiAracSayisi
        {
            get
            {
                return this.Arabalar.Where<Araba>((Func<Araba, bool>)(a => a.Durum == "Galeride")).ToList<Araba>().Count;
            }
        }

        public int KiradakiAracSayisi
        {
            get
            {
                return this.Arabalar.Where<Araba>((Func<Araba, bool>)(t => t.Durum == "Kirada")).ToList<Araba>().Count;
            }
        }

        public int ToplamAracSayisi => this.Arabalar.Count;

        public int ToplamAracKiralamaSuresi
        {
            get => this.Arabalar.Sum<Araba>((Func<Araba, int>)(a => a.KiralamaSureleri.Sum()));
        }

        public int ToplamAracKiralamaAdedi
        {
            get => this.Arabalar.Sum<Araba>((Func<Araba, int>)(a => a.KiralamaSayisi));
        }

        public float Ciro
        {
            get
            {
                return this.Arabalar.Sum<Araba>((Func<Araba, float>)(a => (float)a.ToplamKiralamaSuresi * a.KiralamaBedeli));
            }
        }

        public void ArabaEkle(string plaka, string marka, float kiralamaBedeli, string aracTipi)
        {
            this.Arabalar.Add(new Araba(plaka, marka, kiralamaBedeli, aracTipi));
        }

        public void SahteVeriGir()
        {
            this.ArabaEkle("34arb3434", "FIAT", 70f, "Sedan");
            this.ArabaEkle("35arb3535", "KIA", 60f, "SUV");
            this.ArabaEkle("34us2342", "OPEL", 50f, "Hatchback");
        }

        public string DurumGetir(string plaka)
        {
            Araba araba = this.Arabalar.Where<Araba>((Func<Araba, bool>)(a => a.Plaka == plaka.ToUpper())).FirstOrDefault<Araba>();
            return araba != null ? araba.Durum : "ArabaYok";
        }

        public void ArabaKirala(string plaka, int sure)
        {
            Araba araba = this.Arabalar.Where<Araba>((Func<Araba, bool>)(a => a.Plaka == plaka.ToUpper())).FirstOrDefault<Araba>();
            if (araba == null || !(araba.Durum == "Galeride"))
                return;
            araba.Durum = "Kirada";
            araba.KiralamaSureleri.Add(sure);
        }

        public List<Araba> ArabaListesiGetir(string durum)
        {
            List<Araba> arabaList = this.Arabalar;
            if (durum == "Kirada" || durum == "Galeride")
                arabaList = this.Arabalar.Where<Araba>((Func<Araba, bool>)(a => a.Durum == durum)).ToList<Araba>();
            return arabaList;
        }

        public void ArabaTeslimAl(string plaka)
        {
            Araba araba = this.Arabalar.Where<Araba>((Func<Araba, bool>)(a => a.Plaka == plaka.ToUpper())).FirstOrDefault<Araba>();
            if (araba == null)
                throw new Exception("Bu plakada bir araç yok.");
            araba.Durum = !(araba.Durum == "Galeride") ? "Galeride" : throw new Exception("Zaten galeride");
        }

        public void KiralamaIptal(string plaka)
        {
            Araba araba = this.Arabalar.Where<Araba>((Func<Araba, bool>)(a => a.Plaka == plaka.ToUpper())).FirstOrDefault<Araba>();
            if (araba == null)
                return;
            araba.Durum = "Galeride";
            araba.KiralamaSureleri.RemoveAt(araba.KiralamaSureleri.Count - 1);
        }

        public void ArabaSil(string plaka)
        {
            Araba araba = this.Arabalar.Where<Araba>((Func<Araba, bool>)(x => x.Plaka == plaka.ToUpper())).FirstOrDefault<Araba>();
            if (araba == null || !(araba.Durum == "Galeride"))
                return;
            this.Arabalar.Remove(araba);
        }
    }
}
