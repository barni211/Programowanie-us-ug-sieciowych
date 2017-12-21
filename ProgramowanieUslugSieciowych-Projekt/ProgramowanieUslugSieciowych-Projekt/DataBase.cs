using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramowanieUslugSieciowych_Projekt
{
    public class DataBase
    {
        //private static DataBase instance = new DataBase();

        private int idLoggedCoach;

        private SqlConnection connection;

        private string connectionString =

               "Server = tcp:fitfactory.database.windows.net,1433; Initial Catalog = fitfactory_database; Persist Security Info = False; User ID = fitfactoryadmin; Password = &(@#(*$yh383; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        public DataBase()

        {

            this.connection = new SqlConnection(connectionString);
            connection.Open();

        }



        public DataBase GetInstance()

        {
            return this;
        }



        public DataTable ExecuteStoredProcedure(string query)
        {

            DataTable dt = new DataTable();
        
            try
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Nie udało się przeprowadzić operacji na bazie. " + ex.ToString());
                return null;
            }

        }

        public DataTable CheckLogin(String login, String haslo)

        {

            DataTable result = new DataTable();
            //  result.Columns.Add(new DataColumn("wynik"));
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "czyLoginHasloIstnieje";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@p_login", login);
                cmd.Parameters.AddWithValue("@p_haslo", haslo);
                cmd.Parameters.AddWithValue("@p_typ", "T");
                //cmd.ExecuteNonQuery();



                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(result);
                return result;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Nie udało się przeprowadzić operacji na bazie. " + ex.ToString());
                return null;
            }
        }
    }
}
