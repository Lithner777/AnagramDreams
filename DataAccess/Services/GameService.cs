using AnagramDreams.DataAccess.Model;

namespace AnagramDreams.DataAccess.Services
{
    public class GameService : IGameService
    {
        private readonly IWordService wordService;

        public GameService(IWordService wordService)
        {
            this.wordService = wordService;
        }

        public async Task<Game> NewGame(int wordCount, int gameTime, int anagramCount)
        {
            var game = new Game();

            for (var i = 0; i < wordCount; i++)
            {
                var word = await wordService.GetRandomWord(anagramCount);
                var anagrams = await wordService.GetAnagrams(word.Value);

                game.GameWords.Add(
                new GameWord()
                {
                    Word = word,
                    Anagrams = anagrams
                });
            }

            game.GameTime = gameTime;

            return game;
        }
    }
}
