using LoanProcessManagement.Application.Features.LpmCategories.Commands.CreateLpmCategory;
using LoanProcessManagement.Application.Features.LpmCategories.Commands.DeleteLpmCategory;
using LoanProcessManagement.Application.Features.LpmCategories.Commands.UpdateLpmCategory;
using LoanProcessManagement.Application.Features.LpmCategories.Queries.GetAllCategories;
using LoanProcessManagement.Application.Features.LpmCategories.Queries.GetLpmCategoryById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class LpmCategoryController : ControllerBase
    {
        private readonly ILogger<LpmCategoryController> _logger;
        private readonly IMediator _mediator;

        public LpmCategoryController(ILogger<LpmCategoryController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("GetLpmCategories")]
        public async Task<ActionResult> GetLpmCategories()
        {
            _logger.LogInformation("GetLpmCategories Initiated");
            var dtos = await _mediator.Send(new GetAllCategoriesQuery());
            _logger.LogInformation("GetLpmCategories Completed");
            return Ok(dtos);
        }

        [HttpPost("CreateCategory")]
        public async Task<ActionResult> CreateLpmCategory(CreateLpmCategoryCommand req)
        {
            _logger.LogInformation("CreateCategory Initiated");
            var dtos = await _mediator.Send(req);
            _logger.LogInformation("CreateCategory Completed");
            return Ok(dtos);
        }

        [HttpDelete("DeleteLpmCategory/{id}")]
        public async Task<ActionResult> DeleteLpmCategory(long id)
        {
            _logger.LogInformation("DeleteBranch Initiated");
            var dtos = await _mediator.Send(new DeleteLpmCategoryCommand(id));
            _logger.LogInformation("DeleteBranch Completed");
            return Ok(dtos);
        }

        [HttpPut("UpdateLpmCategory")]
        public async Task<ActionResult> UpdateLpmCategory(UpdateLpmCategoryCommand req)
        {
            _logger.LogInformation("UpdateLpmCategory Initiated");
            var dtos = await _mediator.Send(req);
            _logger.LogInformation("UpdateLpmCategory Completed");
            return Ok(dtos);
        }

        [HttpGet("GetCategoryTypeById/{id}")]
        public async Task<ActionResult> GetQueryTypeById(long id)
        {
            _logger.LogInformation("GetAllQueries Initiated");
            var dtos = await _mediator.Send(new GetLpmCategoryByIdCommand(id));
            _logger.LogInformation("GetAllQueries Completed");
            return Ok(dtos);
        }


    }
}
