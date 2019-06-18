using NewCustomerCheck.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewCustomerCheck.Models
{
    [Display]
    public class ActivityModel
    {
        
        public int ID { get; set; }

        [Display(Name = "活动ID")]
        public string ActivityApiID { get; set; }

        [Display(Name = "活动名字")]
        public string ActivityName { get; set; }

        [Display(Name = "活动类型")]
        public ActivityKindEnum ActivityKindEnum { get; set; }
    }
}
