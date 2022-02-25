using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.ChangePassword.Queries
{
    public class VerifyOldPasswordQueryHandler : IRequestHandler<VerifyOldPasswordQuery, bool>
    {
        private readonly IChangePasswordRepository _changePasswordRepository;
        private readonly IMapper _mapper;
        public VerifyOldPasswordQueryHandler(IChangePasswordRepository changePasswordRepository, IMapper mapper)
        {
            _changePasswordRepository = changePasswordRepository;
            _mapper = mapper;
        }

        public Task<bool> Handle(VerifyOldPasswordQuery request, CancellationToken cancellationToken)
        {
            var result = _changePasswordRepository.VerifyOldPassword(request.OldPassword, request.LgId);
            return result;
        }
    }
}
