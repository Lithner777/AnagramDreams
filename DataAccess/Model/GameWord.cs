namespace AnagramDreams.DataAccess.Model
{
    public class GameWord
    {
        public Word Word { get; set; } = null!;

        public List<Word> Anagrams { get; set;} = new List<Word>();
    }
}
