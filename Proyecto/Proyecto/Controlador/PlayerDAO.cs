using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Proyecto.Modelo;

namespace Proyecto.Controlador
{
    public class PlayerDAO
    {
        public static List<Player> getPlayer()
        {
            DataTable dt = null;
            List<Player> listPlayer = new List<Player>();
            
            try
            {
                dt= ConnectionDB.ExecuteQuery("SELECT * FROM PLAYER");
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error!");
            }
            
            foreach (DataRow row in dt.Rows)
            {
                Player p = new Player();
                p.nickname = row[0].ToString();
                listPlayer.Add(p);
            }
            return listPlayer;
        }
        
        //Método que agrega un jugador a la base de datos
        public static void insertPlayer(string player)
        {
            try
            {
                var dt = ConnectionDB.ExecuteQuery($"SELECT * FROM \"PLAYER\" WHERE nickname = '{player}'");
                if (dt.Rows.Count > 0)
                    MessageBox.Show($"Bienvenido nuevamente {player}");
                else
                {
                    string query = $"INSERT INTO \"PLAYER\"(nickname) VALUES ('{player}')";
                    ConnectionDB.ExecuteNonQuery(query);
                    MessageBox.Show("Usuario registrado con exito, bienvenio!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error!");
            }
        }
    }
}