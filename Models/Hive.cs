using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoneyDo.Models
{
    public class Hive
    {
        public int HiveId { get; set; }

        [Display(Name = "Honey Produced(L)")]
        public double HoneyProduced { get; set; }

        [Display(Name = "Bee Count")]
        public int BeeCount { get; set; }

        [Display(Name = "Type of Bees")]
        public string BeeType { get; set; }
        
        [Display(Name = "Hive Location")]
        public string Location { get; set; }

        [Display(Name = "Name of Hive")]
        public string HiveName { get; set; }
    }
}
