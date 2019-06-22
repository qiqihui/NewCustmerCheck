using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewCustomerCheck.Enum;
using NewCustomerCheck.Models;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;
using static NewCustomerCheck.Models.TaoBaoSumModel;

namespace NewCustomerCheck.Controllers
{
    public class TaoBaoController : Controller
    {
        private readonly NewCustomerCheckContext _context;

        public TaoBaoController(NewCustomerCheckContext context)
        {
            _context = context;
        }

        // GET: TaoBao
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActivityModel.ToListAsync());
        }

        // GET: TaoBao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityModel = await _context.ActivityModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (activityModel == null)
            {
                return NotFound();
            }

            return View(activityModel);
        }

        // GET: TaoBao/Create
        public IActionResult Create()
        {
            List<SelectListItem> selectLists = new List<SelectListItem>();
            selectLists.Add(new SelectListItem() { Value = ActivityKindEnum.AliPay.ToString(), Text = "支付宝（数据不全）" });
            selectLists.Add(new SelectListItem() { Value = ActivityKindEnum.TaoBao.ToString(), Text = "淘宝" });
            selectLists.Add(new SelectListItem() { Value = ActivityKindEnum.TianMao.ToString(), Text = "天猫" });
            ViewBag.ActivityKind = selectLists;
            return View();
        }

        // POST: TaoBao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ActivityApiID,ActivityName,ActivityKindEnum")] ActivityModel activityModel)
        {
            List<SelectListItem> selectLists = new List<SelectListItem>();
            selectLists.Add(new SelectListItem() { Value = ActivityKindEnum.AliPay.ToString(), Text = "支付宝（数据不全）" });
            selectLists.Add(new SelectListItem() { Value = ActivityKindEnum.TaoBao.ToString(), Text = "淘宝" });
            selectLists.Add(new SelectListItem() { Value = ActivityKindEnum.TianMao.ToString(), Text = "天猫" });
            ViewBag.ActivityKind = selectLists;
            if (ModelState.IsValid)
            {
                _context.Add(activityModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activityModel);
        }

        // GET: TaoBao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            List<SelectListItem> selectLists = new List<SelectListItem>();
            selectLists.Add(new SelectListItem() { Value = ActivityKindEnum.AliPay.ToString(), Text = "支付宝（数据不全）" });
            selectLists.Add(new SelectListItem() { Value = ActivityKindEnum.TaoBao.ToString(), Text = "淘宝" });
            selectLists.Add(new SelectListItem() { Value = ActivityKindEnum.TianMao.ToString(), Text = "天猫" });
            ViewBag.ActivityKind = selectLists;
            var activityModel = await _context.ActivityModel.FindAsync(id);
            if (activityModel == null)
            {
                return NotFound();
            }
            return View(activityModel);
        }

        // POST: TaoBao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ActivityApiID,ActivityName,ActivityKindEnum")] ActivityModel activityModel)
        {
            if (id != activityModel.ID)
            {
                return NotFound();
            }
            List<SelectListItem> selectLists = new List<SelectListItem>();
            selectLists.Add(new SelectListItem() { Value = ActivityKindEnum.AliPay.ToString(), Text = "支付宝（数据不全）" });
            selectLists.Add(new SelectListItem() { Value = ActivityKindEnum.TaoBao.ToString(), Text = "淘宝" });
            selectLists.Add(new SelectListItem() { Value = ActivityKindEnum.TianMao.ToString(), Text = "天猫" });
            ViewBag.ActivityKind = selectLists;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activityModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityModelExists(activityModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(activityModel);
        }

        // GET: TaoBao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityModel = await _context.ActivityModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (activityModel == null)
            {
                return NotFound();
            }
            List<SelectListItem> selectLists = new List<SelectListItem>();
            selectLists.Add(new SelectListItem() { Value = ActivityKindEnum.AliPay.ToString(), Text = "支付宝（数据不全）" });
            selectLists.Add(new SelectListItem() { Value = ActivityKindEnum.TaoBao.ToString(), Text = "淘宝" });
            selectLists.Add(new SelectListItem() { Value = ActivityKindEnum.TianMao.ToString(), Text = "天猫" });
            ViewBag.ActivityKind = selectLists;
            return View(activityModel);
        }

        // POST: TaoBao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activityModel = await _context.ActivityModel.FindAsync(id);
            _context.ActivityModel.Remove(activityModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityModelExists(int id)
        {
            return _context.ActivityModel.Any(e => e.ID == id);
        }

        public async Task<IActionResult> Sum(int ActivityID, TaoBaoSumModel sumModel)
        {
            var activity = await _context.ActivityModel.FirstOrDefaultAsync(i => i.ID == ActivityID);
            if (activity == null)
            {
                return NotFound();
            }
            var pageindex = 1;
            List<TaoBaoSumItem> ItemList = new List<TaoBaoSumItem>();
            while (true)
            {
                ITopClient client = new DefaultTopClient("http://gw.api.taobao.com/router/rest", Program.Websiteconfig.TaoBaoAppKey, Program.Websiteconfig.TaoBaoAppSecret, "json");
                TbkDgNewuserOrderSumRequest req = new TbkDgNewuserOrderSumRequest();
                req.PageSize = 100L;
                req.PageNo = pageindex;
                req.ActivityId = activity.ActivityApiID;
                TbkDgNewuserOrderSumResponse rsp = client.Execute(req);
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(TaoBaoSumModelOrgin));
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(rsp.Body));
                var modelOrgin = (TaoBaoSumModelOrgin)serializer.ReadObject(ms);

                if (modelOrgin.taoBaoSumModelSecond.taoBaoSumModel.taoBaoSumModel.Results.taoBaoSumItems == null) //没有数据
                {
                    sumModel.NoData = true;
                    break;
                }
                ItemList.AddRange(modelOrgin.taoBaoSumModelSecond.taoBaoSumModel.taoBaoSumModel.Results.taoBaoSumItems);
                if (modelOrgin.taoBaoSumModelSecond.taoBaoSumModel.taoBaoSumModel.HasNext == false)
                {
                    break;
                }
                pageindex++;
            }
            sumModel.DataModels = ItemList;
            sumModel.ActivityName = activity.ActivityName;
            sumModel.ActivityID = activity.ID;
            return View(sumModel);

        }

        public async Task<IActionResult> Detail(int ActivityID, TaoBaoDetailModel detailModel)
        {
            var activity = await _context.ActivityModel.FirstOrDefaultAsync(i => i.ID == ActivityID);
            if (activity == null)
            {
                return NotFound();
            }
            var pageindex = 1;

            List<TbkDgNewuserOrderGetResponse.MapDataDomain> ItemList = new List<TbkDgNewuserOrderGetResponse.MapDataDomain>(); 
            if (!detailModel.NoSearch)
            {
                detailModel.NoSearch = false;
                string FirstDate = "";
                string FinalDate = "";
                if (!string.IsNullOrEmpty(detailModel.FirstDate))
                {
                    string[] datesplit = detailModel.FirstDate.Split(" - ");
                    FirstDate = datesplit[0];
                    FinalDate = datesplit[1];
                }
                while (true)
                {
                    ITopClient client = new DefaultTopClient("http://gw.api.taobao.com/router/rest", Program.Websiteconfig.TaoBaoAppKey, Program.Websiteconfig.TaoBaoAppSecret, "json");
                    TbkDgNewuserOrderGetRequest req = new TbkDgNewuserOrderGetRequest();
                    req.PageSize = 100;
                    //req.AdzoneId = 123L;
                    req.PageNo = pageindex;
                    if (FirstDate != "" && FinalDate != "")
                    {
                        req.StartTime = DateTime.Parse(FirstDate);
                        req.EndTime = DateTime.Parse(FinalDate);
                    }
                    req.ActivityId = activity.ActivityApiID;
                    TbkDgNewuserOrderGetResponse rsp = client.Execute(req);
                    if (rsp.Results.Data.Results == null)
                    {
                        detailModel.NoData = true;
                        break;
                    }

                    ItemList.AddRange(rsp.Results.Data.Results);


                    if (rsp.Results.Data.HasNext == false)
                    {
                        break;
                    }

                    pageindex++;
                }
            }


            detailModel.ActivityID = activity.ID;
            detailModel.ActivityName = activity.ActivityName;
            detailModel.DataModels = ItemList;
            detailModel.ActivityKindEnum = activity.ActivityKindEnum;
            return View(detailModel);
        }
        


        public class TaoBaoDetailModel
        {
            public int ActivityID { get; set; }
            public string ActivityName { get; set; }
            public bool NoData { get; set; }
            public bool NoSearch { get; set; } = true;
            public string FirstDate { get; set; }



            public ActivityKindEnum ActivityKindEnum { get; set; }
            public List<TbkDgNewuserOrderGetResponse.MapDataDomain> DataModels { get; set; }

        }
        public class TaoBaoSumModel
        {
            public int ActivityID { get; set; }
            public string ActivityName { get; set; }

            public bool NoData { get; set; }

            public List<TaoBaoSumItem> DataModels { get; set; }
        }

        [DataContract]
        public class DetailMapModel
        {

            [DataMember(Name = "tb_trade_parent_id")]
            public long TbTradeParentId { get; set; }
            [DataMember(Name = "success_time")]
            public string SuccessTime { get; set; }
            [DataMember(Name = "status")]
            public long Status { get; set; }
            [DataMember(Name = "site_name")]
            public string SiteName { get; set; }
            [DataMember(Name = "site_id")]
            public long SiteId { get; set; }
            [DataMember(Name = "relation_id")]
            public string RelationId { get; set; }
            [DataMember(Name = "register_time")]
            public string RegisterTime { get; set; }
            [DataMember(Name = "receive_time")]
            public string ReceiveTime { get; set; }
            [DataMember(Name = "orders")]
            public List<OrderData> Orders { get; set; }
            [DataMember(Name = "order_tk_type")]
            public long OrderTkType { get; set; }
            [DataMember(Name = "mobile")]
            public string Mobile { get; set; }
            [DataMember(Name = "member_nick")]
            public string MemberNick { get; set; }
            [DataMember(Name = "member_id")]
            public long MemberId { get; set; }
            [DataMember(Name = "login_time")]
            public string LoginTime { get; set; }
            [DataMember(Name = "is_card_save")]
            public long IsCardSave { get; set; }
            [DataMember(Name = "get_rights_time")]
            public string GetRightsTime { get; set; }
            [DataMember(Name = "buy_time")]
            public string BuyTime { get; set; }
            [DataMember(Name = "biz_date")]
            public string BizDate { get; set; }
            [DataMember(Name = "bind_time")]
            public string BindTime { get; set; }
            [DataMember(Name = "bind_card_time")]
            public string BindCardTime { get; set; }
            [DataMember(Name = "adzone_name")]
            public string AdzoneName { get; set; }
            [DataMember(Name = "adzone_id")]
            public long AdzoneId { get; set; }
            [DataMember(Name = "activity_type")]
            public string ActivityType { get; set; }
            [DataMember(Name = "activity_id")]
            public string ActivityId { get; set; }
            [DataMember(Name = "accept_time")]
            public string AcceptTime { get; set; }
            [DataMember(Name = "union_id")]
            public string UnionId { get; set; }
            [DataMember(Name = "use_rights_time")]
            public string UseRightsTime { get; set; }
        }

        [DataContract]
        public class OrderData
        {

            [DataMember(Name = "commission")]
            public string Commission { get; set; }
            [DataMember(Name = "confirm_receive_time")]
            public string ConfirmReceiveTime { get; set; }
            [DataMember(Name = "order_no")]
            public string OrderNo { get; set; }
            [DataMember(Name = "pay_time")]
            public string PayTime { get; set; }
        }
    }
}
