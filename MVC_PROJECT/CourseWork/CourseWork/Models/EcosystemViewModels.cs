using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseWork.Models
{
    public class EcosystemViewModels
    {
        [Required(ErrorMessage = "Поле имени экосистемы не может быть пустым.")]
        [Display(Name = "Имя экосистемы")]
        public string Ecosystem_name { get; set; }
        [Required(ErrorMessage = "Поле имени биотопа не может быть пустым.")]
        [Display(Name = "Имя биотопа")]
        public string Bitope { get; set; }
        [Required(ErrorMessage = "id местоположения не может быть пустым.")]
        [Display(Name = "ID Местоположения")]
        public string Coordinates { get; set; }
    }

}