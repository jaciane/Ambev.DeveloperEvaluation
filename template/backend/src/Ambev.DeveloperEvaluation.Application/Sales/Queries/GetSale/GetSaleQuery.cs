﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSale
{
    public record GetSaleQuery : IRequest<GetSaleResult>
    {
        /// <summary>
        /// The unique identifier of the sale to retrieve
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Initializes a new instance of GetSaleQuery
        /// </summary>
        /// <param name="id">The ID of the sale to retrieve</param>
        public GetSaleQuery(Guid id)
        {
            Id = id;
        }
    }
}
