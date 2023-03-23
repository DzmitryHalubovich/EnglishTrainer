using System.ComponentModel.DataAnnotations;

namespace EnglishTrainer.ApplicationCore.Models
{
    public class RegisterDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        [Compare("Password", ErrorMessage ="Password don't match")]
        public string PasswordConfirm { get; set; }

        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
