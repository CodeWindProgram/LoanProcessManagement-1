using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.CustomModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.LeadList.Commands
{
    public class LeadListCommandHandler : IRequestHandler<LeadListCommand, Response<LeadListCommandDto>>
    {
        private readonly ILeadListRepository _leadListRepository;
        private readonly IMapper _mapper;
        public LeadListCommandHandler(IMapper mapper,ILeadListRepository leadListRepository)
        {
            _mapper = mapper;
            _leadListRepository = leadListRepository;
        }

        public async Task<Response<LeadListCommandDto>> Handle(LeadListCommand request, CancellationToken cancellationToken)
        {
            var  LeadListCommandResponse = new Response<LeadListCommandDto>();
            //var timepass = await _leadListRepository.GetAllLeadList();

            var LeadListing = new LeadListCommandDto()
            {
                LgId = request.LgId,
                UserRoleId = request.UserRoleId,
                BranchId = request.BranchId
            };
            return LeadListCommandResponse;
        }
    }
}
