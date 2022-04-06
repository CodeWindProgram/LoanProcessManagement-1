using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.LeadList.Commands.UpdateLead
{
    class UpdateLeadCommandHandler : IRequestHandler<UpdateLeadCommand, Response<UpdateLeadDto>>
    {
        private readonly ILeadListRepository _leadListRepository;
        public UpdateLeadCommandHandler(ILeadListRepository leadListRepository)
        {
            _leadListRepository = leadListRepository;
        }
        #region This method will call repository method by - Akshay Pawar - 18/11/2021
        /// <summary>
        /// 18/11/2021 - This method will call repository method
        //	commented by Akshay
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>Response</returns>
        public async Task<Response<UpdateLeadDto>> Handle(UpdateLeadCommand request, CancellationToken cancellationToken)
        {
            var leadDto = await _leadListRepository.ModifyLead(request);
            if (leadDto.Succeeded)
            {
                return new Response<UpdateLeadDto>(leadDto, "Success");
            }
            else
            {
                var res = new Response<UpdateLeadDto>(leadDto, "failure")
                {
                    Succeeded = false
                };
                return res;
            }
        } 
        #endregion
    }
}
