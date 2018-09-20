using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CompanyHome.Core_Captcha;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Session;

namespace CompanyHome
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});
            #region sql连接配置
            var sqlConnection = Configuration.GetConnectionString("SqlServerConnection");
            services.AddDbContext<MyDBContent>(option => option.UseSqlServer(sqlConnection));
            #endregion
            services.AddSession(options =>
            {
                // 设置 Session 过期时间
                options.IdleTimeout = TimeSpan.FromDays(90);
            });//添加session
            #region 添加授权支持，并添加使用Cookie的方式，配置登录页面和没有权限时的跳转页面
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
              {
                options.LoginPath = new PathString("/Manage/Home/Index");
                options.AccessDeniedPath = new PathString("/denied");
            });
            #endregion
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();//验证中间件
            app.UseSession(); //使用session
            app.UseMvc(routes =>
            {
                #region 区域路由（后台）
                routes.MapRoute(
                    name: "areaname",
                    template: "{Manage:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapAreaRoute(
                    name: "Manage",
                    areaName: "Manage",
                    template: "Manage/{controller=Home}/{action=Index}"
                    );
                #endregion
                #region 路由（前台）
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
                #endregion
        }
    }
}
