using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NaturalDisasterDatabaseWebsite.Models
{
    public class EarthquakeViewModel
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="年份")]
        public string eYears { get;set;}
        [Display(Name ="地震次数")]
        public string eTotalNumbers { get;set;}
        [Display(Name ="伤亡人数")]
        public string eCasualties { get;set;}
        [Display(Name ="经济损失")]
        public string eEconomicLosses { get;set;}
        [Display(Name ="备注")]
        public string eRemarks { get;set;}
    }
}
