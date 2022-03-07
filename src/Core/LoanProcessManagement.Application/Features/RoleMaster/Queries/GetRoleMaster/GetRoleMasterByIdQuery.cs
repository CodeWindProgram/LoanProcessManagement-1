using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.RoleMaster.Queries.GetRoleMaster
{
    public class GetRoleMasterByIdQuery : IRequest<GetRoleMasterByIdDto>
    {       
        public long id { get; set; }
    } 
}   