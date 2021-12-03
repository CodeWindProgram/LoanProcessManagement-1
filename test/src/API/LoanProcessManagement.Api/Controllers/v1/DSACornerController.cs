using LoanProcessManagement.Application.Features.DSACorner.Query.CircularList;
using LoanProcessManagement.Application.Features.DSACorner.Query.DSACornerList;
using LoanProcessManagement.Application.Features.DSACorner.Query.TrainingVideosList;
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
    public class DSACornerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public DSACornerController(IMediator mediator, ILogger<DSACornerController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        #region DSA Corener - Ramya Guduru- 25/11/2021
        /// <summary>
        /// DSA Corner - Ramya Guduru - 25/11/2021
        /// </summary>
        /// <param name="DSACorner"></param>
        /// <returns></returns>
        [HttpGet("DSACorner/{ParentId}")]
        public async Task<IActionResult> DSACornerList([FromRoute] DSACornerListQuery dsaCornerList)
        {
            return Ok(await _mediator.Send(dsaCornerList));
        }
        #endregion

        #region  TrainingVideosList - Ramya Guduru- 25/11/2021
        /// <summary>
        /// DSA Corner - Ramya Guduru - 25/11/2021
        /// </summary>
        /// <param name="TrainingVideosList"></param>
        /// <returns></returns>
        [HttpGet("TrainingVideos/{ParentId}")]
        public async Task<IActionResult> TrainingVideosList([FromRoute] TrainingVideosListQuery trainingVideosList)
        {
            return Ok(await _mediator.Send(trainingVideosList));
        }
        #endregion
        #region CircularList  - Ramya Guduru- 25/11/2021
        /// <summary>
        /// DSA Corner - Ramya Guduru - 25/11/2021
        /// </summary>
        /// <param name="CircularList"></param>
        /// <returns></returns>
        [HttpGet("Circular/{ParentId}")]
        public async Task<IActionResult> CircularList([FromRoute] CircularListQuery circular)
        {
            return Ok(await _mediator.Send(circular));
        }
        #endregion
    }
}
