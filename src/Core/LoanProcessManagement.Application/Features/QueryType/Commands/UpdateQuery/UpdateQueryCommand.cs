using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.QueryType.Commands.UpdateQuery
{
    public class UpdateQueryCommand : IRequest<Response<UpdateQueryCommandDto>>
    {
        public long Id { get; set; }
        public Char QueryType { get; set; }
        public string QueryName { get; set; }
        public bool IsActive { get; set; }

    }
}
