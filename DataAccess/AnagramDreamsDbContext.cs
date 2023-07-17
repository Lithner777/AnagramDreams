using AnagramDreams.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace AnagramDreams.DataAccess
{
    public class AnagramDreamsDbContext : DbContext
    {
        public AnagramDreamsDbContext(DbContextOptions<AnagramDreamsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Word> Words => Set<Word>();
    }
}
