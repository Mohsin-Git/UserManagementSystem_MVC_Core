using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementSystem.Application.DTO;

namespace UserManagementSystem.Application.IServices
{
    public interface IPurchaseOrderService
    {
        Task<int> SavePurchaseOrderAsync(PurchaseOrderDTO dto);
    }
}
