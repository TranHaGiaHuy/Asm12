using System.ComponentModel.DataAnnotations;

namespace AssignmentSlot12_WebClient.Models
{
    public class LoginDTO
    {
        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(int.MaxValue)]
        public string Password { get; set; }
    }
}
