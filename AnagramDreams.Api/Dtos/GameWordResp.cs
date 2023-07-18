using AutoMapper;

namespace AnagramDreams.Api.Dtos
{
    public class GameWordResp
    {
        public WordResp Word { get; set; } = null!;

        public List<WordResp> Anagrams { get; set; } = new List<WordResp>();

        public static void MapOutgoing(Profile profile)
        {
            profile.CreateMap<Dtos.GameWordResp, DataAccess.Model.GameWord>()
                .IncludeAllDerived();
        }
    }
}
