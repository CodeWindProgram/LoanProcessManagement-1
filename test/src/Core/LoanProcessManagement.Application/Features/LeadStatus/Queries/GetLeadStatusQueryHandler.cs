using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.LeadStatus.Queries
{
    public class GetLeadStatusQueryHandler : IRequestHandler<GetLeadStatusQuery, Response<IEnumerable<GetLeadStatusDto>>>
    {
        private readonly ILeadStatusRepository _leadStatusRepository;
        private readonly IMapper _mapper;
        public GetLeadStatusQueryHandler(IMapper mapper, ILeadStatusRepository leadStatusRepository)
        {
            _mapper = mapper;
            _leadStatusRepository = leadStatusRepository;
        }
        #region This method will call repository method by - Akshay Pawar - 18/11/2021
        /// <summary>
        /// 18/11/2021 - This method will call repository method
        //	commented by Akshay
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>Response</returns>
        public async Task<Response<IEnumerable<GetLeadStatusDto>>> Handle(GetLeadStatusQuery request, CancellationToken cancellationToken)
        {
            var leadStatus = await _leadStatusRepository.GetLeadStatus(request.Role);
            var mappedLeadStatus = _mapper.Map<IEnumerable<GetLeadStatusDto>>(leadStatus);
            return new Response<IEnumerable<GetLeadStatusDto>>(mappedLeadStatus, "success");
        } 
        #endregion
    }
}
