using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NaturalDisasterDatabaseWebsite.Models
{
    public class FireViewModel
    {
        [Key]
        public int ID { get; set; }

        [Display(Name ="年份")]
        public string ffYears { get; set; }

        [Display(Name = "火灾次数")]
        public string ffNumbers { get; set; }

        [Display(Name = "一般火灾")]
        public string ffGeneralNumbers { get; set; }

        [Display(Name = "较大火灾")]
        public string ffMiddleNumbers { get; set; }

        [Display(Name = "重大火灾")]
        public string ffMajorNumbers { get; set; }

        [Display(Name = "特别重大火灾")]
        public string ffSpecialNumbers { get; set; }

        [Display(Name = "火场总面积")]
        public string ffTFireArea { get; set; }

        [Display(Name = "受灾森林面积")]
        public string ffTAffectedArea { get; set; }

        [Display(Name = "伤亡人数")]
        public string ffCasualtiesNumbers { get; set; }

        [Display(Name = "经济损失")]
        public string ffEconomicLossed { get; set; }

        [Display(Name = "备注")]
        public string ffRemarks { get; set; }
    }
}
