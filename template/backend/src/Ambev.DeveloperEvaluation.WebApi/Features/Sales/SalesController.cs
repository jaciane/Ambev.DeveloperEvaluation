using Ambev.DeveloperEvaluation.Application.Sales.Commands.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.Commands.DeleteSale;
using Ambev.DeveloperEvaluation.Application.Sales.Queries.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SalesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves a sale by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale details if found</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetSaleResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSale([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var request = new GetSaleRequest { Id = id };
                var validator = new GetSaleRequestValidator();
                var validationResult = await validator.ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors);

                var command = _mapper.Map<GetSaleQuery>(request.Id);
                var response = await _mediator.Send(command, cancellationToken);

                return Ok(new ApiResponseWithData<GetSaleResponse>
                {
                    Success = true,
                    Message = "Sale retrieved successfully",
                    Data = _mapper.Map<GetSaleResponse>(response)
                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ApiResponse { Message = ex.Message });
            }
            catch (Exception )
            {
                return StatusCode(500, new ApiResponse { Message = "An unexpected error occurred" });
            }
        }

        /// <summary>
        /// Handles the creation of a new sale.
        /// </summary>
        /// <param name="request">The sale data to create.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The created sale details.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSale([FromBody] CreateSaleRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new CreateSaleRequestValidator();
                var validationResult = await validator.ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors);

                var command = _mapper.Map<CreateSaleCommand>(request);
                var response = await _mediator.Send(command, cancellationToken);

                return Created(string.Empty, new ApiResponseWithData<CreateSaleResponse>
                {
                    Success = true,
                    Message = "Sale created successfully",
                    Data = _mapper.Map<CreateSaleResponse>(response)
                });
            }
            catch (Exception)
            {
                return StatusCode(500, new ApiResponse { Message = "An unexpected error occurred" });
            }
        }

        /// <summary>
        /// Deletes a sale by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the sale to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Success response if the sale was deleted</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSale([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var request = new DeleteSaleRequest { Id = id };
                var validator = new DeleteSaleRequestValidator();
                var validationResult = await validator.ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors);

                var command = _mapper.Map<DeleteSaleCommand>(request.Id);
                await _mediator.Send(command, cancellationToken);

                return Ok(new ApiResponse
                {
                    Success = true,
                    Message = "Sale deleted successfully"
                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ApiResponse { Message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new ApiResponse { Message = "An unexpected error occurred" });
            }
        }
    }
}
