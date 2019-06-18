using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewCustomerCheck.Models
{
    [Display(Name = "日志")]
    public class Log
    {
        public int ID { get; set; }
        
        [Display(Name = "错误信息")]
        public string ErrorMsg { get; set; }

        [Display(Name = "日期")]
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
