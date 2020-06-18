namespace Proyecto.Modelo
{
    public class Regist
    {
        public int idScore { get; set; } 
        public string nickname { get; set; }
        public int score { get; set; }
       

        public Regist()
        {
            idScore = 1;
            nickname = ""; 
            score = 0;
        }
    }
}