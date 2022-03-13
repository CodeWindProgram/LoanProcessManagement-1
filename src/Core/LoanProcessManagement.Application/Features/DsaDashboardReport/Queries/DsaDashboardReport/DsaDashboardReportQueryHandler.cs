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

namespace LoanProcessManagement.Application.Features.DsaDashboardReport.Queries.DsaDashboardReport
{
    public class DsaDashboardReportQueryHandler : IRequestHandler<DsaDashboardReportQuery, Response<List<DsaDashboardReportDto>>>
    {
        private readonly IDsaDashboardReportRepository _dsaDashboardReportRepository;
        private readonly ILogger<DsaDashboardReportQueryHandler> _logger;
        private readonly IMapper _mapper;

        public DsaDashboardReportQueryHandler(IDsaDashboardReportRepository dsaDashboardReportRepository, ILogger<DsaDashboardReportQueryHandler> logger, IMapper mapper)
        {
            _dsaDashboardReportRepository = dsaDashboardReportRepository;
            _logger = logger;
            _mapper = mapper;
        }
       
        public async Task<Response<List<DsaDashboardReportDto>>> Handle(DsaDashboardReportQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var response = await _dsaDashboardReportRepository.GetDsaDashboardReport(request);
            var mappedResponse = _mapper.Map<List<DsaDashboardReportDto>>(response);
            _logger.LogInformation("Handle Completed");
            return new Response<List<DsaDashboardReportDto>>(mappedResponse, "Success");
        } 
        
    }
}
