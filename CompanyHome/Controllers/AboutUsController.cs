using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyHome.Core_Captcha;
using Microsoft.AspNetCore.Mvc;

namespace CompanyHome.Controllers
{
    public class AboutUsController : Controller
    {
        readonly private MyDBContent myDBContent;
        public AboutUsController(MyDBContent myDBContent)
        {
            this.myDBContent = myDBContent;
        }
        public IActionResult Index()
        {
            var list = myDBContent.AboutUs.ToList();
            return View(list);
        }
    }
}