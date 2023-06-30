using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;

namespace Testfall2DBCSharpN
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<string> dirs = new List<string>(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory).Split('\\'));
            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + String.Join(@"\", dirs) + @"\Testfall2DB.mdf;Integrated Security=True;Connect Timeout=5";

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand insertCommand = con.CreateCommand())
                        {
                            insertCommand.Transaction = transaction;
                            insertCommand.CommandText = "INSERT INTO Testdaten VALUES (@Id, @Name, @Wert)";
                            insertCommand.Parameters.Add(new SqlParameter("Id", 0));
                            insertCommand.Parameters.Add(new SqlParameter("Name", ""));
                            insertCommand.Parameters.Add(new SqlParameter("Wert", 0));

                            for (int i = 1; i <= 50000; i++)
                            {
                                insertCommand.Parameters["Id"].Value = i;
                                insertCommand.Parameters["Name"].Value = "Testdatei" + i;
                                insertCommand.Parameters["Wert"].Value = i + i;
                                insertCommand.ExecuteNonQuery();
                            }
                        }

                        using (SqlCommand updateCommand = con.CreateCommand())
                        {
                            updateCommand.Transaction = transaction;
                            updateCommand.CommandText = "UPDATE Testdaten SET Wert = 0 WHERE Id = @Id";
                            updateCommand.Parameters.Add(new SqlParameter("Id", 0));

                            for (int i = 1; i <= 50000; i++)
                            {
                                updateCommand.Parameters["Id"].Value = i;
                                updateCommand.ExecuteNonQuery();
                            }
                        }

                        using (SqlCommand deleteCommand = con.CreateCommand())
                        {
                            deleteCommand.Transaction = transaction;
                            deleteCommand.CommandText = "DELETE FROM Testdaten WHERE Id = @Id";
                            deleteCommand.Parameters.Add(new SqlParameter("Id", 0));

                            for (int i = 1; i <= 50000; i++)
                            {
                                deleteCommand.Parameters["Id"].Value = i;
                                deleteCommand.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        Console.WriteLine("Fertig");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Fehler bei Transaktion" + ex.Message);
                    }
                }
            }

            stopwatch.Stop();
            Console.WriteLine("Laufzeit: " + stopwatch.Elapsed);
            Console.ReadKey();
        }
    }
}
