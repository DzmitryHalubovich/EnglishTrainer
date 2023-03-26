using System.ComponentModel.DataAnnotations;

namespace EnglishTrainer.ApplicationCore.Models
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength =2, ErrorMessage = "Пароль должен состоять как минимум из 2-х символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Пароли должны совпадать")]
        public string PasswordConfirm { get; set; }

        //[DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string Email { get; set; }
    }
}
