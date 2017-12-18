using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseWork.Models
{
    public class MapViewModels
    {

        [RegularExpression((@"Point"), ErrorMessage = "Неверный тип местоположения")]
        [Required(ErrorMessage = "Поле типа местоположения не может быть пустым.")]
        [Display(Name = "Тип местоположения")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Поле адреса не может быть пустым.")]
        [Display(Name = "Адресс")]
        public string Adress { get; set; }

        [RegularExpression((@"[0-9]{2}\.[0-9]+"), ErrorMessage = "Широта может содержать только цифры")]
        [Required(ErrorMessage = "Широта не может быть пустая.")]
        [Display(Name = "Широта")]
        public string Latitude { get; set; }
        [RegularExpression((@"[0-9]{2}\.[0-9]+"), ErrorMessage = "Долгота может содержать только цифры")]
        [Required(ErrorMessage = "Долгота не может быть пустая.")]
        [Display(Name = "Долгота")]
        public string Longitude { get; set; }
    }
}