using Ambev.DeveloperEvaluation.Application.Sales.Commands.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.Commands.EditSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.EditSale
{
    /// <summary>
    /// Profile for mapping between Application and API EditSale responses
    /// </summary>
    public class EditSaleProfilecs : Profile
    {
        /// <summary>
        /// Initializes the mappings for EditSale feature
        /// </summary>
        public EditSaleProfilecs()
        {
            CreateMap<EditSaleRequest, EditSaleCommand>();
            CreateMap<EditSaleItemRequest, EditSaleItem>();
            CreateMap<EditSaleResult, EditSaleResponse>();
            CreateMap<EditSaleItemResult, EditSaleItemResponse>();

        }
    }
}
