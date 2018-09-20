using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyHome.Areas.Manage.Models;
using CompanyHome.Core_Captcha;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyHome.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class PageController : BaseController
    {
        private readonly MyDBContent myDBContent;
        public PageController(MyDBContent myDBContent)
        {
            this.myDBContent = myDBContent;
        }//上下文对象
        public IActionResult Index()
        {
            var list = myDBContent.Pages.ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult Edit(string Identity)
        {
            var page = myDBContent.Pages.FirstOrDefault(p => p.Identity == Identity);
            return View(page);
        }
        [HttpPost]
        public IActionResult Edit(string Identity, PageEditModel pageedit)
        {
            var page = myDBContent.Pages.FirstOrDefault(p => p.Identity == Identity);
            if (ModelState.IsValid)
            {
                page.AddTime = pageedit.AddTime;
                page.Identity = pageedit.Identity;
                page.Position = pageedit.Position;
                page.Age = pageedit.Age;
                page.Hobby = pageedit.Hobby;
                page.Name = pageedit.Name;
                page.Content = pageedit.Content;
            }
            int v = myDBContent.SaveChanges();
            if (v > 0)
            {
                return RedirectToAction("/Manage/Page/Index");
            }
            else
            {
                ModelState.AddModelError("Identity", "修改失败！");
            }
            return View(page);
        }//改
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(PageAddModel pageadd)
        {
            if (ModelState.IsValid)
            {
                var page = new Page
                {
                    AddTime = pageadd.AddTime,
                    Identity = pageadd.Identity,
                    Position = pageadd.Position,
                    Age=pageadd.Age,
                    Hobby = pageadd.Hobby,
                    Name = pageadd.Name,
                    Content = pageadd.Content
                };
                myDBContent.Add(page);
                int v = myDBContent.SaveChanges();
                if (v > 0)
                {
                    return RedirectToAction("/Manage/Page/Index");
                }
                else
                {
                    ModelState.AddModelError("Identity", "保存失败！");
                }
            }
            return View();
        }//增
        [HttpPost]
        public IActionResult Del(int id)
        {
            myDBContent.Pages.Remove(myDBContent.Pages.Where(p => p.ID == id).FirstOrDefault());
            int m = myDBContent.SaveChanges();
            return Json(m > 0);
        }//删
        public IActionResult CheckIdentity(string Identity)
        {
            Page page = myDBContent.Pages.Where(p => p.Identity == Identity).FirstOrDefault();
            return Json(page == null);
        }//检查标识符是否存在
    }
}