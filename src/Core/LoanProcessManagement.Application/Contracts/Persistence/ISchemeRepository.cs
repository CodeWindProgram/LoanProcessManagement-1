using LoanProcessManagement.Application.Features.SchemeMaster.Commands.CreateScheme;
using LoanProcessManagement.Application.Features.SchemeMaster.Commands.DeleteScheme;
using LoanProcessManagement.Application.Features.SchemeMaster.Commands.UpdateScheme;
using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface ISchemeRepository
    {
        Task<IEnumerable<LpmLoanSchemeMaster>> GetAllScheme();
        Task<LpmLoanSchemeMaster> GetSchemeById(long id);
        Task<CreateSchemeCommandDto> CreateScheme(LpmLoanSchemeMaster request);
        Task<DeleteSchemeDto> DeleteScheme(long id);
        Task<UpdateSchemeCommandDto> UpdateScheme(UpdateSchemeCommand req);


    }
}
