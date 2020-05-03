using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NaturalDisasterDatabaseWebsite.Models
{
    public class Science_essayViewModel
    //public class Science_essayViewModel : IdentityUser<int>
    {
        //DatabaseGenerated特性让你能自行指定主键，而不是让数据库自动指定主键
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int ID { get; set; } 

        [Required(ErrorMessage = "标题不能为空")]
        [StringLength(200, ErrorMessage = "标题最多200个字符或中文")]
        [Display(Name = "标题")]
        public string title { get; set; }

        [Display(Name ="作者")]
        [StringLength(20, ErrorMessage = "作者最多20个字符或中文")]
        public string author { get; set; }

        [Display(Name ="来源")]
        [StringLength(100, ErrorMessage = "来源最多100个字符或中文")]
        public string source { get; set; }

        [Display(Name ="发布时间")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime fb_time { get; set; }

        [Required(ErrorMessage = "文章内容不能为空")]
        [Display(Name = "内容")]
        public string wz_content { get; set; }

        //[Display(Name = "图片")]
        //public string wz_img { get; set; }

        [Required(ErrorMessage = "请选择文章类型")]
        [Display(Name = "类型")]
        public string wz_style { get; set; }

        [Display(Name ="状态")]
        public string state { get; set; }
        public int userID { get; set; }

        //导航属性
        //public UsersViewModel nickname { get; set; }
        [Display(Name ="账号")]
        public UsersViewModel user { get; set; }

        //一个Science_essay实体可以与任意数量的Forum_msg实体相关
        //一片文章可以有很多留言
        public ICollection<Forum_msgViewModel> forum_msgs { get; set; } //在做个人中心的我的文章时是这一行代码
        //public Forum_msgViewModel forum_msgs { get; set; }
    }
}
