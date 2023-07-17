using AnagramDreams.Api.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Identity.Web;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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
