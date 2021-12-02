using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.ReportsLeadList.Queries
{
    public class GetReportsLeadListQueryHandler : IRequestHandler<GetReportsLeadListQuery, Response<IEnumerable<GetReportsLeadListQueryVm>>>
    {
        private readonly IMapper _mapper;
        private readonly IReportsLeadListRepository _reportsLeadListRepository;
        
        public GetReportsLeadListQueryHandler(IMapper mapper, IReportsLeadListRepository reportsLeadListRepository)
        {
            _reportsLeadListRepository = reportsLeadListRepository;
            _mapper = mapper;
        }

        #region Logger For the get all ReportsLeadList - Ramya Guduru - 2/12/2021
        /// <summary>
        /// 2/12/2021 - Logger For the ReportsLeadList 
        /// commented by Ramya Guduru
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Response</returns>
        public async Task<Response<IEnumerable<GetReportsLeadListQueryVm>>> Handle(GetReportsLeadListQuery request, CancellationToken cancellationToken)
        {
            
            var leadList = await _reportsLeadListRepository.GetReportsLeadList(request.Lg_Id, request.Branch_Id);

            var reportsLeadList = _mapper.Map<IEnumerable<GetReportsLeadListQueryVm>>(leadList);

            return new Response<IEnumerable<GetReportsLeadListQueryVm>>(reportsLeadList, "success Message");
            
        }
        #endregion
    }
}
