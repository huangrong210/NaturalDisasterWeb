using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NaturalDisasterDatabaseWebsite.Models
{
    public class ForestViewModel
    {
        [Key]
        public int ID { get; set; }

        [Display(Name ="年份")]
        [Required]
        public string fbYears { get; set; }

        [Display(Name ="总发生面积")]
        public string fbTotalOccurArea { get; set; }

        [Display(Name ="总防治面积")]
        public string fbTotalControlArea { get; set; }

        [Display(Name ="总防治率")]
        public string fbTotalControlRate { get; set; }

        [Display(Name ="病害发生面积")]
        public string fbDiseasesOccurArea { get; set; }

        [Display(Name ="病害防治面积")]
        public string fbDiseasesControlArea { get; set; }

        [Display(Name ="病害防治率")]
        public string fbDiseasesControlRate { get; set; }

        [Display(Name ="虫害发生面积")]
        public string fbPestOccurArea { get; set; }

        [Display(Name ="虫害防治面积")]
        public string fbPestControlArea { get; set; }

        [Display(Name ="虫害防治率")]
        public string fbPestControlRate { get; set; }

        [Display(Name ="鼠害发生面积")]
        public string fbMouseOccurArea { get; set; }

        [Display(Name ="鼠害防治面积")]
        public string fbMouseControlArea { get; set; }

        [Display(Name ="鼠害防治率")]
        public string fbMouseControlRate { get; set; }

        [Display(Name ="有害植物发生面积")]
        public string fbHarmPlantsOccurArea { get; set; }

        [Display(Name ="有害植物防治面积")]
        public string fbHarmPlantsControlArea { get; set; }

        [Display(Name ="有害植物防治率")]
        public string fbHarmlPlantsControlRate { get; set; }

        [Display(Name ="经济损失")]
        public string fbEconomicLosses { get; set; }

        [Display(Name ="备注")]
        public string fbRemarks { get; set; }
    }
}
