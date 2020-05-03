using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NaturalDisasterDatabaseWebsite.Models
{
    public class QuakeDetailsViewModel
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "发生时间"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime quaketime { get; set; }
        [Display(Name ="参考位置")]
        public string quakeplace { get;set;}
        [Display(Name ="经度")]
        public string quakelongitude { get;set;}
        [Display(Name ="纬度")]
        public string quakedimension { get;set;}
        [Display(Name ="地震级别")]
        public string quakelevel { get;set;}
        [Display(Name ="深度")]
        public string quakedepth { get;set;}
        [Display(Name ="伤亡人数")]
        public string quakecasualty { get;set;}
        [Display(Name ="经济损失")]
        public string quakeloss { get;set;}
        [Display(Name ="受灾面积")]
        public string quakearea { get;set;}
        [Display(Name ="详情")]
        public string quakedetails { get;set;}
        public int userID { get;set;}
    }
}
