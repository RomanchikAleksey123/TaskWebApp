using System;
using System.ComponentModel.DataAnnotations;


namespace WebApplication.ViewModels
{
    public class AddEventViewModel
    {
        [Required(ErrorMessage = "Поле пустое")]
        [Display(Name = "Название")]
        public string Tittle { get; set; }

        [Required(ErrorMessage = "Поле пустое")]
        [Display(Name = "Тема")]
        public string Topic { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Поле пустое")]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Поле пустое")]
        [Display(Name = "Дата проведения")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Поле пустое")]
        [Range(1, int.MaxValue, ErrorMessage = "Колличество участников должно быть больше 1")]
        [Display(Name = "Максимальное число участников")]
        public int TotalNumberParticipants { get; set; }
    }
}
