using System.ComponentModel.DataAnnotations;

namespace ManageUserApi.DTOs
{
    public class RegisterDto
    {

        [Required(ErrorMessage = "{0} is Required.")]
        [MaxLength(10, ErrorMessage = "The number of characters exceeds the limit")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "{0} is Required.")]
        [MaxLength(50, ErrorMessage = "The number of characters exceeds the limit")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is Required.")]
        [MaxLength(50, ErrorMessage = "The number of characters exceeds the limit")]

        public string Password { get; set; }
    }
}
