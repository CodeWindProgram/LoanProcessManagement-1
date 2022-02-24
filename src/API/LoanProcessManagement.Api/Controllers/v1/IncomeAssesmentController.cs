using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTAddEnuiry;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTCreateEnquiry;
using LoanProcessManagement.Application.Features.IncomeAssesment.Queries.GetIncomeAssessment;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.AddIncomeAssessment;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanProcessManagement.Application.Features.IncomeAssesment.Queries.GetIsSubmitFromGst;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.UpdateSubmitGst;

namespace LoanProcessManagement.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class IncomeAssesmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public IncomeAssesmentController(IMediator mediator, ILogger<IncomeAssesmentController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("{ApplicantType}/{Lead_Id}")]
        public async Task<ActionResult> AddEnquiry([FromRoute] int ApplicantType , int Lead_Id)
        {
            _logger.LogInformation("GetHistory Initiated");
            var dtos = await _mediator.Send(new GstAddEnquiryCommand(ApplicantType, Lead_Id));
            _logger.LogInformation("GetHistory Completed");
            return Ok(dtos);
        }
        [HttpPost]
        public async Task<ActionResult> CreateGstEnquiry([FromBody] GstCreateEnquiryCommand request)
        {
            _logger.LogInformation("RegisterAsync Initiated");
            var dtos = await _mediator.Send(request);
            _logger.LogInformation("RegisterAsync Completed");
            return Ok(dtos);
        }

        #region GetIncomeAssessmentDetails API by Pratiksha Poshe - 14/02/2022
        /// <summary>
        /// 14/02/2021 - GetIncomeAssessmentDetails API
        /// Commented by Pratiksha Poshe
        /// </summary>
        /// <param name="lead_Id"></param>
        /// <param name="applicantType"></param>
        /// <returns></returns>
        [HttpGet("GetIncomeAssessmentDetailsByLeadId")]
        public async Task<ActionResult> GetIncomeAssessmentDetailsByLeadId([FromQuery] int applicantType, [FromQuery] long lead_Id)
        {
            _logger.LogInformation("GetIncomeAssessmentDetails Initiated");
            var result = await _mediator.Send(new GetIncomeAssessmentDetailsQuery(applicantType,lead_Id));
            _logger.LogInformation("GetIncomeAssessmentDetails Initiated");
            return Ok(result);
        }
        #endregion

        #region AddIncomeAssessmentDetails API by Pratiksha Poshe - 14/02/2022
        /// <summary>
        /// 14/02/2021 - AddIncomeAssessmentDetails API
        /// Commented by Pratiksha Poshe
        /// </summary>
        /// <param name="lead_Id"></param>
        /// <param name="applicantType"></param>
        /// <returns></returns>
        [HttpPost("AddIncomeAssessmentDetailsByLeadId")]
        public async Task<ActionResult> AddIncomeAssessmentDetailsByLeadId([FromBody] AddIncomeAssessmentDetailsCommand addIncomeAssessmentDetails)
        {
            _logger.LogInformation("AddIncomeAssessmentDetails Initiated");
            var result = await _mediator.Send(addIncomeAssessmentDetails);
            _logger.LogInformation("AddIncomeAssessmentDetails Initiated");
            return Ok(result);
        }
        #endregion


        [HttpGet("GetSubmit/{Id}")]
        public async Task<ActionResult> GetSubmit([FromRoute]long Id)
        {
            var dtos = await _mediator.Send(new GetIsSubmitFromGstQuery(Id));
            return Ok(dtos);
        }

        [HttpPut("UpdateSubmitGst")]
        public async Task<ActionResult> UpdateSubmitGst([FromBody] UpdateSubmitGstCommand request)
        {
            var dtos = await _mediator.Send(request);
            return Ok(dtos);
        }
    }
}