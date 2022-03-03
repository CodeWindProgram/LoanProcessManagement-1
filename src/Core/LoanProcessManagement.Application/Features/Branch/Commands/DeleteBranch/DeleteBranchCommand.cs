using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Branch.Commands.DeleteBranch
{
    public class DeleteBranchCommand : IRequest<Response<DeleteBranchDto>>
    {
        public long Id { get; set; }
        public DeleteBranchCommand(long id)
        {
            this.Id = id;
        }

    }
}
