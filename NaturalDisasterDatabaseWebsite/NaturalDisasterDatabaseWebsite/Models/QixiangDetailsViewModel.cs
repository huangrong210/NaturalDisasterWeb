using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NaturalDisasterDatabaseWebsite.Models
{
    public class QixiangDetailsViewModel
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "发生时间"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime qixiangtime { get; set; }
        [Display(Name =("参考位置"))]
        public string qixiangplace { get;set;}
        [Display(Name =("经度"))]
        public string qixianglogitude { get;set;}
        [Display(Name =("纬度"))]
        public string qixiangdimension { get;set;}
        [Display(Name =("经济损失"))]
        public string qixiangloss { get;set;}
        [Display(Name =("受灾面积"))]
        public string qixiangarea { get;set;}
        [Display(Name =("伤亡人数"))]
        public string qixiangcasualty { get;set;}
        [Display(Name =("灾害类型"))]
        public string qixiangstyle { get;set;}
        [Display(Name =("详情"))]
        public string qixiangdetails { get;set;}
        public int userID { get;set;}
    }
}
