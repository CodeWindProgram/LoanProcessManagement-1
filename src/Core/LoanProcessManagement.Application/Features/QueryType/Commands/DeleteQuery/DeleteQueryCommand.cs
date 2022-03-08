using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.QueryType.Commands.DeleteQuery
{
    public class DeleteQueryCommand : IRequest<Response<DeleteQueryDto>>
    {
        public long Id { get; set; }
        public DeleteQueryCommand(long id)
        {
            this.Id = id;
        }
    }
}
