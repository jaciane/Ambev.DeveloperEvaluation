using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.EditSale
{
    /// <summary>
    /// Validator for individual sale items in the EditSaleItemRequest.
    /// </summary>
    public class EditSaleItemRequestValidator : AbstractValidator<EditSaleItemRequest>
    {
        /// <summary>
        /// Initializes validation rules for edit a sale item.
        /// </summary>
        public EditSaleItemRequestValidator()
        {
            RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id of Sale Item is required.");

            RuleFor(x => x.ProductId)
                    .NotEmpty().WithMessage("ProductId is required.");

            RuleFor(x => x.ProductName)
                    .NotEmpty().WithMessage("Product name is required.")
                    .MaximumLength(50).WithMessage("Product name cannot exceed 50 characters.");

            RuleFor(x => x.UnitPrice)
                    .GreaterThan(0).WithMessage("Unit price must be greater than zero.");

            RuleFor(x => x.Quantity)
                    .GreaterThan(0).WithMessage("Quantity must be greater than zero.");

            RuleFor(x => x.Discount)
                    .GreaterThanOrEqualTo(0).WithMessage("Discount cannot be negative.")
                    .LessThan(x => x.UnitPrice* x.Quantity)
                    .WithMessage("Discount cannot exceed the total item value.");
        }

    }
}
