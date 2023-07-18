namespace AnagramDreams.DataAccess.Model
{
    public class Game
    {
        public List<GameWord> GameWords { get; set; } = new List<GameWord>();

        public int GameTime { get; set; }
    }
}
