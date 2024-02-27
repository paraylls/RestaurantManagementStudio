using AutoMapper;
using BarService.Dtos;
using BarService.Models;

namespace BarService.Profiles
{
    public class BartenderProfile : Profile
    {
        public BartenderProfile()
        {
            CreateMap<BartenderModel, BartenderReadDto>();
            CreateMap<BartenderCreateDto, BartenderModel>();
        }
    }
}
