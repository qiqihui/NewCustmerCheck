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
        public string TaoBaoAppKey { get; set; } = "27607206";

        [DataMember]
        [Display(Name = "淘宝接口密钥（AppSecret)")]
        public string TaoBaoAppSecret { get; set; } = "7610e054ce149026aed9c559543c85b5";

        [DataMember]
        [Display(Name = "支付宝接口AppID")]
        public string AliPayAppID { get; set; } = "2019042964325340";

        [DataMember]
        [Display(Name = "支付宝开发者私钥")]
        public string AliPayPrivateKey = "MIIEpQIBAAKCAQEA4P9Wzcq98DsQciha9FLBn1tc/XqQT6Ly40O/YvtKgVjKxt6Xu6aWKlVwcM1S/d894Hkao2sifALqjhrkCYVCFtFOGnBB89eYIemCLFSiBbRn/EV+yK927BtIGkJcOqQmJvwFPHxqUhtZeCURjBtVfsoqo1Xy1IqiY62+GKz8Ge0pH03g1g7FdDwH1n8cQpTs1iCRIN5QxRsIGDMEd75pE3NL7ygMK9F71UEDuSh9fCDyUYby/5movutwAZ+Dx7XpzpO8+53Qfl5wlgPtT/pPD2yrrtXZc/uLifU5InJx9ILcEonVfNvc7vGwX9DvfJWsgzz/jVYfcFoxBPgCJuYKfQIDAQABAoIBAQDSYQ5qSDtHiAK9q0w4jbTr64LMpLCRNh0EMZGf3LXysfKQ9wtLc92PYepMH0CNjxMNdE9bJE7PQ+7LxwsYd9iu+zCbegHBHgLrGqsUBmKlEOX2NYjx31dEN9I4c3pHfrsJ0raWswK7GUWUGJ0Ks3hCoIgzx6bR43sp1wgbjIwBNEXnwo0DlyzsYvknEmSXEJd83kCQW4rJmdP2geFNFm/0cyehMpZUi+tOraD6Qmww90o7IBli1zXHzaIgJutw8i5gM2+KtK+1y0P/qDKYkr0M6NOVtETfw6kwxqt+UlHhGCpacqSUSzObXXo6rNQr9msWt7cy6LTWhVpfArwNk3KFAoGBAPtEntPcpe1+70Plv0iE13JkD/zAZ4Yd4C6i4eoKPMBQpD78TlgchqQp4Hm3vKuraV7+d0sHfUDVt9G4fZIRGp6M6y4VtgBvgaeo1tTof07B5HhSBTO2bbUXbSRHl1f3Q4he4RRFkpq2p6Vm73ZNi/DWr8NTWVVZwH4tMokz941DAoGBAOU8EPVLgdlAO/GuUZ1eHBDGa5QpRNoQWT5QFRe1UQtNkVnfra1t5tfxUrq1aXhKpagpIQqNgh/APytxp78bM3IMVyAC1aR97KXsLUhCfqIS9l/xn0t7oy5p4EpoY9i1R4i62D7piqwS9j7soswaFbbbTvF2GXt5FjrDoXLZLK0/AoGBAOtA5DQYcoJaRkqb4OxU9CL17MIIouS/NBZ2Cm7GBvtIhX8zW2bDzowFaVaM4OkaJB38wlRNPshlUSXaRjdsLDAmYEtVqIHf5NTFD99nj0p93xuIL7arJyxWMqm1Hc4Og/w6WSJRwWF5gp0qMyngkRV87DNE5m8zCTcZuicbsLthAoGBAI4i3HD8TJsklQaaC8kD3WsZXQMVQ7figzN7/Fgi+QmFIycS5mGuz3/+Bkn2ylroDidiuTYN4C1HyuNpKZX5i8CfnjYfC9Fesyl+c+VmNZbRIysCar8m/lt9ErGQYLiyTpSdJhB8RpvDdiQ2Hgtn8SbcfOqDS/GfdwUg4C6SMn2JAoGATyxLfV444jvSTLkzatUGHSxRK6CIlaMDCLPVTNNQ6JeprdVkwhxT+HVcokx667JEDEdS2uP63ySOwCcZVkgWRVMx+pw86nhZtlbTK3sp9OHmpaPGFVFAaFNuLyOejC+XaltbC8sF+F7js7jxxvzDkbv1tSYGdALxJiE8kb1VHQA="; //开发者私钥

        [DataMember]
        [Display(Name = "支付宝公钥")]
        public string AliPayPublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAtCYbYgn3lAcm5PV3ytso5SwNT49jHwA3w13ujghER3LMSygUXXXsQBTTjArnZaFloJ4qk79IpbsFrwKkmN3/X1JlxCt3wRDC+wPWCuWRwOGSzFrLTDzXLtpswZ3WDyEstjOkUtOqQH8VkNo1w47d+TokQIHVSV9cyl0gHPzt0mrr/i/bRbxtBKxDRWWbsEdHTDfkuUCVSGutvKfPFOL82ENov3HTRiYZgEbShHqhxuOPnd1F13mS3024R35L1+uOO0x8c9w1CUzc2Pc8kAFupbcYU744NEf5M0rn1yUZwzGNTKgXTE7XpCKPfSDVIAb6H9NA6+3yLdu41ZLklEfDPwIDAQAB"; //阿里公钥

        [DataMember]
        [Display(Name = "支付宝PID")]
        public string Pid = "2088531078806400";
    }
}
