using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Aop.Api;
using Aop.Api.Request;
using Aop.Api.Response;
using Microsoft.AspNetCore.Mvc;
using NewCustomerCheck.Models;

namespace NewCustomerCheck.Controllers
{
    public class AliPayController : Controller
    {
        public async Task<IActionResult> Sum(SumModel sumModel)
        {
            if (sumModel.OrginDate != null) //如果开始搜索
            {
                List<AlipayOfflineSummaryModel> finalModelList = new List<AlipayOfflineSummaryModel>();
                List<DateTime> times = DateTimeToDateClass.DateStrToDoubleDateTime(sumModel.OrginDate);

                DateTime dt1 = new DateTime(times[0].Year, times[0].Month, times[0].Day);
                DateTime dt2 = new DateTime(times[1].Year, times[1].Month, times[1].Day);
                IAopClient client = new DefaultAopClient("https://openapi.alipay.com/gateway.do", Program.Websiteconfig.AliPayAppID, Program.Websiteconfig.AliPayPrivateKey, "json", "1.0", "RSA2", Program.Websiteconfig.AliPayPublicKey, "utf-8", false);
                for (DateTime dt3 = dt1;dt3 <= dt2; dt3 = dt3.AddDays(1))
                {
                    AlipayUserInviteOfflinesummaryQueryRequest request = new AlipayUserInviteOfflinesummaryQueryRequest();
                    request.BizContent = "{" +
                    "\"pid\":\"" + Program.Websiteconfig.Pid + "\"," +
                    "\"report_date\":\"" + dt3.ToString("yyyyMMdd") + "\"" +
                    //"\"partner_id\":\"m_qvdao1_qvdao2\"" +
                    "  }";
                    AlipayUserInviteOfflinesummaryQueryResponse response = client.Execute(request);
                    if (response.OfflineInviteNewerSummaryInfoList != null)
                    {
                        foreach (var rspitem in response.OfflineInviteNewerSummaryInfoList)
                        {
                            if (sumModel.OrginPartnerid != null)
                            {
                                if (rspitem.PartnerId == sumModel.OrginPartnerid)
                                {
                                    AlipayOfflineSummaryModel alipayOfflineSummaryModelitem = new AlipayOfflineSummaryModel()
                                    {
                                        ExtInfo = rspitem.ExtInfo,
                                        Pid = rspitem.Pid,
                                        ReportDate = rspitem.ReportDate,
                                        PartnerId = rspitem.PartnerId,
                                    };
                                    finalModelList.Add(alipayOfflineSummaryModelitem);
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                AlipayOfflineSummaryModel alipayOfflineSummaryModelitem = new AlipayOfflineSummaryModel()
                                {
                                    ExtInfo = rspitem.ExtInfo,
                                    Pid = rspitem.Pid,
                                    ReportDate = rspitem.ReportDate,
                                    PartnerId = rspitem.PartnerId,
                                };
                                finalModelList.Add(alipayOfflineSummaryModelitem);
                            }
                        }
                    }
                }
                sumModel.DataModelList = finalModelList;
                sumModel.NoData = false;

                sumModel.NoSearch = false;
            }
            return View(sumModel); 
        }

        public async Task<IActionResult> Detail(DetailModel detailModel)
        {
            if (detailModel.OrginDate != null)
            {
                detailModel.NoSearch = false;
                string reportdate = DateTimeToDateClass.DateStrToDateStr(detailModel.OrginDate);
                IAopClient client = new DefaultAopClient("https://openapi.alipay.com/gateway.do", Program.Websiteconfig.AliPayAppID, Program.Websiteconfig.AliPayPrivateKey, "json", "1.0", "RSA2", Program.Websiteconfig.AliPayPublicKey, "utf-8", false);
                var pageindex = 1;
                while (true)
                {
                    AlipayUserInviteOfflinedetailQueryRequest request = new AlipayUserInviteOfflinedetailQueryRequest();
                    request.BizContent = "{" +
                    "\"pid\":\"" + Program.Websiteconfig.Pid + "\"," +
                    "\"report_date\":\"" + reportdate + "\"," +
                    //"\"partner_id\":\"" + partner_id + "\"," +
                    "\"page\":" + pageindex + "," +
                    "\"page_size\":" + 500 +
                    "  }";
                    AlipayUserInviteOfflinedetailQueryResponse response = client.Execute(request);
                    if (response.OfflineDetailInfoList != null)
                    {
                        detailModel.DataModelList.AddRange(response.OfflineDetailInfoList);
                        detailModel.NoData = false;
                        pageindex++;
                    }
                    else
                    {
                        break;
                    }
                }

            }
            return View(detailModel);
        }
    }

    public class DetailModel
    {
        public bool NoData { get; set; } = true;

        public bool NoSearch { get; set; } = true;

        public string OrginDate { get; set; }

        public int PageIndex { get; set; } = 1;

        public List<OfflineDetailInfo> DataModelList { get; set; } = new List<OfflineDetailInfo>();
    }

    /// <summary>
    /// Sum页面模型
    /// </summary>
    public class SumModel
    {
        /// <summary>
        /// 原始数据
        /// </summary>
        public string OrginDate { get; set; }


        /// <summary>
        /// 原始数据
        /// </summary>
        public string OrginPartnerid { get; set; }

        public List<AlipayOfflineSummaryModel> DataModelList { get; set; }

        public bool NoData { get; set; } = true;

        public bool NoSearch { get; set; } = true;
    }

    public partial class DateTimeToDateClass
    {
        /// <summary>
        /// 将格式为MM/dd/yyyy转换为格式yyyyMMdd
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DateStrToDateStr(string str)
        {
            DateTimeFormatInfo ogdtFormat = new DateTimeFormatInfo();
            ogdtFormat.ShortDatePattern = "MM/dd/yyyy";
            DateTime date = Convert.ToDateTime(str, ogdtFormat);
            return date.ToString("yyyyMMdd");
        }
    }
}