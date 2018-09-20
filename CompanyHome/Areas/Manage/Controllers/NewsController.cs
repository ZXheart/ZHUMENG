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
    public class NewsController : BaseController
    {
        private readonly MyDBContent myDBContent;
        public NewsController(MyDBContent myDBContent)
        {
            this.myDBContent = myDBContent;
        }//上下文对象
        public IActionResult Index()
        {
            var list = myDBContent.News.ToList();
            return View(list);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var news = myDBContent.News.Where(n => n.ID == id).FirstOrDefault();
            return View(news);
        }
        [HttpPost]
        public IActionResult Edit(int id, NewsEditModel newsedit)
        {
            var news = myDBContent.News.Where(n => n.ID == id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                news.AddTime = DateTime.Now;
                news.Title = newsedit.Title;
                news.Content = newsedit.Content;
            }
            int v = myDBContent.SaveChanges();
            if (v > 0)
            {
                return Redirect("/Manage/News/Index");
            }
            else
            {
                ModelState.AddModelError("Title", "修改失败！");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Add(NewsAddModel newsadd)
        {
            if (ModelState.IsValid)
            {
                var news = new News
                {
                    AddTime = DateTime.Now,
                    Title = newsadd.Title,
                    Content = newsadd.Content
                };
                myDBContent.Add(news);
                int v = myDBContent.SaveChanges();
                if (v > 0)
                {
                    return Redirect("/Manage/News/Index");
                }
                else
                {
                    ModelState.AddModelError("Title", "保存失败！");
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Del(int id)
        {
            myDBContent.News.Remove(myDBContent.News.Where(n => n.ID == id).FirstOrDefault());
            int m = myDBContent.SaveChanges();
            return Json(m > 0);
        }
    }
}