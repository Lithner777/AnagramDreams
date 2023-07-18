using AutoMapper;

namespace AnagramDreams.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DataAccess.Model.Word, Dtos.WordResp>();
            CreateMap<DataAccess.Model.Game, Dtos.GameResp>();
            CreateMap<DataAccess.Model.GameWord, Dtos.GameWordResp>();
        }
    }
}
