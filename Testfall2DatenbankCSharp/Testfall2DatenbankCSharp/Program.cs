using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testfall2DatenbankCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<string> dirs = new List<string>(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory).Split('\\'));
            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + String.Join(@"\", dirs) +  @"\Testfall2DB.mdf;Integrated Security=True;Connect Timeout=5";
            //string conString = @"Data Source=.\SQLEXPRESS;AttachDbFileName=|DataDirectory|\Testfall2DB.mdf;Integrated Security=True;Connect Timeout=5";
            SqlConnection con = new SqlConnection(conString);
            con.Open();


            SqlCommand cmd = new SqlCommand();

            string SQL = "";

            // INSERT
            for (int i = 1; i <= 50000; i++)
            {
                SQL = "insert into Testdaten values (@Id, @Name, @Wert)";
                cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("Id", i));
                cmd.Parameters.Add(new SqlParameter("Name", "Testdatei" + i));
                cmd.Parameters.Add(new SqlParameter("Wert", i + i));
                cmd.ExecuteNonQuery();
            }

            //Update
            for (int i = 1; i <= 50000; i++)
            {
                SQL = "update Testdaten set Wert = 0 where Id = @id";
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = SQL;
                cmd.Parameters.Add(new SqlParameter("id", i));
                cmd.ExecuteNonQuery();
            }

            //Delete
            for (int i = 1; i <= 50000; i++)
            {
                SQL = "delete from Testdaten where Id = @id";
                cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("id", i));
                cmd.ExecuteNonQuery();
            }

            con.Close();
            stopwatch.Stop();
            Console.WriteLine("Fertig");
            Console.WriteLine("Laufzeit: " + stopwatch.Elapsed);
            Console.ReadKey();
        }
    }
}
