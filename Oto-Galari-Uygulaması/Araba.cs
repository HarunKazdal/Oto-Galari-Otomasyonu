using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleriSon
{
    internal class Araba
    {
        public List<int> KiralamaSureleri = new List<int>();

        public string Plaka { get; set; }

        public string Marka { get; set; }

        public float KiralamaBedeli { get; set; }

        public string AracTipi { get; set; }

        public string Durum { get; set; }

        public int KiralamaSayisi => this.KiralamaSureleri.Count;

        public int ToplamKiralamaSuresi => this.KiralamaSureleri.Sum();

        public Araba(string plaka, string marka, float kiralamaBedeli, string aracTipi)
        {
            this.Plaka = plaka.ToUpper();
            this.Marka = marka.ToUpper();
            this.KiralamaBedeli = kiralamaBedeli;
            this.AracTipi = aracTipi;
            this.Durum = "Galeride";
        }
    }
}
