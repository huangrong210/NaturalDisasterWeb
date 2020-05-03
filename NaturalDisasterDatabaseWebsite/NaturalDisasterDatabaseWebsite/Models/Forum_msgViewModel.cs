using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace NaturalDisasterDatabaseWebsite.Models
{
    //public class Forum_msgViewModel : IdentityUser<int>
    public class Forum_msgViewModel
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="评论内容")]
        public string comment { get; set; }

        //DataType属性用于指定比数据库内部类型更具体的数据类型，它枚举了多种数据类型：如日期、时间、电话号码、货币、电子邮件地址等
        //DataFormat特性用于显式指定日期格式
        [Display(Name ="发布时间"),DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime comment_time { get; set; }
        public int userID { get; set; }
        public int essayID { get; set; }

        //导航属性
        [Display(Name = "用户账号")]
        public UsersViewModel user { get; set; }
        //public List<Science_essayViewModel> essays { get; set; }
        //public ICollection<Science_essayViewModel> essay { get; set; }

        [Display(Name ="文章标题")]
        public Science_essayViewModel essay { get; set; }
    }
}
