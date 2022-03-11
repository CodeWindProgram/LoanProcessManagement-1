using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.SchemeMaster.Queries.GetSchemeById
{
    public class GetSchemeById : IRequest<Response<GetSchemeByIdDto>>
    {
        public GetSchemeById(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
