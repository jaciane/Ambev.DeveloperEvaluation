using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.EditSale
{
    /// <summary>
    /// Profile for mapping between Sale entity and EditSaleResponse
    /// </summary>
    /// 
    public class EditSaleProfile : Profile
    {

        /// <summary>
        /// Initializes the mappings for EditSale operation
        /// </summary>
        public EditSaleProfile()
        {
            CreateMap<EditSaleCommand, Sale>();
            CreateMap<EditSaleItem, SaleItem>();
            CreateMap<Sale, EditSaleResult>();
            CreateMap<SaleItem, EditSaleItemResult>();

        }
    }
}
