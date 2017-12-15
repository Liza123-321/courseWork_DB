using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseWork.Models
{
    public class DetachmentViewModels
    {
        [Required(ErrorMessage = "Поле имени отряда не может быть пустым.")]
        [Display(Name = "Имя")]
        public string Detachment_name { get; set; }
    }
    public class SpeciesViewModels
    {
        [Required(ErrorMessage = "Поле имени вида не может быть пустым.")]
        [Display(Name = "Имя на русском")]
        public string Species_name_RUS { get; set; }
        [Required(ErrorMessage = "Поле имени вида не может быть пустым.")]
        [Display(Name = "Имя на английском")]
        public string Species_name_ENG { get; set; }
        [Required(ErrorMessage = "Поле подотряда не может быть пустым.")]
        [Display(Name = "Подотряд")]
        public string Suborder { get; set; }
    }
    public class SuborderViewModels
    {
        [Required(ErrorMessage = "Поле имени отряда не может быть пустым.")]
        [Display(Name = "Отряд")]
        public string Detachment { get; set; }
        [Required(ErrorMessage = "Поле имени подотряда не может быть пустым.")]
        [Display(Name = "Имя подотряда")]
        public string Suborder_name{ get; set; }
        [Required(ErrorMessage = "Поле количетсва родов не может быть пустым.")]
        [Display(Name = "Количество родов")]
        public int Count_genus { get; set; }
    }
}