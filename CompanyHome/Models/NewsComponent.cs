using CompanyHome.Core_Captcha;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyHome.Models
{
    public class NewsComponent:ViewComponent
    {
        readonly private MyDBContent myDBContent;
        public NewsComponent(MyDBContent myDBContent)
        {
            this.myDBContent = myDBContent;
        }
        public IViewComponentResult Invoke(int num)
        {
            var list = myDBContent.News.Take(num).ToList();
            return View(list);
        }
    }
}
