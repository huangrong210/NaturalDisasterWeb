using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NaturalDisasterDatabaseWebsite.Models
{
    public class GeologyDetailsViewModel
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "发生时间"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime geologytime { get; set; }
        [Display(Name ="参考位置")]
        public string geologyplace { get;set;}
        [Display(Name ="经度")]
        public string geologylogitude { get;set;}
        [Display(Name ="纬度")]
        public string geologydimension { get;set;}
        [Display(Name ="伤亡人数")]
        public string geologycasualty { get;set;}
        [Display(Name ="级别")]
        public string geologylevel { get;set;}
        [Display(Name ="类型")]
        public string geologystyle { get;set;}
        [Display(Name ="经济损失")]
        public string geologyloss { get;set;}
        [Display(Name ="受灾面积")]
        public string geologyarea { get;set;}
        [Display(Name ="详情")]
        public string geologydetails { get;set;}
        public int userID { get;set;}
    }
}
