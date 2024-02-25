using AutoMapper;
using ManagerService.Dtos;
using ManagerService.Models;

namespace ManagerService.Profiles
{
    public class ManagersProfile : Profile
    {
        public ManagersProfile()
        {
            // Source -> Target
            CreateMap<ManagerModel, ManagerReadDto>();
            CreateMap<ManagerCreateDto, ManagerModel>();
        }
    }
}
