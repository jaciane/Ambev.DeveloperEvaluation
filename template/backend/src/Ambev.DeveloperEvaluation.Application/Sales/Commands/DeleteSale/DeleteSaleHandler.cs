using Ambev.DeveloperEvaluation.Application.Users.DeleteUser;
using Ambev.DeveloperEvaluation.Common.Extensions;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.DeleteSale
{
    /// <summary>
    /// Handler for processing DeleteSaleCommand requests
    /// </summary>
    public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, DeleteSaleResponse>
    {
        private readonly IGenericRepository<Sale> _saleRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of DeleteSaleHandler
        /// </summary>
        /// <param name="saleRepository">The sale repository</param>
        /// <param name="validator">The validator for DeleteSaleCommand</param>
        public DeleteSaleHandler(IGenericRepository<Sale> saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<DeleteSaleResponse> Handle(DeleteSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new DeleteSaleValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var sale = await _saleRepository.GetByIdAsync(command.Id, cancellationToken);
            if (sale==null)
                throw new KeyNotFoundException($"Sale with ID {command.Id} not found");

            sale.IsCanceled=true;
            var success = await _saleRepository.UpdateAsync(sale, cancellationToken);

            ///Simulate publish sale delete event
            sale.PublishEventAsync("deletedSale")
                 .FireAndForgetSafeAsync(ex => Console.WriteLine($"Erro: {ex.Message}"));

            return new DeleteSaleResponse { Success = true };
        }
    }
}
