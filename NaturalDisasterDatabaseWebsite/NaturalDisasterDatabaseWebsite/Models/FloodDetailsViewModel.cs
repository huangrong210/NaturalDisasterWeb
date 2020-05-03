using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NaturalDisasterDatabaseWebsite.Models
{
    public class FloodDetailsViewModel
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "发生时间"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime floodtime { get; set; }
        [Display(Name ="参考位置")]
        public string floodplace { get;set;}
        [Display(Name ="经度")]
        public string floodlogitude { get;set;}
        [Display(Name ="纬度")]
        public string flooddimension { get;set;}
        [Display(Name ="灾害级别")]
        public string floodlevel { get;set;}
        [Display(Name ="经济损失")]
        public string floodloss { get;set;}
        [Display(Name ="伤亡人数")]
        public string floodcasualty { get;set;}
        [Display(Name ="类型")]
        public string floodstyle { get;set;}
        [Display(Name ="受灾面积")]
        public string floodarea { get;set;}
        [Display(Name ="详情")]
        public string flooddetails { get;set;}
        public int userID { get;set;}
    }
}
