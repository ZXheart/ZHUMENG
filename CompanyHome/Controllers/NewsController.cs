using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyHome.Areas.Manage.Models;
using CompanyHome.Core_Captcha;
using Microsoft.AspNetCore.Mvc;

namespace CompanyHome.Controllers
{
    public class NewsController : Controller
    {
        readonly private MyDBContent myDBContent;
        public NewsController(MyDBContent myDBContent)
        {
            this.myDBContent = myDBContent;
        }
        public IActionResult Index(int id=1)//第一页不需要参数 所以规定p为空的时候 默认是1
        {
            if (id <= 0)
            {
                id = 1;
            }
            int pageSize = 5;//每页新闻数
            var total = myDBContent.News.Count();//总共新闻数
            int totalPage = total / pageSize + (total % pageSize > 0 ? 1 : 0);//总页数
            if (id > totalPage)
            {
                id = totalPage;
            }
            //ef中的分页 其实就是跳过前面的记录 取多少条
            int skip = (id - 1) * pageSize;//跳过前边多少条
            var list = new List<News>();
            if (skip == 0)// Skip就是跳过，Take 就是获取
            {
                list = myDBContent.News.Take(pageSize).ToList();//=0的时候直接获取数据
            }
            else
            {
                list = myDBContent.News.Skip(skip).Take(pageSize).ToList();//>0时跳过xx页，取数据
            }
            //take 如果取10条 但是跳过以后 可能不够10条 它只会取剩下的
            ViewBag.CurrentPage = id;
            ViewBag.TotalPage = totalPage;
            return View(list);
        }
        public IActionResult Detail(int id)
        {
            var news = myDBContent.News.FirstOrDefault(n => n.ID == id);
            ViewBag.News = news;
            return View();
        }
    }
} 