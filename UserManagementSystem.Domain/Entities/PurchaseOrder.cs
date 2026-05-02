using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementSystem.Domain.Entities
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public string? PONumber { get; set; }
        public string? SupplierName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<PurchaseOrderItem> Items { get; set; } = new();
    }
}
