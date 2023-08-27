using AutoMapper;
using WebMvcTelefonRehberi.Domain;
using WebMvcTelefonRehberi.Models.Dtos;

namespace WebMvcTelefonRehberi.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Kisi, KisiCreateDto>();
            CreateMap<KisiCreateDto, Kisi>();
        }
    }
}
