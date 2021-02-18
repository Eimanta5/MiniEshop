using System.ComponentModel.DataAnnotations;

namespace MiniEshop.Models.Actions
{
    public class UpdateUser
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Surname { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }

        [MaxLength(12)]
        public string PhoneNumber { get; set; }
    }
}
