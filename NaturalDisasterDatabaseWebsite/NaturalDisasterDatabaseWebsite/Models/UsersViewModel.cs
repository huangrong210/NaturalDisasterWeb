using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;

namespace NaturalDisasterDatabaseWebsite.Models
{
    //public class UsersViewModel : IdentityUser<int>
    public class UsersViewModel
    {
        ///Entity Framework 无法自动识别 InstructorID 作为此实体的主键，因为其名称不符合 ID 或 classnameID 命名约定。 因此，Key 特性用于将其识别为主键
        ///Entity Framework 无法自动识别 InstructorID 作为此实体的主键，因为其名称不符合 ID 或 classnameID 命名约定。 因此，Key 特性用于将其识别为主键
        ///[Key]
        ///public int floodID { get; set; }

        //[Display(Name = "ID")]
        [Key]
        public int ID { get; set; }

        //Display指定要显示的字段名称内容(如username在显示时会显示成账号)
        [Display(Name = "账号")]
        ///远程验证 [Remote(ActionName, ControllerName, ErrorMessage)]
        //[Remote("CheckName","Home", ErrorMessage="此账号已被占用,请改用其他账号")]
        //[Remote(action: "VerifyUsername", controller: "Home", AdditionalFields =nameof(username))]
        //[Remote(action: "VerifyUsername", controller: "Home")]
        ///* 将验证规则添加到模型
        ///* using System.ComponentModel.DataAnnotations;
        ///* DataAnnotations命名空间提供一组内置验证特性，可通过声明方式应用于类和属性
        ///* DataAnnotations还包含DataType等格式特性，有助于格式设置单不提供任何验证
        ///* 验证特性如：Required、StringLength、RegularExpression 和 Range 等验证特性
        ///* StringLength特性设置数据库中的最大长度，并为ASP.NET Core MVC提供客户端和服务器端验证，但该特性不会阻止用户在名称中输入空格，所以使用正则
        [Required(ErrorMessage = "账号不能为空")]
        [StringLength(20, ErrorMessage = "账号最多20个字符或中文")]
        [RegularExpression(@"^[^ ]+$", ErrorMessage = "账号不能有空格")]
        public string username { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "密码为6位数字")]
        [Display(Name = "密码")]
        //[DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "性别")]
        [Required(ErrorMessage = "请选择性别")]
        public string sex { get; set; }
        //[RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "邮箱格式不正确")]
        [RegularExpression(@"^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+((\.[a-zA-Z0-9_-]{2,3}){1,2})$", ErrorMessage = "邮箱格式不正确")]
        [Display(Name = "邮箱")]
        //[EmailAddress]
        public string email { get; set; }

        [Display(Name = "身份")]
        [Required(ErrorMessage = "身份不能为空")]
        ///[RegularExpression(@"^[01]$", ErrorMessage = "只能为0或1,0:普通用户(默认),1:管理员")]
        ///[Range(minimum:0, maximum:1, ErrorMessage = "只能为0或1,0:普通用户(默认),1:管理员")]
        public string status { get; set; }

        [Display(Name = "头像")]
        //[FileExtensions(Exceptions=".jpg,.png",ErrorMessage ="图片格式有误")]
        public string img { get; set; }

        [Display(Name = "电话")]
        [RegularExpression(@"^1[3458][0-9]{9}$", ErrorMessage = "手机号格式不正确")]
        public string telephone { get; set; }

        [Display(Name = "工作地点")]
        public string workplace { get; set; }

        [Display(Name = "从事职业")]
        public string occupation { get; set; }

        [Display(Name = "居住地址")]
        public string address { get; set; }

        //导航属性
        ///public UsersViewModel user { get; set; }
        ///public List<Science_essayViewModel> essay { get; set; }
        [Display(Name = "发布文章")]
        //public Science_essayViewModel essay { get; set; }

        //一个用户可以发布很多文章：用户ICollection，即如果导航属性可包含多个实体，则其类型必须是可添加、可删除和可更新实体的列表。 可指定 ICollection<T> 或诸如 List<T> 或 HashSet<T> 的类型。 如果指定 ICollection<T>，EF 默认会创建一个 HashSet<T> 集合
        public ICollection<Science_essayViewModel> essay { get; set; }
        //public Forum_msgViewModel forum_msgs { get; set; }

        //一个用户可以有很多留言
        [Display(Name ="文章留言")]
        public ICollection<Forum_msgViewModel> forum_msgs { get; set; }     
    }
}
 