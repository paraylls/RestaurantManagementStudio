using System.ComponentModel.DataAnnotations;

namespace ManagerService.Models
{
    public class ManagerModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public int PID { get; set; }

        [Required]
        public int RID { get; set; }

        [Required]
        public readonly string Role = "Admin";
    }
}
