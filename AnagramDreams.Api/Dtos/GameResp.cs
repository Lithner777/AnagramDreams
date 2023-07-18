using AnagramDreams.DataAccess.Model;
using AutoMapper;
using System.Text.Json.Serialization;

namespace AnagramDreams.Api.Dtos
{
    public class GameResp
    {
        [JsonPropertyName("gamewords")]
        public List<GameWordResp> GameWords { get; set; } = new List<GameWordResp>();

        [JsonPropertyName("gametime")]
        public int GameTime { get; set; }

        public static void MapOutgoing(Profile profile)
        {
            profile.CreateMap<Dtos.GameResp, DataAccess.Model.Game>()
                .IncludeAllDerived();
        }
    }
}
