using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.QueryHistory.Queries
{
    public class GetQueryHistoryQueryHandler : IRequestHandler<GetQueryHistoryQuery, Response<List<GetQueryHistoryDto>>>
    {
        private readonly IQueryHistoryRepository _queryHistoryRepository;
        private readonly IMapper _mapper;
        public GetQueryHistoryQueryHandler(IQueryHistoryRepository queryHistoryRepository, IMapper mapper)
        {
            _queryHistoryRepository = queryHistoryRepository;
            _mapper = mapper;
        }

        #region This method will call repository method by - Pratiksha Poshe - 03/12/2021
        /// <summary>
        /// 03/12/2021 - This method will call repository method
        //	commented by Pratiksha Poshe
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>Response</returns>
        public async Task<Response<List<GetQueryHistoryDto>>> Handle(GetQueryHistoryQuery request, CancellationToken cancellationToken)
        {
            var leadQuery = await _queryHistoryRepository.GetQueryHistoryByLeadId(request.lead_Id);
            var mappedLeadQuery = _mapper.Map<List<GetQueryHistoryDto>>(leadQuery);
            return new Response<List<GetQueryHistoryDto>>(mappedLeadQuery, "success");
        } 
        #endregion
    }
}
