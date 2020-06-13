namespace Proyecto.Modelo
{
    public class Player
    {
        public int idPlayer { get; set; }
        public string NickName { get; set; }
        public int Score { get; set; }
        public int MaxScore { get; set; }
        public int Lifes { get; set; }

        public Player() {}

        public Player(int id, string nickName, int maxScore = 0)
        {
            this.Lifes = 3;
            this.idPlayer = id;
            this.NickName = nickName;
            this.Score = 0;
            this.MaxScore = maxScore;
        }
    }
}