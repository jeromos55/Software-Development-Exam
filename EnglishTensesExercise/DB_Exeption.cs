using System;
using System.Runtime.Serialization;

namespace EnglishTensesExercise
{
    [Serializable]
    internal class DB_Exeption : Exception
    {      
        public DB_Exeption(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}