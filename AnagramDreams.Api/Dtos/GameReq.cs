using AnagramDreams.DataAccess.Model;

namespace AnagramDreams.Api.Dtos
{
    public class GameReq
    {
        public int WordCount { get; set; }

        public int GameTime { get; set; }

        public int AnagramCount { get; set; }
    }
}
