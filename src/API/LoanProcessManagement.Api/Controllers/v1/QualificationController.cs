using LoanProcessManagement.Application.Features.Qualification.Commands.CreateQualification;
using LoanProcessManagement.Application.Features.Qualification.Commands.DeleteQualification;
using LoanProcessManagement.Application.Features.Qualification.Commands.UpdateQualification;
using LoanProcessManagement.Application.Features.Qualification.Queries.GetQualificationById;
using LoanProcessManagement.Application.Features.Qualification.Queries.GetQualificationList;
using MediatR;
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
    public class QualificationController : ControllerBase
    {
        private readonly ILogger<QualificationController> _logger;
        private readonly IMediator _mediator;

        public QualificationController(ILogger<QualificationController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        #region Api's for CRUD Qualification in db by Dipti Pandhram - 21-03-2022

        /// <summary>
        /// Api which will Create Qualification in db -21/03/2022
        ///	commented by Dipti P.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("CreateQualification")]
        public async Task<ActionResult> CreateQualifictaion(CreateQualificationCommand req)
        {
            _logger.LogInformation("Create Qualification Initiated");
            var dtos = await _mediator.Send(req);
            _logger.LogInformation("Create Qualification Completed");
            return Ok(dtos);
        }


        /// <summary>
        /// Api which will Delete Qualification in db -21/03/2022
        ///	commented by Dipti P.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteQualification/{id}")]
        public async Task<ActionResult> DeleteQualification(long id)
        {
            _logger.LogInformation("DeleteQualification Initiated");
            var dtos = await _mediator.Send(new DeleteQualificationCommand(id));
            _logger.LogInformation("DeleteQualification Completed");
            return Ok(dtos);
        }



        /// <summary>
        /// Api which will Update Qualification in db -21/03/2022
        ///	commented by Dipti P.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPut("UpdateQualification")]
        public async Task<ActionResult> UpdateQualification(UpdateQualificationCommand req)
        {
            _logger.LogInformation("UpdateQualification Initiated");
            var dtos = await _mediator.Send(req);
            _logger.LogInformation("UpdateQualification Completed");
            return Ok(dtos);
        }


        /// <summary>
        /// Api which will Get All Qualification in db -21/03/2022
        ///	commented by Dipti P.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllQualification")]
        public async Task<ActionResult> GetAllQualification()
        {
            _logger.LogInformation("GetAllQualification Initiated");
            var dtos = await _mediator.Send(new GetQualificationListQuery());
            _logger.LogInformation("GetAllQualification Completed");
            return Ok(dtos);
        }


        /// <summary>
        /// Api which will Get Qualification By Id in db -21/03/2022
        ///	commented by Dipti P.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetQualificationById/{id}")]
        public async Task<ActionResult> GetQualificationById(long id)
        {
            _logger.LogInformation("GetQualificationById Initiated");
            var dtos = await _mediator.Send(new GetQualificationByIdQuery(id));
            _logger.LogInformation("GetQualificationById Completed");
            return Ok(dtos);
        } 
        #endregion

    }
}
