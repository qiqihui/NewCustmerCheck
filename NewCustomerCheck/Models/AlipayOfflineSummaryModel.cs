using Jayrock.Json.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace NewCustomerCheck.Models
{
    public class AlipayOfflineSummaryModel
    {
        /// <summary>
        /// 结算日期
        /// </summary>
        [Display(Name = "结算日期")]
        public string ReportDate { get; set; }

        /// <summary>
        /// 一级渠道 
        /// </summary>
        [Display(Name = "一级渠道")]
        public string Pid { get; set; }

        /// <summary>
        /// 二级渠道 
        /// </summary>
        [Display(Name = "二级渠道")]
        public string PartnerId { get; set; }

        /// <summary>
        /// 返佣扩展信息 
        /// </summary>
        [Display(Name = "返佣扩展信息")]
        public string ExtInfo { set
            {
                value = value.Replace("\\", "");
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<ExtInfoItem>));
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(value));
                ExtInfoList = (List<ExtInfoItem>)serializer.ReadObject(ms);
            }
        }

        public List<ExtInfoItem> ExtInfoList { get; set; }

        [Display(Name = "核销返佣金额")]
        public decimal settleAmountHexiao { get
            {
                if (ExtInfoList.Count != 0)
                {
                    decimal data = 0;
                    foreach (var extinfoitem in ExtInfoList)
                    {
                        data += extinfoitem.settleAmountHexiao;
                    }
                    return data;
                }
                else
                {
                    return 0;
                }
            }
        }

        [Display(Name = "绑卡返佣金额")]
        public decimal settleAmountBind {
            get
            {
                if (ExtInfoList.Count != 0)
                {
                    decimal data = 0;
                    foreach (var extinfoitem in ExtInfoList)
                    {
                        data += extinfoitem.settleAmountBind;
                    }
                    return data;
                }
                else
                {
                    return 0;
                }
            }
        }

        [Display(Name = "当日返佣金额")]
        public decimal settleAmount { get
            {
                if (ExtInfoList.Count != 0)
                {
                    decimal data = 0;
                    foreach (var extinfoitem in ExtInfoList)
                    {
                        data += extinfoitem.settleAmount;
                    }
                    return data;
                }
                else
                {
                    return 0;
                }
            }
        }

        [Display(Name = "权益领取用户数")]
        public decimal userPrizeCount {
            get
            {
                if (ExtInfoList.Count != 0)
                {
                    decimal data = 0;
                    foreach (var extinfoitem in ExtInfoList)
                    {
                        data += extinfoitem.userPrizeCount;
                    }
                    return data;
                }
                else
                {
                    return 0;
                }
            }
        }

        [Display(Name = "权益核销用户数")]
        public decimal userConsumeCount {
            get
            {
                if (ExtInfoList.Count != 0)
                {
                    decimal data = 0;
                    foreach (var extinfoitem in ExtInfoList)
                    {
                        data += extinfoitem.userConsumeCount;
                    }
                    return data;
                }
                else
                {
                    return 0;
                }
            }
        }

        [Display(Name = "可结算核销用户数")]
        public decimal userConsumeSettleCount {
            get
            {
                if (ExtInfoList.Count != 0)
                {
                    decimal data = 0;
                    foreach (var extinfoitem in ExtInfoList)
                    {
                        data += extinfoitem.userConsumeSettleCount;
                    }
                    return data;
                }
                else
                {
                    return 0;
                }
            }
        }

        [Display(Name = "实名用户数")]
        public decimal userCertCount {
            get
            {
                if (ExtInfoList.Count != 0)
                {
                    decimal data = 0;
                    foreach (var extinfoitem in ExtInfoList)
                    {
                        data += extinfoitem.userCertCount;
                    }
                    return data;
                }
                else
                {
                    return 0;
                }
            }
        }

        [Display(Name = "可结算实名用户数")]
        public decimal userCertSettleCount {
            get
            {
                if (ExtInfoList.Count != 0)
                {
                    decimal data = 0;
                    foreach (var extinfoitem in ExtInfoList)
                    {
                        data += extinfoitem.userCertSettleCount;
                    }
                    return data;
                }
                else
                {
                    return 0;
                }
            }
        }

        [Display(Name = "绑卡用户数")]
        public decimal userBindCardCount
        {
            get
            {
                if (ExtInfoList.Count != 0)
                {
                    decimal data = 0;
                    foreach (var extinfoitem in ExtInfoList)
                    {
                        data += extinfoitem.userBindCardCount;
                    }
                    return data;
                }
                else
                {
                    return 0;
                }
            }
        }

        [Display(Name = "可结算绑卡用户数")]
        public decimal userBindCardSettleCount {
            get
            {
                if (ExtInfoList.Count != 0)
                {
                    decimal data = 0;
                    foreach (var extinfoitem in ExtInfoList)
                    {
                        data += extinfoitem.userBindCardSettleCount;
                    }
                    return data;
                }
                else
                {
                    return 0;
                }
            }
        }
    }

    [DataContract]
    public class ExtInfoItem
    {
        [DataMember]
        [Display(Name = "区域系数")]
        public decimal lbs { get; set; }

        [DataMember]
        [Display(Name = "质量系数")]
        public decimal qulityRate { get; set; }

        [DataMember]
        [Display(Name = "核销基础单价")]
        public decimal basePrice { get; set; }

        [DataMember]
        [Display(Name = "绑卡单价")]
        public decimal bindPrice { get; set; }

        [DataMember]
        [Display(Name = "是否福利码（Y/N）")]
        public string promoterCode { get; set; }

        [DataMember]
        [Display(Name = "核销返佣金额")]
        public decimal settleAmountHexiao { get; set; }

        [DataMember]
        [Display(Name = "绑卡返佣金额")]
        public decimal settleAmountBind { get; set; }

        [DataMember]
        [Display(Name = "当日返佣金额")]
        public decimal settleAmount { get; set; }

        [DataMember]
        [Display(Name = "权益领取用户数")]
        public decimal userPrizeCount { get; set; }

        [DataMember]
        [Display(Name = "权益核销用户数")]
        public decimal userConsumeCount { get; set; }
        
        [DataMember]
        [Display(Name = "可结算核销用户数")]
        public decimal userConsumeSettleCount { get; set; }

        [DataMember]
        [Display(Name = "实名用户数")]
        public decimal userCertCount { get; set; }

        [DataMember]
        [Display(Name = "可结算实名用户数")]
        public decimal userCertSettleCount { get; set; }

        [DataMember]
        [Display(Name = "绑卡用户数")]
        public decimal userBindCardCount { get; set; }

        [DataMember]
        [Display(Name = "可结算绑卡用户数")]
        public decimal userBindCardSettleCount { get; set; }

    }

}
