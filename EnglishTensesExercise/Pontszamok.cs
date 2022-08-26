using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTensesExercise
{
    class Pontszamok
    {
        int? id;
        string felhasznaloNeve;
        Igeidok igeidok;
        int pontszam;

        public int? ID
        {
            get => id;
            set
            {
                if (id == null)
                {
                    id = value;
                }
                else
                {
                    throw new InvalidOperationException("Az ID változtatása csak egyszer lehetséges");
                }
            }
        }
        public string FelhasznaloNeve 
        { 
            get => felhasznaloNeve; 
            set
            {
                if (felhasznaloNeve == null)
                {
                    felhasznaloNeve = value;
                }
                else
                {
                    throw new InvalidOperationException("Az felhasznaló nevének változtatása csak egyszer lehetséges");
                }
            }
        }
        public int Pontszam 
        { 
            get => pontszam;
            set
            {
                if (pontszam >= 0)
                {
                    pontszam = value;
                }
                else
                {
                    throw new InvalidOperationException("A pontszám nem lehet 0-nál kisebb!");
                }
            }
        }
        internal Igeidok Igeidok { get => igeidok; /*set => igeidok = value;*/ }
       

        public Pontszamok(Igeidok igeidok, string felhasznaloNeve,  int pontszam)
        {
            this.igeidok = igeidok;
            this.felhasznaloNeve = felhasznaloNeve;
            Pontszam = pontszam;
        }

        public Pontszamok(int? id, Igeidok igeidok, string felhasznaloNeve, int pontszam)
        {
            ID = id;
            this.igeidok = igeidok;
            FelhasznaloNeve = felhasznaloNeve;
            Pontszam = pontszam;
        }

        public override string ToString()
        {
            return felhasznaloNeve + "\t-\t" + igeidok + "\t-\t" + pontszam;
        }

    }
}
