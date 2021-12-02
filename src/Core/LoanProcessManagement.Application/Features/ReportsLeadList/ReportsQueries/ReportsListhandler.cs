using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.ReportsLeadList.ReportsQueries
{
   public class ReportsListhandler : IRequestHandler<ReportsListQuery, Response<IEnumerable<ReportsListVm>>>
    {
        private readonly IReportsLeadListRepository _reportsLeadListRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ReportsListhandler(IMapper mapper, IReportsLeadListRepository reportsLeadListRepository)
        {
            _mapper = mapper;
            _reportsLeadListRepository = reportsLeadListRepository;
        }
        #region Logger For the get all Reports Tiles Services - Ramya Guduru - 2/12/2021
        /// <summary>
        /// 2/12/2021 - Logger For the Report Tiles 
        /// commented by Ramya Guduru
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Response</returns>
        public async Task<Response<IEnumerable<ReportsListVm>>> Handle(ReportsListQuery request, CancellationToken cancellationToken)
        {
            var reportsList = await _reportsLeadListRepository.ReportsList(request.ParentId);
            var reportsDto = _mapper.Map<IEnumerable<ReportsListVm>>(reportsList);
            var response = new Response<IEnumerable<ReportsListVm>>(reportsDto);
            return response;
        }
        #endregion
    }
}
