using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Agency.Queries.GetAllAgency
{
    public class GetAllAgencyQuery : IRequest<Response<GetAllAgencyDto>>
    {
    }
}
