using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyHome.Areas.Manage.Models
{
    public class PageAddModel
    {
        [Display(Name ="标识符")]
        [Required(ErrorMessage ="{0}是必填的")]
        [StringLength(20,ErrorMessage ="{0}最大长度为20字符")]
        [RegularExpression(@"^\w+$",ErrorMessage ="{0}必须输出英文")]
        [Remote("CheckIdentity","Page","Manage",ErrorMessage ="标识符已存在")]
        public string Identity { get; set; }

        [Display(Name = "姓名")]
        [Required(ErrorMessage = "{0}是必填的")]
        [StringLength(5,ErrorMessage ="{0}最大长度为5字符")]
        public string Name { get; set; }

        [Display(Name = "年龄")]
        [Required(ErrorMessage = "{0}是必填的")]
        [Range(0,130,ErrorMessage ="{0}不符合要求")]
        public int Age { get; set; }

        [Display(Name ="介绍")]
        [Required(ErrorMessage = "{0}是必填的")]
        public string Content { get; set; }

        [Display(Name ="爱好")]
        public string Hobby { get; set; }

        [Display(Name ="职位")]
        [Required(ErrorMessage = "{0}是必填的")]
        public string Position { get; set; }

        [Display(Name ="加入时间")]
        [Required(ErrorMessage = "{0}是必填的")]
        public DateTime AddTime { get; set; }

    }
}
