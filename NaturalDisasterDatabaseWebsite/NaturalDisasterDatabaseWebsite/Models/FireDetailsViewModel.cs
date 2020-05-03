using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NaturalDisasterDatabaseWebsite.Models
{
    public class FireDetailsViewModel
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "发生时间"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime firetime { get; set; }
        [Display(Name ="参考位置")]
        public string fireplace { get;set;}
        [Display(Name ="经度")]
        public string firelogitude { get;set;}
        [Display(Name ="纬度")]
        public string firedimension { get;set;}
        [Display(Name ="伤亡人数")]
        public string firecasualty { get;set;}
        [Display(Name ="经济损失")]
        public string fireloss { get;set;}
        [Display(Name ="受灾面积")]
        public string firearea { get;set;}
        [Display(Name ="火灾级别")]
        public string fireslevel { get;set;}
        [Display(Name ="详情")]
        public string firedetails { get;set;}
        public int useID { get;set;}
    }
}
