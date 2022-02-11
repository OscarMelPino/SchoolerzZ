using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginSchoolerzZ
{
    public class DatabaseConnection
    {
        private String host, port, username, password, database;
        private String connectionString;
        private MySqlConnection connection;
        private MySqlCommand command;
        DataSet resultados = new DataSet();
        public DatabaseConnection()
        {
            host = "172.16.51.7";
            port = "3306";
            username = "alvaro";
            password = "1234";
            database = "schoolerzz";
            connectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4};", host, port, username, password, database);
        }
        public DatabaseConnection(String host, String port, String username, String pwd, String db)
        {
            this.host = host;
            this.port = port;
            this.username = username;
            this.password = pwd;
            this.database = db;
            connectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4};", host, port, username, password, database);
        }
        private void MakeConnection()
        {
            try
            {
                connection = new(connectionString);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void CloseConnection()
        {
            connection.Close();
        }
        // TODO : ejecutar procedimiento en funcion del parametro de entrada (1 -> 4)
        public int TryLogin(string username, string password)
        {
            MakeConnection();
            string query = "LoginTeacherAO";
            command = new(query, connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("username", username);
            command.Parameters.AddWithValue("pwd", password);

            command.Parameters.Add(new MySqlParameter("@valid", MySqlDbType.Int32));
            command.Parameters["@valid"].Direction = ParameterDirection.Output;

            connection.Open();
            command.ExecuteNonQuery();
            CloseConnection();
            return (int)command.Parameters["@valid"].Value;
        }
    }
}
