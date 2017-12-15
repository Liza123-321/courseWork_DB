using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWork.DAL_Models
{
    public class Publication
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public DateTime Publication_date { get; set; }
        public string link { get; set; }
    }
}