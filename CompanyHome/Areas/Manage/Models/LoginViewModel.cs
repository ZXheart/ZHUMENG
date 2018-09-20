using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyHome.Areas.Manage.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="{0}必填项"),StringLength(16,MinimumLength =5,ErrorMessage ="{0}不正确"),Display(Name ="用户名")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "{0}必填项"), StringLength(16, MinimumLength = 5, ErrorMessage = "{0}不正确"), Display(Name = "密码")]
        public string PasswordFor { get; set; }
        [Required(ErrorMessage = "{0}必填项"), StringLength(5, MinimumLength = 5, ErrorMessage = "{0}不正确"), Display(Name = "验证码")]
        [Remote("V","Home","Manage")]
        public string Verification { get; set; }
    }
}
