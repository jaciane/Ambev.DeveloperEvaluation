using Ambev.DeveloperEvaluation.Common.Extensions;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.EditSale
{
    public class EditSaleHandler : IRequestHandler<EditSaleCommand, EditSaleResult>
    {

        private readonly IGenericRepository<Sale> _saleRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of EditSaleHandler
        /// </summary>
        /// <param name="saleRepository">The sale repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public EditSaleHandler(IGenericRepository<Sale> saleRepository,IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the EditSaleCommand request
        /// </summary>
        /// <param name="request">The EditSale command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Editd sale</returns>
        public async Task<EditSaleResult> Handle(EditSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new EditSaleValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var sale = _mapper.Map<Sale>(command);
            var EditdSale = await _saleRepository.UpdateAsync(sale, cancellationToken);

            ///Simulate publish sale modified event
            sale.PublishEventAsync("SaleModified")
                 .FireAndForgetSafeAsync(ex => Console.WriteLine($"Erro: {ex.Message}"));

            return _mapper.Map<EditSaleResult>(EditdSale);
        }
    }
}
