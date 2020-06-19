using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Proyecto.Modelo;

namespace Proyecto.Controlador
{
    public class RegistDAO
    {
        
        public static List<Regist> getScore()
        {
            var listScore = new List<Regist>();
            DataTable dt = null;
            try
            {
                string sql = "SELECT nickname, score FROM \"REGIS\" ORDER BY score DESC LIMIT 10";
                dt = ConnectionDB.ExecuteQuery(sql);
                foreach (DataRow row in dt.Rows)
                {
                    listScore.Add(new Regist(row[0].ToString(), Convert.ToInt32(row[1])));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error! es esto");
            }
            return listScore;
        }
    }
}