using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public void RegisterNewUserInDb(String login, String haslo, string email)
        {

            DataTable result = new DataTable();
            //  result.Columns.Add(new DataColumn("wynik"));
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "PUS.RegisterNewUser";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@Login", login);
                cmd.Parameters.AddWithValue("@Password", haslo);
                cmd.Parameters.AddWithValue("@Email", email);
                //cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(result);
                //return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie udało się przeprowadzić operacji na bazie. " + ex.ToString());
               // return null;
            }
        }

        public string LoginIntoApplication(string login, string haslo)
        {
            DataTable result = new DataTable();
            string username = null;
            //  result.Columns.Add(new DataColumn("wynik"));
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "PUS.CheckThatUserExists";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@Login", login);
                cmd.Parameters.AddWithValue("@Password", haslo);
                //cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(result);

                if(result.Rows.Count > 0)
                {
                    username = result.Rows[0]["ID"].ToString() + "@" + result.Rows[0]["LOGIN"].ToString();
                }
                //return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie udało się przeprowadzić operacji na bazie. " + ex.ToString());
                // return null;
            }

            return username;
        }

        public void SendMessageToUser(String message, String sender, String receiver)
        {

            DataTable result = new DataTable();
            //  result.Columns.Add(new DataColumn("wynik"));
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "PUS.SendMessageToUser";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@MESSAGE", message);
                cmd.Parameters.AddWithValue("@SENDER", sender);
                cmd.Parameters.AddWithValue("@RECEIVER", receiver);
                //cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(result);
                //return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie udało się przeprowadzić operacji na bazie. " + ex.ToString());
                // return null;
            }
        }

        public DataTable ShowFriendList(String user)
        {
            DataTable result = new DataTable();
            //  result.Columns.Add(new DataColumn("wynik"));
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "PUS.ShowFriendsList";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@USER", user);
            
                //cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(result);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie udało się przeprowadzić operacji na bazie. " + ex.ToString());
                 return null;
            }

        }

        public void AddNewFriend(String user, String friend)
        {
            DataTable result = new DataTable();
            //  result.Columns.Add(new DataColumn("wynik"));
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "PUS.AddNewFriend";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@OWNER", user);
                cmd.Parameters.AddWithValue("@FRIEND", friend);

                //cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(result);
                //return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie udało się przeprowadzić operacji na bazie. " + ex.ToString());
                //return null;
            }
        }


    }
}
