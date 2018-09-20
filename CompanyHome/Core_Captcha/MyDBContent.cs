using CompanyHome.Areas.Manage.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyHome.Core_Captcha
{
    public class MyDBContent : DbContext
    {
        public MyDBContent(DbContextOptions<MyDBContent> options) : base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<Page> Pages { get; set; }

        public DbSet<AboutUs> AboutUs { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<JoinUs> JoinUs { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
