using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyHome.Areas.Manage.Models
{
    public class Comment
    {
        public virtual News GetNews { get; set; }

        public int ID { get; set; }

        [ForeignKey("NewsID")]
        public int NewsID { get; set; }

        public int Level { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(400)]
        public string Content { get; set; }

        public string Ip { get; set; }

        public DateTime AddTime { get; set; }
    }
}
