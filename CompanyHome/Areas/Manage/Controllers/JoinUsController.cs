using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyHome.Areas.Manage.Models;
using CompanyHome.Core_Captcha;
using Microsoft.AspNetCore.Mvc;

namespace CompanyHome.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class JoinUsController : Controller
    {
        private readonly MyDBContent myDBContent;
        public JoinUsController(MyDBContent myDBContent)
        {
            this.myDBContent = myDBContent;
        }
        public IActionResult Index(int id=1)
        {
            var joinUs = myDBContent.JoinUs.Where(a => a.ID == id).FirstOrDefault();
            return View(joinUs);
        }
        [HttpPost]
        public IActionResult Index(JoinUsEdit jue)
        {
            if (ModelState.IsValid)
            {
                myDBContent.JoinUs.FirstOrDefault().Content = jue.Content;
                int v = myDBContent.SaveChanges();
                if (v > 0)
                {
                    ModelState.AddModelError("Content", "保存成功！");
                }
                else
                {
                    ModelState.AddModelError("Content", "保存失败！");
                }
            }
            return View();
        }
    }
}