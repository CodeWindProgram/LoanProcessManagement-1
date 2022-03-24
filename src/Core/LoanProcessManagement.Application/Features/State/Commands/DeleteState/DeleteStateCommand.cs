using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.State.Commands.DeleteState
{
    public class DeleteStateCommand : IRequest<Response<DeleteStateDto>>
    {
        public long Id { get; set; }
        public DeleteStateCommand(long id)
        {
            this.Id = id;
        }
    }
}
