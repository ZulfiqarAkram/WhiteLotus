using System.ComponentModel.DataAnnotations;

namespace WhiteLotusProject.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
         [Required]
         [StringLength(255)]
        public string Email { get; set; }
         [Required]
        [StringLength(255)]
        public string MobileNo { get; set; }
    }
}