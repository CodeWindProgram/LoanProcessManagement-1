using LoanProcessManagement.Application.Features.SchemeMaster.Commands.CreateScheme;
using LoanProcessManagement.Application.Features.SchemeMaster.Commands.DeleteScheme;
using LoanProcessManagement.Application.Features.SchemeMaster.Commands.UpdateScheme;
using LoanProcessManagement.Application.Features.SchemeMaster.Queries.GetSchemeById;
using LoanProcessManagement.Application.Features.SchemeMaster.Queries.GetSchemeList;
using LoanProcessManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface ISchemeService
    {
        Task<Response<IEnumerable<GetAllSchemeDto>>> GetAllScheme();
        Task<Response<CreateSchemeCommandDto>> AddScheme(CreateSchemeCommand req);
        Task<Response<DeleteSchemeDto>> DeleteScheme(long id);
        Task<Response<GetSchemeByIdDto>> GetSchemeById(long id);
        Task<Response<UpdateSchemeCommandDto>> UpdateScheme(UpdateSchemeCommand req);
    }
}
