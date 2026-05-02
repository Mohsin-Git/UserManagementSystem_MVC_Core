using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementSystem.Domain.Entities;

namespace UserManagementSystem.Application.Interfaces
{
    public interface IPurchaseOrderRepository
    {
        Task<int> AddAsync(PurchaseOrder order);
    }
}
