using System.ComponentModel.DataAnnotations;

namespace WebApplication.ViewModels
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Поле пустое")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле пустое")]
        [Display(Name = "Имя")]
        [StringLength(100, MinimumLength = 2,ErrorMessage = "Имя должно быть от 2 до 100 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле пустое")]
        [Display(Name = "Фамилия")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Фамилия должна быть от 2 до 100 символов")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Поле пустое")]
        [Display(Name = "Номер телефона")]
        [Phone(ErrorMessage = "Некорректный номер телефона")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Поле пустое")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле пустое")]
        [Display(Name = "Подтверждение пароля")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; }
    }
}
