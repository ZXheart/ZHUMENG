using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyHome.Areas.Manage.Models
{
    public class Admin
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string PassWord { get; set; }

        public DateTime AddTime{ get; set; }

        public DateTime LastLoginTime{ get; set; }

    }
}
