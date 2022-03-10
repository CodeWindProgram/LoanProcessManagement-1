using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface ILpmInstitutionMastersRepository
    {
        Task<IEnumerable<LpmLeadInstitutionMaster>> GetAllInstitutionMasters();
    }
}
