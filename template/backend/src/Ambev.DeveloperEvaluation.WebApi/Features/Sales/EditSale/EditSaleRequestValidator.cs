using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.EditSale
{
    /// <summary>
    /// Validator for the EditSale request.
    /// </summary>
    /// 
    public class EditSaleRequestValidator : AbstractValidator<EditSaleRequest>
    {
        /// <summary>
        /// Initializes validation rules for creating a new sale.
        /// </summary>
        public EditSaleRequestValidator()
        {
            RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id is required.");

            RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("CustomerId is required.");

            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("Customer name is required.")
                .MaximumLength(100).WithMessage("Customer name cannot exceed 100 characters.");

            RuleFor(x => x.BranchId)
                .NotEmpty().WithMessage("BranchId is required.");

            RuleFor(x => x.BranchName)
                .NotEmpty().WithMessage("Branch name is required.")
                .MaximumLength(100).WithMessage("Branch name cannot exceed 100 characters.");

            RuleFor(x => x.Items)
                .NotEmpty().WithMessage("At least one item is required.");

            RuleForEach(x => x.Items).SetValidator(new EditSaleItemRequestValidator());

        }
    }
}
