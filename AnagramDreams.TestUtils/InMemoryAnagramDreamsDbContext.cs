using AnagramDreams.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AnagramDreams.TestUtils
{
    public class InMemoryAnagramDreamsDbContext : AnagramDreamsDbContext
    {
        public static InMemoryDatabaseRoot DatabaseRoot = new();
        private string dbName;

        public InMemoryAnagramDreamsDbContext(DbContextOptions<AnagramDreamsDbContext> options)
            : base(options)
        {
            dbName = Guid.NewGuid().ToString();
        }

        public InMemoryAnagramDreamsDbContext(DbContextOptions<AnagramDreamsDbContext> options, string dbName)
            : base(options)
        {
            this.dbName = dbName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(dbName);
        }
    }
}