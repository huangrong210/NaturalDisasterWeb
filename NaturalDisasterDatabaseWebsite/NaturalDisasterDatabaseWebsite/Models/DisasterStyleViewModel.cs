using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace NaturalDisasterDatabaseWebsite.Models
{
    public class DisasterStyleViewModel
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "灾害名称")]
        public string natrualDisasterName { get; set; }
        [Display(Name = "灾害简介")]
        public string natrualDisasterDefinition { get; set; }
        [Display(Name = "灾害图片")]
        public string imgSrc { get; set; }
        [Display(Name = "了解更多")]
        public string href { get; set; }
    }
}
