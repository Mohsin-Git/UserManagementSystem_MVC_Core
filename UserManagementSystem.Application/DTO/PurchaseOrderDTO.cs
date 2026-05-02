using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementSystem.Application.DTO
{
    public class PurchaseOrderDTO
    {
        public string? PONumber { get; set; }
        public string? SupplierName { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Today;
        public decimal TotalAmount { get; set; }
        public List<PurchaseOrderItemDTO> Items { get; set; } = new();
    }
}
