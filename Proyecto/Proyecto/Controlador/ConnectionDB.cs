using System.Data;
using Npgsql;

namespace Proyecto.Controlador
{
    public class ConnectionDB
    {
        private static string host = "localhost",
            database = "Arkanoid",
            userID = "postgres",
            pasword = "1234";
        
        private static string sConecction =
            $"Server={host};Port=5432;User Id={userID};Password={pasword};Database={database};";
        
        public static DataTable ExecuteQuery(string query)
        {
            NpgsqlConnection connection = new NpgsqlConnection(sConecction);
            DataSet ds = new DataSet();
            
            connection.Open();
                
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, connection);
            da.Fill(ds);
                
            connection.Close();
            
            return ds.Tables[0];
        }
        
        public static void ExecuteNonQuery(string act)
        {
            NpgsqlConnection connection = new NpgsqlConnection(sConecction);
            
            connection.Open();
                
            NpgsqlCommand command = new NpgsqlCommand(act, connection);
            command.ExecuteNonQuery(); 
                
            connection.Close();
        }
    }
}