using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementSystem.Application.DTO;

namespace UserManagementSystem.Application.Validators
{
    public class PurchaseOrderDTOValidator : AbstractValidator<PurchaseOrderDTO>
    {
        public PurchaseOrderDTOValidator()
        {
            RuleFor(x => x.PONumber)
                .NotEmpty().WithMessage("PO Number is required")
                .MaximumLength(20);

            RuleFor(x => x.SupplierName)
                .NotEmpty().WithMessage("Supplier Name is required");

            RuleFor(x => x.OrderDate)
                .LessThanOrEqualTo(DateTime.Today);

            RuleFor(x => x.Items)
                .NotEmpty().WithMessage("At least one item required");

            RuleForEach(x => x.Items)
                .SetValidator(new PurchaseOrderItemDTOValidator());

            RuleFor(x => x)
                .Must(order =>
                    order.TotalAmount == order.Items.Sum(i => i.LineTotal))
                .WithMessage("Total amount mismatch");
        }
    }
}
