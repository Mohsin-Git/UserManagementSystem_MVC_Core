using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementSystem.Application.DTO;
using UserManagementSystem.Application.Interfaces;
using UserManagementSystem.Application.IServices;
using UserManagementSystem.Domain.Entities;

namespace UserManagementSystem.Application.ServiceImplementation
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public PurchaseOrderService(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }
        public async Task<int> SavePurchaseOrderAsync(PurchaseOrderDTO dto)
        {
            var order = new PurchaseOrder
            {
                PONumber = dto.PONumber,
                SupplierName = dto.SupplierName,
                OrderDate = dto.OrderDate,
                TotalAmount = dto.TotalAmount,
                Items = dto.Items.Select(i => new PurchaseOrderItem
                {
                    ItemName = i.ItemName,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    LineTotal = i.Quantity * i.UnitPrice
                }).ToList()
            };

            return await _purchaseOrderRepository.AddAsync(order);
        }
    }
}
