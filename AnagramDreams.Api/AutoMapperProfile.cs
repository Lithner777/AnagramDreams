using AnagramDreams.Api.Dtos;
using AutoMapper;

namespace AnagramDreams.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DataAccess.Model.Word, Dtos.WordResp>();
        }
    }
}
