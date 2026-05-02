using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementSystem.Application.DTO;

namespace UserManagementSystem.Application.Validators
{
    public class PurchaseOrderItemDTOValidator : AbstractValidator<PurchaseOrderItemDTO>
    {
        public PurchaseOrderItemDTOValidator()
        {
            RuleFor(x => x.ItemName).NotEmpty().WithMessage("Item Name is required");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0");
            RuleFor(x => x.UnitPrice).GreaterThan(0).WithMessage("Unit Price must be positive");
            RuleFor(x => x.LineTotal)
                .GreaterThan(0);
        }
    }
}
