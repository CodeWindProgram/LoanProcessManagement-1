using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Agency.Queries.GetAgencyById
{
    public class GetAgencyByIdQuery : IRequest<Response<GetAgencyByIdQueryVm>>
    {
        public GetAgencyByIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
