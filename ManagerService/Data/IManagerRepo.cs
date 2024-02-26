using ManagerService.Models;

namespace ManagerService.Data
{
    public interface IManagerRepo
    {
        bool SaveChanges();

        IEnumerable<ManagerModel> GetAllManagers();
        ManagerModel GetManagerById(int id);
        void CreateManager(ManagerModel manager);
        void DeleteManager(int id);
        void UpdateManager(int id, ManagerModel manager);
    }
}
