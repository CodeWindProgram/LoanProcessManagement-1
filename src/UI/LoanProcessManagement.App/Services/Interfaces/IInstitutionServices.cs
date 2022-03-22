using LoanProcessManagement.Application.Features.InstitutionMasters.Commands.CreateInstitutionMasters;
using LoanProcessManagement.Application.Features.InstitutionMasters.Commands.DeleteInstitutionMasters;
using LoanProcessManagement.Application.Features.InstitutionMasters.Commands.UpdateInstitutionMasters;
using LoanProcessManagement.Application.Features.InstitutionMasters.Queries.GetInstitutionMasters;
using LoanProcessManagement.Application.Features.InstitutionMasters.Queries.GetInstitutionMastersById;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface IInstitutionServices
    {
        Task<Response<IEnumerable<GetInstitutionMastersQueryDto>>> GetAllInstitutions();
        Task<Response<InstitutionMastersDto>> CreateInstitutionMastersCommand(CreateInstitutionMastersCommand request);
        Task<Response<DeleteInstitutionMastersDto>> DeleteInstitutionMasters(long id);
        Task<Response<UpdateInstitutionMastersDto>> UpdateInstitutionMasters(UpdateInstitutionMastersCommand req);
        Task<Response<GetInstitutionMastersByIdQueryVm>> GetInstitutionMastersById(long id);
    }
}
