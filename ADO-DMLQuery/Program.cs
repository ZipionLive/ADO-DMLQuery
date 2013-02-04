using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ADO_DMLQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectString = @"Data Source = ASPIRE-5560G\ZLSQL; Initial Catalog = DBSlides; Integrated Security = True";

            try
            {
                SqlConnection db = new SqlConnection();
                db.ConnectionString = connectString;

                string dmlQueryDel = "DELETE FROM student WHERE student_id > 25";
                string dmlQueryIns = "INSERT INTO student (student_id, first_name, last_name, birth_date, login, section_id, year_result, course_id) VALUES (26, 'Darren', 'Aronofsky', '19650513', 'darono', 1020, 18, 'EG2110')";

                SqlCommand delCmd = db.CreateCommand();
                delCmd.CommandText = dmlQueryDel;

                db.Open();
                try
                {
                    int delRows = delCmd.ExecuteNonQuery();
                    Console.WriteLine(delRows + " lignes affectées par le DELETE");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("DELETE échoué\n{0}", ex.Message));
                }
                db.Close();

                SqlCommand insCmd = db.CreateCommand();
                insCmd.CommandText = dmlQueryIns;

                db.Open();
                try
                {
                    int insRows = insCmd.ExecuteNonQuery();
                    Console.WriteLine(insRows + " lignes affectées par le INSERT");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("INSERT échoué\n{0}", ex.Message));
                }
                db.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
