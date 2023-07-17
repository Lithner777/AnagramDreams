using AutoMapper;
using System.Text.Json.Serialization;

namespace AnagramDreams.Api.Dtos
{
    public class WordResp
    {
        [JsonPropertyName("value")]
        public string Value { get; set; } = null!;

        public static void MapOutgoing(Profile profile)
        {
            profile.CreateMap<Dtos.WordResp, DataAccess.Model.Word>()
                .IncludeAllDerived();
        }
    }
}
