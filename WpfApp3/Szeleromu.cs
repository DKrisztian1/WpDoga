using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzeleromuClass
{
    internal class Szeleromu
    {
        string telepules;
        int egysegekSzama;
        int teljesitmeny;
        int kezdetiEv;

        public Szeleromu(string telepules, int egysegekSzama, int teljesitmeny, int kezdetiEv)
        {
            this.telepules = telepules;
            this.egysegekSzama = egysegekSzama;
            this.teljesitmeny = teljesitmeny;
            this.kezdetiEv = kezdetiEv;
        }

        public string Telepules { get => telepules; set => telepules = value; }
        public int EgysegekSzama { get => egysegekSzama; set => egysegekSzama = value; }
        public int Teljesitmeny { get => teljesitmeny; set => teljesitmeny = value; }
        public int KezdetiEv { get => kezdetiEv; set => kezdetiEv = value; }

        public static char TeljesitmenySzamolas(int kapottTelj)
        {
            if (kapottTelj >= 1000)
                return 'A';
            else if (kapottTelj > 500)
                return 'B';
            else
                return 'C';
        }
    }
}
