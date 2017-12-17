using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseWork.Models
{
    public class RegDeliteViewModel
    {
        [Display(Name = "ID")]
        public string Reg_Id { get; set; }

        [Required(ErrorMessage = "Поле имени автора не может быть пустым.")]
        [Display(Name = "Author")]
        public string Author { get; set; }


        [Required(ErrorMessage = "Поле даты учёта не может быть пустым.")]
        [Display(Name = "Date")]
        public string Date { get; set; }
    }

    public class RegAddAuthorViewModel
    {

        [Required(ErrorMessage = "Поле имени автора не может быть пустым.")]
        [Display(Name = "Author")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Поле даты учёта не может быть пустым.")]
        [Display(Name = "Date")]
        public string Date { get; set; }

    }

    public class RegAddAnimalViewModel
    {

        [Required(ErrorMessage = "Поле имени животного не может быть пустым.")]
        [Display(Name = "Animal")]
        public string Animal { get; set; }

        [Required(ErrorMessage = "Поле местоположения учёта не может быть пустым.")]
        [Display(Name = "Coords")]
        public string Coords { get; set; }

        [Required(ErrorMessage = "Поле метода исследования не может быть пустым.")]
        [Display(Name = "Method")]
        public string Method { get; set; }

        [Required(ErrorMessage = "Поле регистрации автора не может быть пустым.")]
        [Display(Name = "RegAuthor")]
        public string RegAuthor { get; set; }

    }
}