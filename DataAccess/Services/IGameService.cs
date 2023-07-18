using AnagramDreams.DataAccess.Model;

namespace AnagramDreams.DataAccess.Services
{
    public interface IGameService
    {
        Task<Game> NewGame(int wordCount, int gameTime, int anagrtamCount);
    }
}
