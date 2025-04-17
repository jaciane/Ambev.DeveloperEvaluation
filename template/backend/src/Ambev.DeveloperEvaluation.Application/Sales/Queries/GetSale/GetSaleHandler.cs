﻿using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Ambev.DeveloperEvaluation.Application.Sales.Queries;

namespace Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSale
{
    public class GetSaleHandler : IRequestHandler<GetSaleQuery, GetSaleResult>
    {
        private readonly IGenericRepository<Sale> _saleRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of GetSaleHandler
        /// </summary>
        /// <param name="saleRepository">The sale repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public GetSaleHandler(
            IGenericRepository<Sale> saleRepository,
            IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the GetSaleCommand request
        /// </summary>
        /// <param name="request">The GetSale command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale details if found</returns>
        public async Task<GetSaleResult> Handle(GetSaleQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetSaleValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var sale = await _saleRepository.GetByIdAsync(request.Id, cancellationToken);

            if (sale == null)
                throw new KeyNotFoundException($"Sale with ID {request.Id} not found");

            return _mapper.Map<GetSaleResult>(sale);
        }

    }
}
