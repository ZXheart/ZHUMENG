using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyHome.Core_Captcha;
using Microsoft.AspNetCore.Mvc;

namespace CompanyHome.Controllers
{
    public class JoinUsController : Controller
    {
        readonly private MyDBContent myDBContent;
        public JoinUsController(MyDBContent myDBContent)
        {
            this.myDBContent = myDBContent;
        }
        public IActionResult Index()
        {
            var list = myDBContent.JoinUs.ToList();
            return View(list);
        }
    }
}