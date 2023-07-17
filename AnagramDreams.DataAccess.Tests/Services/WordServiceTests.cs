using AnagramDreams.DataAccess.Model;
using AnagramDreams.DataAccess.Services;
using AnagramDreams.TestUtils;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace AnagramDreams.DataAccess.Tests.Services
{
    public class WordServiceTests
    {
        [Theory]
        [InlineData("sALTER", new[] { "ALERTS", "ALTERS" })]
        [InlineData("ALERtS", new[] { "SALTER", "ALTERS" })]
        [InlineData("ALTERS", new[] { "SALTER", "ALERTS" })]
        public async Task GetAnagramsShouldReturnCorrectAnagrams(string input, string[] expected)
        { 
            using (var dbContext = CreateDbContext())
            {
                var cut = new WordService(dbContext);
                var result = await cut.GetAnagrams(input);

                result.Count.ShouldBe(2);
                result[0].Value.ShouldBe(expected[0]);
                result[1].Value.ShouldBe(expected[1]);
            }
        }

        [Fact]
        public async Task GetAnagramsShouldThrowIfWordNotInDb()
        {
            using (var dbContext = CreateDbContext())
            {
                var cut = new WordService(dbContext);
                
                var exception = await Should.ThrowAsync<Exception>(async () =>
                {
                    await cut.GetAnagrams("BLABLA");
                });

                exception.Message.ShouldBe("The word BLABLA is not in the dictionary.");
            }
        }

        [Theory]
        [InlineData("ALeRTS", "SALTER", true)]
        [InlineData("SALTER", "SALTER", false)]
        [InlineData("ARSLE", "SALTER", false)]
        [InlineData("ALTERS", "ALERTS", true)]
        public async Task IsAnagramWorks(string input, string word, bool expected)
        {
            using (var dbContext = CreateDbContext())
            {
                var cut = new WordService(dbContext);
                var result = await cut.IsAnagram(input, word);
                result.ShouldBe(expected);
            }
        }

        private InMemoryAnagramDreamsDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<AnagramDreamsDbContext>()
                .UseInMemoryDatabase("AnagramDreamsDb")
                .Options;

            var dbContext = new InMemoryAnagramDreamsDbContext(options);
            dbContext.Words.Add(new Word() { Value = "SALTER", Alfagram = "AELRST" });
            dbContext.Words.Add(new Word() { Value = "ALERTS", Alfagram = "AELRST" });
            dbContext.Words.Add(new Word() { Value = "ALTERS", Alfagram = "AELRST" });
            dbContext.Words.Add(new Word() { Value = "BRAIN", Alfagram = "ABINR" });

            dbContext.SaveChanges();

            return dbContext;
        }
    }
}
