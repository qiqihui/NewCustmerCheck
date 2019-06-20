using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewCustomerCheck.Enum;
using NewCustomerCheck.Models;

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
    }
}
