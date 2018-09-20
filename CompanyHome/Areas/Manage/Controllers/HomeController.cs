using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyHome.Areas.Manage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using System.Web;
using CompanyHome.Core_Captcha;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace CompanyHome.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class HomeController : Controller
    {
        private readonly MyDBContent myDBContent;
        public HomeController(MyDBContent myDBContent)
        {
            this.myDBContent = myDBContent;
        }//上下文对象
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Company()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult V(string Verification)
        {
            string s = HttpContext.Session.GetString("code").ToLower();
            //string s1 = TempData["code"].ToString();
            if (Verification.Trim().ToLower() != s)
            {
                return Json(data: $"验证码不匹配");
            }
            else
            {
                return Json(data: true);
            }
        }//异步验证 验证码
        [HttpPost]
        public IActionResult Login(LoginViewModel LVM, string ReturnUrl)
        {
            if (ModelState.IsValid)//服务器端验证
            {
                Admin dbUser = myDBContent.Admins.Where(m => m.Name == LVM.UserName).FirstOrDefault();//验证用户名是否为空
                if (dbUser != null)//不为空
                {
                    if (dbUser.PassWord == LVM.PasswordFor)//验证密码
                    {
                        //用户标识
                        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                        identity.AddClaim(new Claim(ClaimTypes.Name, LVM.UserName));
                        identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                        if (string.IsNullOrEmpty(ReturnUrl))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return Redirect(ReturnUrl);
                        }
                    }
                    ModelState.AddModelError("UserName", "用户名或密码不正确");
                }
                ModelState.AddModelError("UserName", "用户名或密码不正确");
            }
            return View();
        }//验证账号密码 并授权登陆
    }
}