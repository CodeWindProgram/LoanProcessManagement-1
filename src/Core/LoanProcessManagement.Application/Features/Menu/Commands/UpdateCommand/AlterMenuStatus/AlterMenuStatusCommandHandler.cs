using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.Menu.Commands.UpdateCommand.AlterMenuStatus
{
    public class AlterMenuStatusCommandHandler : IRequestHandler<AlterMenuStatusCommand, AlterMenuStatusCommandDTO>
    {
        private readonly IMenuRepository _menuRepository;

        public AlterMenuStatusCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        public async Task<AlterMenuStatusCommandDTO> Handle(AlterMenuStatusCommand request, CancellationToken cancellationToken)
        {
            var response = await _menuRepository.AlterStatus(request.Id, request.LgId);
            return response;
        }
    }
}
