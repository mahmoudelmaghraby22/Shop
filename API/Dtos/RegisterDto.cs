using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\\W_]).{6,30})",
        ErrorMessage = "Password requires at least 1 lower case character, 1 upper case character, 1 number, 1 special character and must be at least 6 characters and at most 50")]
        public string Password { get; set; }
        [Required]
        public string DisplayName { get; set; }
    }
}