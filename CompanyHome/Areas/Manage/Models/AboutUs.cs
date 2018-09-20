using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyHome.Areas.Manage.Models
{
    public class AboutUs
    {
        public int ID { get; set; }

        [Display(Name ="内容")]
        [Required(ErrorMessage ="{0}不能为空！")]
        public string Content { get; set; }
    }
}
