using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NaturalDisasterDatabaseWebsite.Models
{
    public class GeologicalViewModel
    {
        [Key]
        public int ID { get; set; }

        [Display(Name ="年份")]
        public string gYears { get; set; }

        [Display(Name ="发生起数")]
        public string gTOccurNumbers { get;set;}

        [Display(Name ="人员伤亡")]
        public string gCasualtiesNumbers { get;set;}

        [Display(Name ="经济损失")]
        public string gEconomicLosses { get;set;}

        [Display(Name ="防治项目数")]
        public string gCProjectNumbers { get;set;}

        [Display(Name ="防治项目总投资")]
        public string gControlInvest { get;set;}

        [Display(Name ="治理面积")]
        public string gZhiliArea { get;set;}

        [Display(Name ="备注")]
        public string gRemarks { get;set; }
    }
}
