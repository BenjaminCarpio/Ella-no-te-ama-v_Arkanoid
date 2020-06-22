namespace Proyecto.Modelo
{
    public class Regist
    {
        public int idScore { get; set; } 
        public string nickname { get; set; }
        public int score { get; set; }
       

        public Regist(string nick = "unnamed", int sc = 0)
        {
            nickname = nick; 
            score = sc;
        }
    }
}