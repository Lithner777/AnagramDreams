using AnagramDreams.DataAccess.Model;

namespace AnagramDreams.DataAccess.Services
{
    public interface IWordService
    {
        Task<List<Word>> GetAnagrams(string word);

        Task<bool> IsAnagram(string input, string word);
    }
}
