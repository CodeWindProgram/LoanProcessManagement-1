using LoanProcessManagement.Application.Features.InstitutionMasters.Commands.CreateInstitutionMasters;
using LoanProcessManagement.Application.Features.InstitutionMasters.Commands.DeleteInstitutionMasters;
using LoanProcessManagement.Application.Features.InstitutionMasters.Commands.UpdateInstitutionMasters;
using LoanProcessManagement.Application.Features.InstitutionMasters.Queries.GetInstitutionMasters;
using LoanProcessManagement.Application.Features.InstitutionMasters.Queries.GetInstitutionMastersById;
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
    public class InstitutionController : ControllerBase
    {
        private readonly ILogger<InstitutionController> _logger;
        private readonly IMediator _mediator;

        public InstitutionController(ILogger<InstitutionController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        #region Api's for CRUD Institution Master in db by Dipti Pandhram - 18-03-2022

        /// <summary>
        /// Api which will Get Institution Master in db -18/03/2022
        ///	commented by Dipti P.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetInstitutions")]
        public async Task<ActionResult> GetInstitutions()
        {
            _logger.LogInformation("GetInstitutions Initiated");
            var dtos = await _mediator.Send(new GetInstitutionMastersQuery());
            _logger.LogInformation("GetInstitutions Completed");
            return Ok(dtos);
        }

        /// <summary>
        /// Api which will Create Institution Master in db -18/03/2022
        ///	commented by Dipti P.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("CreateInstitions")]
        public async Task<ActionResult> CreateInstitions(CreateInstitutionMastersCommand req)
        {
            _logger.LogInformation("CreateInstitions Initiated");
            var dtos = await _mediator.Send(req);
            _logger.LogInformation("CreateInstitions Completed");
            return Ok(dtos);
        }


        /// <summary>
        /// Api which will Delete Institution Master in db -18/03/2022
        ///	commented by Dipti P.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteInstitions/{id}")]
        public async Task<ActionResult> DeleteInstitions(long id)
        {
            _logger.LogInformation("Delete Insitution Initiated");
            var dtos = await _mediator.Send(new DeleteInstitutionMastersCommand(id));
            _logger.LogInformation("Delete Institution Completed");
            return Ok(dtos);
        }


        /// <summary>
        /// Api which will Update Institution Master in db -18/03/2022
        ///	commented by Dipti P.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPut("UpdateInstitution")]
        public async Task<ActionResult> UpdateInstitution(UpdateInstitutionMastersCommand req)
        {
            _logger.LogInformation("Update Institution Masters Initiated");
            var dtos = await _mediator.Send(req);
            _logger.LogInformation("Update Institution Completed");
            return Ok(dtos);
        }


        /// <summary>
        /// Api which will Get Institution Master By Id in db -18/03/2022
        ///	commented by Dipti P.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetInstitutionMasterById/{Id}")]
        public async Task<ActionResult> GetInstitutionMasterById(long Id)
        {
            _logger.LogInformation("GetIntitutionMasters Initiated");
            var dtos = await _mediator.Send(new GetInstitutionMastersByIdQuery(Id));
            _logger.LogInformation("GetIntitutionMasters Completed");
            return Ok(dtos);
        } 
        #endregion
    }
}
