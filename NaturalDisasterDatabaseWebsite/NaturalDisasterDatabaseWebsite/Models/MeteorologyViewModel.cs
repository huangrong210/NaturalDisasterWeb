using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NaturalDisasterDatabaseWebsite.Models
{
    public class MeteorologyViewModel
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="年份")]
        public string mYears { get;set;}
        [Display(Name ="总受灾面积")]
        public string mTShouzArea { get;set;}
        [Display(Name ="总绝收面积")]
        public string mTJuesArea { get;set;}
        [Display(Name ="总受灾人口")]
        public string mManShouzNumbers { get;set;}
        [Display(Name ="总伤亡人数")]
        public string mCasualtiesNumbers { get;set;}
        [Display(Name ="经济损失")]
        public string mEconomicLosses { get;set;}
        [Display(Name ="备注")]
        public string mRemarks { get;set;}
    }
}
