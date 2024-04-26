using System.ComponentModel.DataAnnotations;

namespace NardSmena.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Поле 'Логин' является обязательным")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле 'Пароль' является обязательным")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set;}

        [Required(ErrorMessage = "Поле 'ФИО' является обязательным")]
        public string FIO { get; set; }

        [Required(ErrorMessage = "Поле 'Отдел' является обязательным")]
        public string Department { get; set; }
    }
}
