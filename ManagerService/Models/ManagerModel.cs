using System.ComponentModel.DataAnnotations;

namespace ManagerService.Models
{
    public class ManagerModel
    {
        public ManagerModel()
        {
            
        }
        [Key]
        public required int ID { get; set; }
        public required String LastName { get; set; }
        public required String FirstName { get; set; }
        public required String Email { get; set; }
        public required String Password { get; set; }
        public required String Gender { get; set; }
        public required DateTime BirthDate { get; set; }
        public long PID { get; set; }
        public long RID { get; set; }
        public readonly String Role = "Admin";
    }
}
