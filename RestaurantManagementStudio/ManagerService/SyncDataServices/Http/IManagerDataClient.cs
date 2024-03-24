using ManagerService.Dtos;

namespace ManagerService.SyncDataServices.Http
{
    public interface IManagerDataClient
    {
        Task SendManagerToBartender(ManagerReadDto managerReadDto);
    }
}
