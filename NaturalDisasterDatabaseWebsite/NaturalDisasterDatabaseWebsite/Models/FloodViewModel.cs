using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NaturalDisasterDatabaseWebsite.Models
{
    public class FloodViewModel
    {
        [Key]
        public int ID { get; set; }

        [Display(Name ="年份")]
        public string fYears { get;set;}
        [Display(Name ="农业受灾面积")]
        public string fAgrishouzArea { get;set;}
        [Display(Name ="农业成灾面积")]
        public string fAgrichengzArea { get;set;}
        [Display(Name ="水灾受灾面积")]
        public string fWatershouzArea { get;set;}
        [Display(Name ="水灾成灾面积")]
        public string fWaterchengzArea { get;set;}
        [Display(Name ="旱灾水灾面积")]
        public string fDroughtshouzArea { get;set;}
        [Display(Name ="旱灾成灾面积")]
        public string fDroughtchengzArea { get;set;}
        [Display(Name ="除涝面积")]
        public string fDrainageArea { get;set;}
        [Display(Name ="经济损失")]
        public string fEconomicLosses { get;set;}
        [Display(Name ="备注")]
        public string fRemarks { get;set;}
    }
}
