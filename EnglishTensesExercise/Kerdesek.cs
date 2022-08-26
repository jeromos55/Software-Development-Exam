using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTensesExercise
{
    enum Igeidok
    {
        PastSimple,
        PresentSimple,
        FutureSimple,
        PastPerfect,
        PresentPerfect,
        FuturePerfect,
        PastContinous,
        PresentContinous,
        FutureContinous,
        PastPerfectContinous,
        PresentPerfectContinous,
        FuturePerfectContinous,
        Simple,
        Perfect,
        Continouos,
        PerfectContinuos,
        Past,
        Present,
        Future,
        All
    }

    class Kerdesek
    {
        string kerdes;
        int mondatPozicio;
        Boolean helyesE; // default false = 0

        public string Kerdes { get => kerdes; /*set => kerdes = value;*/ }

        //public string MondatPozicio { get => mondatPozicio; /*set => mondatPozicio = value;*/ }
        public int MondatPozicio
        {
            get => mondatPozicio;
            set
            {
                if (value > 0)
                {
                    mondatPozicio = value;
                }
                else
                {
                    throw new InvalidOperationException("A pozició nem lehet kisebb egynél!");
                }
            }
        }
        public bool HelyesE { get => helyesE; /*set => helyesE = value;*/ }

        public Kerdesek(string kerdes, bool helyesE, int mondatPozicio)
        {
            this.kerdes = kerdes;
            this.helyesE = helyesE;
            MondatPozicio = mondatPozicio;
        }
    }
}
