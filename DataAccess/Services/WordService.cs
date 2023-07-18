using AnagramDreams.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace AnagramDreams.DataAccess.Services
{
    public class WordService : IWordService
    {
        private readonly AnagramDreamsDbContext dbContext;

        public WordService(AnagramDreamsDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Word>> GetAnagrams(string word)
        {
            word = word.ToUpper();
            var alfagram = string.Concat(word.OrderBy(c => c));

            var match = await dbContext.Words
                .AnyAsync(w => w.Value == word);

            if (match)
            {
                return await dbContext.Words
                    .Where(w => w.Alfagram == alfagram && w.Value != word)
                    .ToListAsync();
            }
            else
            {
                throw new Exception($"The word {word} has no anagrams in the dictionary.");
            }
        }

        public async Task<bool> IsAnagram(string input, string word)
        {
            input = input.ToUpper();
            var anagrams = await GetAnagrams(word);
            if (anagrams.Select(w => w.Value).Contains(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Word> GetRandomWord(int anagramCount)
        {
            var random = new Random();

            if (anagramCount == 0)
            {
                var randomIndex = random.Next(dbContext.Words.Count());
                var word = dbContext.Words.Skip(randomIndex).Take(1).SingleOrDefault();
                return word!;
            }

            var words = await dbContext.Words
                .GroupBy(w => w.Alfagram)
                .ToListAsync();

            var filteredWords = words
                .Where(g => g.Count() == anagramCount+1)
                .SelectMany(g => g)
                .ToList();

            var randomIndex2 = random.Next(0, filteredWords.Count());
            return filteredWords[randomIndex2];
        }
    }
}
