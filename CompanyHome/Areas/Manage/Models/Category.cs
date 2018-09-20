using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyHome.Areas.Manage.Models
{
    public class Category
    {
        public Category()
        {
            GetNews = new List<News>();
        }
        public int ID { get; set; }

        [StringLength(15)]
        public string Name { get; set; }

        public DateTime AddTime { get; set; }

        public int Order { get; set; }

        public virtual List<News> GetNews { get; set; }
    }
}
