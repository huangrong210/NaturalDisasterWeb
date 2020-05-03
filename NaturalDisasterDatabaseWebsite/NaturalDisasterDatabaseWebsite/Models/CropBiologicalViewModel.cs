using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NaturalDisasterDatabaseWebsite.Models
{
    public class CropBiologicalViewModel
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "年份")]
        [Required]
        public string cbYears { get; set; }

        [Display(Name = "发生面积/万公顷次")]
        public string cbOccurArea { get; set; }

        [Display(Name = "防治面积/万公顷次")]
        public string cbControlArea { get; set; }

        [Display(Name = "挽回损失/万吨")]
        public string cbSaveEconomic { get; set; }

        [Display(Name = "实际损失/万吨")]
        public string cbRealEconomic { get; set; }

        [Display(Name = "备注")]
        public string cbRemarks { get; set; }
    }
}
