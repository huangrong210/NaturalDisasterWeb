using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NaturalDisasterDatabaseWebsite.Models
{
    public class CropDetailsViewModel
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "发生时间"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime croptime { get; set; }
        [Display(Name ="参考位置")]
        public string cropplace { get;set; }
        [Display(Name ="经度")]
        public string croplongitude { get;set; }
        [Display(Name ="维度")]
        public string cropdimension { get;set; }
        [Display(Name ="类型")]
        public string cropstyle { get;set; }
        [Display(Name ="损失")]
        public string croploss { get;set; }
        [Display(Name ="面积")]
        public string croparea { get;set; }
        [Display(Name ="详情")]
        public string cropdetails { get;set; }
        public int userID { get;set; }
    }
}
