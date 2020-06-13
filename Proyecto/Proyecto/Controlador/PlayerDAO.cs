using System;
using System.Collections.Generic;
using System.Data;
using Proyecto.Modelo;

namespace Proyecto.Controlador
{
    public class PlayerDAO
    {
        public static List<Player> getDataPlayer()
        {
            string sql = "Script para consultar la base"; //jeje

            DataTable dt = ConnectionDB.ExecuteQuery(sql);
            
            List<Player> player1 = new List<Player>();
            foreach (DataRow fila in dt.Rows)
            {
                Player p1 = new Player();
                p1.idPlayer = Convert.ToInt32(fila[0]);
                p1.NickName = fila[1].ToString();
                p1.Score = Convert.ToInt32(fila[2]); 
                p1.MaxScore = Convert.ToInt32(fila[3]);
            }
            return player1;
        }   
    }
}