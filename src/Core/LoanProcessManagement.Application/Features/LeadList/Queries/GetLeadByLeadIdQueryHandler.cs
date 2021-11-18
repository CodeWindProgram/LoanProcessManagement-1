using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.LeadList.Queries
{
    public class GetLeadByLeadIdQueryHandler : IRequestHandler<GetLeadByLeadIdQuery, Response<GetLeadByLeadIdDto>>
    {
        private readonly ILeadListRepository _leadListRepository;
        private readonly IMapper _mapper;
        public GetLeadByLeadIdQueryHandler(IMapper mapper, ILeadListRepository leadListRepository)
        {
            _mapper = mapper;
            _leadListRepository = leadListRepository;
        }
        #region This method will call repository method by - Akshay Pawar - 18/11/2021
        /// <summary>
        /// 18/11/2021 - This method will call repository method
        //	commented by Akshay
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>Response</returns>
        public async Task<Response<GetLeadByLeadIdDto>> Handle(GetLeadByLeadIdQuery request, CancellationToken cancellationToken)
        {
            var lead = await _leadListRepository.GetLeadByLeadId(request.lead_Id);
            return new Response<GetLeadByLeadIdDto>(lead, "success");

        } 
        #endregion
    }
}
