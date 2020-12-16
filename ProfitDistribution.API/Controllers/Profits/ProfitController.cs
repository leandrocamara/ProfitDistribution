using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProfitDistribution.API.ViewModels;
using ProfitDistribution.Application.Abstraction.Common.Interfaces;
using ProfitDistribution.Application.Abstraction.Profits.Queries;
using ProfitDistribution.Application.Abstraction.Profits.ViewModels;

namespace ProfitDistribution.API.Controllers.Profits
{
    [ApiController]
    [Route("[controller]")]
    public class ProfitController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProfitController> _logger;

        public ProfitController(ILogger<ProfitController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("Distribution")]
        [ProducesResponseType(StatusCodes.Status200OK,
            Type = typeof(CommonResponseViewModel<GetProfitDistributionViewModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IResponse> GetProfitsDistribution([FromQuery] [Required] string amountAvailable)
        {
            var query = new GetProfitDistributionQuery(amountAvailable);
            return await _mediator.Send(query);
        }
    }
}