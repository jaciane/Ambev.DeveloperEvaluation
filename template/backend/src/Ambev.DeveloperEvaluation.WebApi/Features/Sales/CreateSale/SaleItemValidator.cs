using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{

    /// <summary>
    /// Validator for individual sale items in the CreateSaleItemRequest.
    /// </summary>
    public class SaleItemValidator : AbstractValidator<CreateSaleItemRequest>
    {
        /// <summary>
        /// Initializes validation rules for a sale item.
        /// </summary>
        public SaleItemValidator()
        {
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
                .LessThan(x => x.UnitPrice * x.Quantity)
                .WithMessage("Discount cannot exceed the total item value.");
        }
    }
}
