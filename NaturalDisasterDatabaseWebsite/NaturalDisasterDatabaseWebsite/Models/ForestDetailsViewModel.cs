using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NaturalDisasterDatabaseWebsite.Models
{
    public class ForestDetailsViewModel
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "发生时间"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime foresttime { get; set; }
        [Display(Name ="经度")]
        public string forestplace { get;set;}
        [Display(Name ="参考位置")]
        public string forestlogitude { get;set;}
        [Display(Name ="维度")]
        public string forestdimension { get;set;}
        [Display(Name ="损失")]
        public string forestloss { get;set;}
        [Display(Name ="类型")]
        public string foreststyle { get;set;}
        [Display(Name ="面积")]
        public string forestarea { get;set;}
        [Display(Name ="详情")]
        public string forestdetails { get;set;}
        public int userID { get;set;}
    }
}
