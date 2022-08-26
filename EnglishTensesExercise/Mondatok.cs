using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTensesExercise
{
    class Mondatok
    {
        int? id;
        string mondat;
        List<Kerdesek> kerdes = new List<Kerdesek>();
        Igeidok igeidok;

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

        public string Mondat { get => mondat; set => mondat = value; }
        internal List<Kerdesek> Kerdes { get => kerdes; set => kerdes = value; }
        internal Igeidok Igeidok { get => igeidok; /*set => igeidok = value;*/ }

        public Mondatok(int? id, Igeidok igeidok, string mondat/*, List<Kerdesek> kerdes*/)
        {
            ID = id;
            this.igeidok = igeidok;
            Mondat = mondat;
            Kerdes = kerdes;
            kerdes = new List<Kerdesek>();
        }

        public Mondatok(Igeidok igeidok, string mondat/*, List<Kerdesek> kerdes*/)
        {
            this.igeidok = igeidok;
            Mondat = mondat;
            //Kerdes = kerdes;
            kerdes = new List<Kerdesek>();
        }
    }
}
