using System.ComponentModel.DataAnnotations;

namespace AnagramDreams.DataAccess.Model
{
    public class Word
    {
        [Key]
        public Guid Id { get; set; }

        public string Value { get; set; } = null!;

        public string Alfagram { get; set; } = null!;
    }
}
