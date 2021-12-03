using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.LeadList.Commands
{
    public class LeadListCommandHandler : IRequestHandler<LeadListCommand, Response<IEnumerable<LeadListCommandDto>>>
    {
        #region Handler for Lead List Command service - Saif Khan - 02/11/2021
        /// <summary>
        /// Handler for Lead List Command service - 02/11/2021
        /// Commented By - Saif Khan
        /// <return>Response<IEnumerable<LeadListCommandDto>></return>
        /// </summary>

        private readonly ILeadListRepository _leadListRepository;
        private readonly IMapper _mapper;
        public LeadListCommandHandler(IMapper mapper, ILeadListRepository leadListRepository)
        {
            _mapper = mapper;
            _leadListRepository = leadListRepository;
        }

        public async Task<Response<IEnumerable<LeadListCommandDto>>> Handle(LeadListCommand request, CancellationToken cancellationToken)
        {
            var AllLead = await _leadListRepository.GetAllLeadList();
            var response = _mapper.Map<IEnumerable<LeadListCommandDto>>(AllLead);
            return new Response<IEnumerable<LeadListCommandDto>>(response, "Inserted successfully");
        } 
        #endregion
    }
}