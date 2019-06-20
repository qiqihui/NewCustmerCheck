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