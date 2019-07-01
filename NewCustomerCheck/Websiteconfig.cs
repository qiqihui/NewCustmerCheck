using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace NewCustomerCheck
{
    [DataContract]
    public class Websiteconfig
    {
        [DataMember]
        [Display(Name = "淘宝接口AppKey")]
        public string TaoBaoAppKey { get; set; } = "";

        [DataMember]
        [Display(Name = "淘宝接口密钥（AppSecret)")]
        public string TaoBaoAppSecret { get; set; } = "";

        [DataMember]
        [Display(Name = "支付宝接口AppID")]
        public string AliPayAppID { get; set; } = "";

        [DataMember]
        [Display(Name = "支付宝开发者私钥")]
        public string AliPayPrivateKey = ""; //开发者私钥

        [DataMember]
        [Display(Name = "支付宝公钥")]
        public string AliPayPublicKey = ""; //阿里公钥

        [DataMember]
        [Display(Name = "支付宝PID")]
        public string Pid = "";
    }
}
