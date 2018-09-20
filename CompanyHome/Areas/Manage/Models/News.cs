using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyHome.Areas.Manage.Models
{
    public class News
    {

        public int ID { get; set; }

        [ForeignKey("CID")]
        public int CID { get; set; }

        public int Maxlevel { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime AddTime { get; set; }
    }
}
