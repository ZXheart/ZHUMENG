using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyHome.Areas.Manage.Models
{
    public class NewsEditModel
    {
        public int ID { get; set; }

        [Display(Name = "标题")]
        [Required(ErrorMessage = "{0}是必填的")]
        [StringLength(100, ErrorMessage = "{0}最大长度为100字符")]
        public string Title { get; set; }

        [Display(Name = "内容")]
        [Required(ErrorMessage = "{0}是必填的")]
        public string Content { get; set; }
    }
}
