using FluentValidation;
namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.EditSale
{
    /// <summary>
    /// Validates the <see cref="EditSaleCommand"/> to ensure all required fields are provided and valid.
    /// </summary>
    public class EditSaleValidator : AbstractValidator<EditSaleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditSaleValidator"/> class
        /// and defines validation rules for creating a sale.
        /// </summary>
        public EditSaleValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");

            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("CustomerId is required.");

            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("CustomerName is required.");

            RuleFor(x => x.BranchId)
                .NotEmpty().WithMessage("BranchId is required.");

            RuleFor(x => x.BranchName)
                .NotEmpty().WithMessage("BranchName is required.");

            RuleFor(x => x.Items)
                .NotNull().WithMessage("At least one item is required.")
                .Must(items => items.Any()).WithMessage("The sale must contain at least one item.");

            RuleForEach(x => x.Items).ChildRules(item =>
            {
                item.RuleFor(i => i.Id)
                   .NotEmpty().WithMessage("Id of the Sale Item is required.");

                item.RuleFor(i => i.ProductId)
                    .NotEmpty().WithMessage("ProductId is required.");

                item.RuleFor(i => i.ProductName)
                    .NotEmpty().WithMessage("ProductName is required.");

                item.RuleFor(i => i.UnitPrice)
                    .GreaterThan(0).WithMessage("UnitPrice must be greater than 0.");

                item.RuleFor(i => i.Quantity)
                    .GreaterThan(0).WithMessage("Quantity must be greater than 0.")
                    .LessThanOrEqualTo(20).WithMessage("You can't sell more than 20 identical items.");
            });
        }
    }
}
