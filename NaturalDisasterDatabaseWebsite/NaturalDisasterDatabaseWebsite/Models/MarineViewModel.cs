using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NaturalDisasterDatabaseWebsite.Models
{
    public class MarineViewModel
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="年份")]
        public string maYears { get;set;}
        [Display(Name ="发生次数")] //全国
        public string maTOccurNumber { get;set;}
        [Display(Name ="伤亡人数")] //全国
        public string maCasualtiesNumbers { get;set;}
        [Display(Name ="经济损失")] //全国
        public string maEconomicLosses { get;set;}
        [Display(Name ="广西经济损失")]
        public string maGXEconomicLoss { get;set;}
        [Display(Name ="备注")]
        public string maRemarks { get;set;}
    }
}
