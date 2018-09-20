using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CompanyHome.Areas.Manage.Models;
using CompanyHome.Core_Captcha;

namespace CompanyHome.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AboutUsController : Controller
    {
        private readonly MyDBContent myDBContent;
        public AboutUsController(MyDBContent myDBContent)
        {
            this.myDBContent = myDBContent;
        }//上下文对象
        public IActionResult Index(int id=1)
        {
            var aboutUs = myDBContent.AboutUs.Where(a => a.ID == id).FirstOrDefault();
            return View(aboutUs);
        }
        [HttpPost]
        public IActionResult Index(AboutUsAdd aud)
        {
            if (ModelState.IsValid)
            {
                myDBContent.AboutUs.FirstOrDefault().Content = aud.Content;
                int v = myDBContent.SaveChanges();
                if (v > 0)
                {
                    ModelState.AddModelError("Content","保存成功");
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