namespace Proyecto.Controlador
{
    public class ScoreDAO
    {
        public int idScore { get; set; }
        public int score { get; set; }
        public string nickname { get; set; }

        public ScoreDAO()
        {
            idScore = 1;
            score = 0;
            nickname = "";
        }
    }
}