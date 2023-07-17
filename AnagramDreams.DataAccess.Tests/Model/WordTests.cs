using AnagramDreams.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Immutable;
using System.IO.Pipelines;
using System.Linq;
using Xunit;


namespace AnagramDreams.DataAccess.Tests.Model
{
    public class WordTests
    {
    //    private readonly AnagramDreamsDbContext _dbContext;

    //    public WordTests()
    //    {
    //        var services = new ServiceCollection()
    //            .AddDbContext<AnagramDreamsDbContext>(options =>
    //            options.UseSqlServer("Server=DIRT\\SQLEXPRESS;Database=AnagramDreamsDb;Trusted_Connection=True;TrustServerCertificate=True;"));

    //        var serviceProvider = services.BuildServiceProvider();

    //        _dbContext = serviceProvider.GetRequiredService<AnagramDreamsDbContext>();
    //    }

    //    [Fact]
    //    public async Task GenerateDb()
    //    {
    //        using (StreamReader reader = new StreamReader("C:/Development/words_alpha.txt"))
    //        {
    //            var line = string.Empty;
    //            while ((line = reader.ReadLine()) != null)
    //            {
    //                var word = line.ToCharArray().ToList().OrderBy(c => c);
    //                var alfagram = string.Join("", word);
    //                _dbContext.Words.Add(new Word()
    //                {
    //                    Value = line.ToUpper(),
    //                    Alfagram = alfagram.ToUpper()
    //                });
    //            }
    //            await _dbContext.SaveChangesAsync();
    //        }
    //    }
    }
}
