using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Queries.UnlockedAndLockedUsers
{
    public class GetAllUsersQuery : IRequest<Response<IEnumerable<GetAllUsersQueryVm>>>
    {
        //public GetAllUsersQuery(string lead_Id)
        //{
        //    Lead_Id = lead_Id;
        //}
        //public string Lead_Id { get; set; }
    }
}
