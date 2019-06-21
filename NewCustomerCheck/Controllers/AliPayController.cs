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
                DateTimeFormatInfo ogdtFormat = new DateTimeFormatInfo();
                ogdtFormat.ShortDatePattern = "MM/dd/yyyy";
                DateTimeFormatInfo fndtFormat = new DateTimeFormatInfo();
                fndtFormat.ShortDatePattern = "yyyyMMdd";
                DateTime date = Convert.ToDateTime(sumModel.OrginDate, ogdtFormat);
                string reportdate = date.ToString("yyyyMMdd");
                IAopClient client = new DefaultAopClient("https://openapi.alipay.com/gateway.do", Program.Websiteconfig.AliPayAppID, Program.Websiteconfig.AliPayPrivateKey, "json", "1.0", "RSA2", Program.Websiteconfig.AliPayPublicKey, "utf-8", false);
                AlipayUserInviteOfflinesummaryQueryRequest request = new AlipayUserInviteOfflinesummaryQueryRequest();
                request.BizContent = "{" +
                "\"pid\":\"" + Program.Websiteconfig.Pid + "\"," +
                "\"report_date\":\"" + reportdate + "\"" +
                //"\"partner_id\":\"m_qvdao1_qvdao2\"" +
                "  }";
                AlipayUserInviteOfflinesummaryQueryResponse response = client.Execute(request);

                if (response.OfflineInviteNewerSummaryInfoList != null)
                {
                    List<AlipayOfflineSummaryModel> finalModelList = new List<AlipayOfflineSummaryModel>();
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

                    sumModel.DataModelList = finalModelList;
                    sumModel.NoData = false;
                }

                sumModel.NoSearch = false;
            }
            return View(sumModel); 
        }

        public async Task<IActionResult> Detail(DetailModel detailModel)
        {
            if (detailModel.OrginDate != null)
            {
                detailModel.NoSearch = false;
                DateTimeFormatInfo ogdtFormat = new DateTimeFormatInfo();
                ogdtFormat.ShortDatePattern = "MM/dd/yyyy";
                DateTime date = Convert.ToDateTime(detailModel.OrginDate, ogdtFormat);
                string reportdate = date.ToString("yyyyMMdd");
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
}