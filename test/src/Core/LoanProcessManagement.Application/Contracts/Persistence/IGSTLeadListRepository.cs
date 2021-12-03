using LoanProcessManagement.Domain.CustomModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface IGSTLeadListRepository : IAsyncRepository<IEnumerable<GSTLeadListModel>>
    {
        Task<IEnumerable<GSTLeadListModel>> GetGSTLeadList(long BranchID);
    }
}
