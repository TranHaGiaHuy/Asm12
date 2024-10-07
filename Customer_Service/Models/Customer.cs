using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Customer_Service.Models
{
    public class Customer
    {
        [Key]
        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(int.MaxValue)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Fullname { get; set; }

        [Required]
        public DateOnly Birthday { get; set; }

        [Required]
        [StringLength(6)]
        public string Gender { get; set; }
        [Required]
        [StringLength(15)]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [StringLength(256)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(int.MaxValue)]
        public string Address { get; set; }
    }
}
