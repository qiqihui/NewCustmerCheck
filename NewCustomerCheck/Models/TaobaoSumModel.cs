using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace NewCustomerCheck.Models
{
    [DataContract]
    public class TaoBaoSumModelOrgin
    {
        [DataMember(Name = "tbk_dg_newuser_order_sum_response")]
        public TaoBaoSumModelSecond taoBaoSumModelSecond { get; set; }
    }

    [DataContract]
    public class TaoBaoSumModelSecond
    {
        [DataMember(Name = "results")]
        public TaoBaoSumModelThried taoBaoSumModel { get; set; }
    }

    [DataContract]
    public class TaoBaoSumModelThried
    {
        [DataMember(Name = "data")]
        public TaoBaoSumModel taoBaoSumModel { get; set; }
    }

    [DataContract]
    public class TaoBaoSumModel
    {

        [DataMember(Name = "results")]
        public ResultMode Results { get; set; }

        [DataMember(Name = "has_next")]
        public bool HasNext { get; set; }

        [DataMember(Name = "page_no")]
        public int PageNo { get; set; }

        [DataContract]
        public class ResultMode
        {
            [DataMember(Name = "map")]
            public List<TaoBaoSumItem> taoBaoSumItems { get; set; }
        }


        [DataContract]
        public class TaoBaoSumItem 
        {

            [DataMember(Name = "activity_id")]
            public string ActivityId { get; set; }
            [DataMember(Name = "alipay_user_cnt")]
            public long AlipayUserCnt { get; set; }
            [DataMember(Name = "alipay_user_cpa_pre_amt")]
            public string AlipayUserCpaPreAmt { get; set; }
            [DataMember(Name = "bind_buy_user_cpa_pre_amt")]
            public string BindBuyUserCpaPreAmt { get; set; }
            [DataMember(Name = "bind_buy_valid_user_cnt")]
            public long BindBuyValidUserCnt { get; set; }
            [DataMember(Name = "bind_card_valid_user_cnt")]
            public long BindCardValidUserCnt { get; set; }
            [DataMember(Name = "biz_date")]
            public string BizDate { get; set; }
            [DataMember(Name = "login_user_cnt")]
            public long LoginUserCnt { get; set; }
            [DataMember(Name = "rcv_user_cnt")]
            public long RcvUserCnt { get; set; }
            [DataMember(Name = "rcv_valid_user_cnt")]
            public long RcvValidUserCnt { get; set; }
            [DataMember(Name = "re_buy_valid_user_cnt")]
            public long ReBuyValidUserCnt { get; set; }
            [DataMember(Name = "reg_user_cnt")]
            public long RegUserCnt { get; set; }
            [DataMember(Name = "relation_id")]
            public string RelationId { get; set; }
            [DataMember(Name = "valid_num")]
            public long ValidNum { get; set; }
        }
    }
}
