using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NaturalDisasterDatabaseWebsite.Models
{
    public class MarineDetailsViewModel
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "发生时间"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime marinetime { get; set; }
        [Display(Name ="参考位置")]
        public string marineplace { get;set;}
        [Display(Name ="经度")]
        public string marinelogitude { get;set;}
        [Display(Name ="纬度")]
        public string marinedimension { get;set;}
        [Display(Name ="经济损失")]
        public string marineloss { get;set;}
        [Display(Name ="伤亡人数")]
        public string marinecasualty { get;set;}
        [Display(Name ="类型")]
        public string marinestyle { get;set;}
        [Display(Name ="详情")]
        public string marinedetails { get;set;}
        public int userID { get;set;}
    }
}
