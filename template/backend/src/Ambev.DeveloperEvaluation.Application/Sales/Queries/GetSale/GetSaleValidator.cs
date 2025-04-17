using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSale
{
    /// <summary>
    /// Validator for GetSaleCommand
    /// </summary>
    public class GetSaleValidator : AbstractValidator<GetSaleQuery>
    {

        /// <summary>
        /// Initializes validation rules for GetSaleCommand
        /// </summary>
        public GetSaleValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Sale ID is required");
        }
    }
}
