using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagementSystem.Application.DTO;
using UserManagementSystem.Application.IServices;
using UserManagementSystem.Domain.Entities;

namespace UserManagementSystem.Controllers
{
    [Authorize]
    public class PurchaseOrdersController : Controller
    {
        private readonly IPurchaseOrderService _Pos;
        public PurchaseOrdersController(IPurchaseOrderService Pos)
        {
            this._Pos = Pos;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreatePO()
        {
            return View(new PurchaseOrderDTO
            {
                Items = new List<PurchaseOrderItemDTO>
            {
                new PurchaseOrderItemDTO()
            }
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreatePO(PurchaseOrderDTO order)
        {
            if (ModelState.IsValid)
            {
                //foreach (var item in order.Items)
                //{
                //    item.LineTotal = item.Quantity * item.UnitPrice;
                //}
                //order.TotalAmount = order.Items.Sum(i => i.LineTotal);
                await this._Pos.SavePurchaseOrderAsync(order);
                return RedirectToAction("Index");
            }
            return View(order);
        }
    }
}
