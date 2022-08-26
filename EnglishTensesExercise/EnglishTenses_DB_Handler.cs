using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTensesExercise
{
    class EnglishTenses_DB_Handler
    {
        static SqlConnection connection;
        static SqlCommand command;


        public static void ConnectionOpen(string conStrNev)
        {
            try
            {
                connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings[conStrNev].ConnectionString;
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
            }
            catch (Exception ex)
            {
                throw new DB_Exeption("Connection opening was unsuccessful!", ex);
            }           
        }

        public static void ConnetionClose()
        {
            try
            {
                connection.Close();
                command.Dispose();
            }
            catch (Exception ex)
            {
                throw new DB_Exeption("Connection closing was unsuccessful!", ex);
            }
        }

        public static void InsertScore(Pontszamok pontszamok)
        {
            try
            {
                command.Parameters.Clear();
                command.Transaction = connection.BeginTransaction();
                command.CommandText = "INSERT INTO [Pontszamok] VALUES (@felhasznalNeve, @igeidokID, @pontszam)";               
                command.Parameters.AddWithValue("@felhasznalNeve", pontszamok.FelhasznaloNeve.ToString());
                command.Parameters.AddWithValue("@IgeidokID", (int)pontszamok.Igeidok + 1);
                command.Parameters.AddWithValue("@pontszam", pontszamok.Pontszam);
                command.ExecuteNonQuery();
                command.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    if (command.Transaction != null)
                    {
                        command.Transaction.Rollback();
                    }
                }
                catch (Exception innerEx)
                {
                    throw new DB_Exeption("Fatal error! Database intervention is required!", innerEx);
                }
                throw new DB_Exeption("Score data recording was unsaccessful!", ex);
            }
        } 

        public static void ModifyScore(Pontszamok pontszamok)
        {
            try
            {
                command.Parameters.Clear();
                command.Transaction = connection.BeginTransaction();
                command.CommandText = "UPDATE Pontszamok SET Pontszam = @pontszam WHERE PontszamokID = @id";
                command.Parameters.AddWithValue("@id", pontszamok.ID);
                command.Parameters.AddWithValue("@pontszam",  (int)pontszamok.Pontszam);
                command.ExecuteNonQuery();
                command.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    if (command.Transaction != null)
                    {
                        command.Transaction.Rollback();
                    }
                }
                catch (Exception innerEx)
                {
                    throw new DB_Exeption("Fatal error! Database intervention is required!", innerEx);
                }
                throw new DB_Exeption("Score data modifying was unsaccessful!!", ex);
            }
        }

        public static void DeleteScores(Pontszamok pontszamok)
        {
            try
            {
                command.Parameters.Clear();
                command.Transaction = connection.BeginTransaction();
                command.CommandText = "DELETE FROM Pontszamok WHERE PontszamokID = @id";
                command.Parameters.AddWithValue("@id", pontszamok.ID);
                command.ExecuteNonQuery();
                command.Transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    if (command.Transaction != null)
                    {
                        command.Transaction.Rollback();
                    }
                }
                catch (Exception innerEx)
                {
                    throw new DB_Exeption("Fatal error! Database intervention is required!", innerEx);
                }
                throw new DB_Exeption("Score data deleting was unsaccessful!!", ex);
            }
        }

        public static List<Pontszamok> ReadScore()
        {            
            try
            {
                List<Pontszamok> pontszamok = new List<Pontszamok>();
                command.Parameters.Clear();
                command.CommandText = "SELECT * FROM Pontszamok";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (pontszamok.Count == 0 || pontszamok.Last().ID != (int)reader["PontszamokID"])
                        {
                            pontszamok.Add(new Pontszamok(
                                (int)reader["PontszamokID"],
                                (Igeidok)((int)reader["IgeidokID"] - 1),
                                reader["FelhasznaloNeve"].ToString(),
                                (int)reader["Pontszam"]
                                )); 

                        }
                    }
                    reader.Close();

                    return pontszamok;
                }
            }
            catch (Exception ex)
            {

                throw new DB_Exeption("Data reading was unsuccessful! (Pontszamok)", ex);
            }

        }

        public static List<Mondatok> ReadSentences(Igeidok igeido)
        {
            try
            {
                command.Parameters.Clear();
                command.CommandText = "SELECT * FROM Mondatok LEFT JOIN [Kerdesek] ON Mondatok.MondatokID = Kerdesek.MondatokID";
                List<Mondatok> mondat = new List<Mondatok>();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (igeido == (Igeidok)((int)reader["IgeidokID"] - 1))
                        {
                            if (mondat.Count == 0 || mondat.Last().ID != (int)reader["MondatokID"])
                            {
                                mondat.Add(new Mondatok(
                                    (int)reader["MondatokID"],
                                     (Igeidok)((int)reader["IgeidokID"] - 1),
                                     reader["Mondatok"].ToString()
                                    )); 
                            }
                      
                            mondat.Last().Kerdes.Add(new Kerdesek(
                                reader["Kerdes"].ToString(),
                                (bool)reader["HelyesE"],
                                (int)reader["Mondat_Pozicio"]
                                )); 
                        }
                    }

                    reader.Close();

                    return mondat;
                }
            }
            catch (Exception ex)
            {

                throw new DB_Exeption("Data reading was unsuccessful! (Mondatok)", ex);
            }
        }
    }
}
