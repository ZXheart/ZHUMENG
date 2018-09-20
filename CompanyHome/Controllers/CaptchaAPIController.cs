using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CompanyHome.Core_Captcha;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace CompanyHome.Controllers
{
    public class APIController : Controller
    {
        public IActionResult GetValidateCode()
        {
            byte[] data = null;
            string code = CaptchaHelper.RandomCode(5);
            HttpContext.Session.SetString("code", code);
            //TempData["code"] = code;
            //定义一个画板
            MemoryStream ms = new MemoryStream();
            using (Bitmap map = new Bitmap(80, 32))
            {
                //画笔,在指定画板画板上画图
                //g.Dispose();
                using (Graphics g = Graphics.FromImage(map))
                {
                    g.Clear(Color.White);
                    g.DrawString(code, new Font("黑体", 18.0F), Brushes.Blue, new Point(4, 3));
                    //绘制干扰线
                    CaptchaHelper.PaintInterLine(g, 6, map.Width, map.Height);
                }
                map.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            data = ms.GetBuffer();
            //存在session中
            return File(data, "image/jpeg");

        }
    }
}