using LoanProcessManagement.Domain.CustomModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface ILeadListRepository 
    {
        Task<IEnumerable<LeadListModel>> GetAllLeadList(string LgId);
    }
}
