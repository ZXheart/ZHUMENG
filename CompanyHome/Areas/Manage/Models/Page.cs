using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CompanyHome.Areas.Manage.Models;

namespace CompanyHome.Areas.Manage.Models
{
    public class Page
    {
        public int ID { get; set; }

        public string Identity { get; set; }

        [Display(Name ="姓名")]
        [Required(ErrorMessage ="{0}是必填的")]
        [StringLength(5, ErrorMessage = "{0}不能超过5个字符")]
        public string Name { get; set; }

        [Display(Name = "年龄")]
        [Required(ErrorMessage = "{0}是必填的")]
        public int Age { get; set; }

        public string Hobby { get; set; }

        public string Position { get; set; }

        public string Content { get; set; }

        public DateTime AddTime { get; set; }

        public List<PageEditModel> EditModels { get; set; }
    }
}
