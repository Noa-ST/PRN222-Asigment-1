using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.DTOs
{
    public class SystemAccountBaseDto
    {
        [Required, MaxLength(100)]
        public string FullName { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; } // Admin, Staff, Lecturer
    }

    public class CreateSystemAccountDto : SystemAccountBaseDto
    {

    }

    public class UpdateSystemAccountDto : SystemAccountBaseDto
    {
        [Required]
        public int ID { get; set; }
    }

    public class GetSystemAccountDto : SystemAccountBaseDto
    {
        public int ID { get; set; }
    }
}
