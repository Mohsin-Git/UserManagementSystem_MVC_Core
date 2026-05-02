using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementSystem.Application.DTO;
using UserManagementSystem.Domain.Entities;

namespace UserManagementSystem.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PurchaseOrderDTO, PurchaseOrder>();
            CreateMap<PurchaseOrderItemDTO, PurchaseOrderItem>();
        }
    }
}
