using LoanProcessManagement.Application.Features.InstitutionMasters.Commands.CreateInstitutionMasters;
using LoanProcessManagement.Application.Features.InstitutionMasters.Commands.DeleteInstitutionMasters;
using LoanProcessManagement.Application.Features.InstitutionMasters.Commands.UpdateInstitutionMasters;
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
        Task<InstitutionMastersDto> CreateInstitutionMastersCommand(LpmLeadInstitutionMaster request);
        Task<DeleteInstitutionMastersDto> DeleteInstitutionMasters(long id);
        Task<UpdateInstitutionMastersDto> UpdateInstitutionMasters(LpmLeadInstitutionMaster req);
        Task<LpmLeadInstitutionMaster> GetInstitutionMastersByIdAsync(long id);
    }
}
