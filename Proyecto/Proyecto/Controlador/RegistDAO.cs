using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Proyecto.Modelo;

namespace Proyecto.Controlador
{
    public class RegistDAO
    {
        public static List<string> getNickName()
        {
            List<string> listScore = new List<string>();
            DataTable dt = null;

            try
            {
                dt = ConnectionDB.ExecuteQuery("SELECT nickname FROM SCORE ORDER BY score DESC, score LIMIT 10");
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error!");
            }

            foreach (DataRow row in dt.Rows)
            {
                listScore.Add(row[0].ToString());
            }
            return listScore;
        }
        
        public static List<string> getScore()
        {
            List<string> listScore = new List<string>();
            DataTable dt = null;
            try
            {
                dt = ConnectionDB.ExecuteQuery("SELECT score FROM SCORE ORDER BY score DESC, score LIMIT 10");
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error!");
            }

            foreach (DataRow row in dt.Rows)
            {
                listScore.Add(row[0].ToString());
            }

            return listScore;
        }
        
        public static List<Regist> getFirstScore()
        {
            List<Regist> listScore = new List<Regist>();
            DataTable dt = null;

            try
            {
                dt = ConnectionDB.ExecuteQuery("SELECT * FROM SCORE ORDER BY score DESC, score LIMIT 1");
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error!");
            }

            foreach (DataRow row in dt.Rows)
            {
                Regist r = new Regist();
                r.idScore = Convert.ToInt32(row[0].ToString());
                r.score = Convert.ToInt32(row[1].ToString());
                r.nickname = row[3].ToString();
                listScore.Add(r);
            }
            return listScore;
        }
        
        public static List<Regist> getPlayerScore()
        {
            List<Regist> listScore = new List<Regist>();
            DataTable dt = null;

            try
            {
                dt = ConnectionDB.ExecuteQuery("SELECT * FROM SCORE");
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error!");
            }

            foreach (DataRow row in dt.Rows)
            {
                Regist r = new Regist();
                r.idScore = Convert.ToInt32(row[0].ToString());
                r.score = Convert.ToInt32(row[1].ToString());
                r.nickname = row[3].ToString();
                listScore.Add(r);
            }
            return listScore;
        }
    }
}