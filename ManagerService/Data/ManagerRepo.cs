using ManagerService.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagerService.Data
{
    public class ManagerRepo : IManagerRepo
    {
        private readonly ApplicationDbContext _context;

        public ManagerRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateManager(ManagerModel manager)
        {
           if (manager == null)
            {
                throw new ArgumentNullException(nameof(manager));
            }
           _context.Manager.Add(manager);
        }

        public void DeleteManager(int id)
        {
            var managerToDelete = _context.Manager.FirstOrDefault(m => m.Id == id);
            if (managerToDelete != null)
            {
                _context.Manager.Remove(managerToDelete);
            }
        }

        public IEnumerable<ManagerModel> GetAllManagers() => _context.Manager.ToList();


        public ManagerModel GetManagerById(int id) => _context.Manager.FirstOrDefault(m => m.Id == id);

        public bool SaveChanges() => _context.SaveChanges() >= 0;

        public void UpdateManager(int id, ManagerModel manager)
        {
            var existingManager = _context.Manager.FirstOrDefault(m => m.Id == id);
            if (existingManager != null)
            {
                existingManager.FirstName = manager.FirstName;
                existingManager.LastName = manager.LastName;
                existingManager.BirthDate = manager.BirthDate;
                existingManager.Email = manager.Email;
                existingManager.Password = manager.Password;
                existingManager.BirthDate = manager.BirthDate;
                existingManager.Gender = manager.Gender;
            }
        }
    }
}
