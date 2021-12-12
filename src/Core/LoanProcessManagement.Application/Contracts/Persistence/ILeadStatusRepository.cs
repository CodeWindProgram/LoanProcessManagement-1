using LoanProcessManagement.Application.Features.LeadStatus.Queries;
using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface ILeadStatusRepository
    {
        Task<IEnumerable<LpmLeadStatusMaster>> GetLeadStatus(string role);
        Task<GetLeadStatusCountDto> GetLeadStatusCount(GetLeadStatusCountQuery req);

        

    }
}
