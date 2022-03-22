using LoanProcessManagement.Application.Features.QueryType.Commands.CreateQuery;
using LoanProcessManagement.Application.Features.QueryType.Commands.DeleteQuery;
using LoanProcessManagement.Application.Features.QueryType.Commands.UpdateQuery;
using LoanProcessManagement.Application.Features.QueryType.Queries.GetQueryType;
using LoanProcessManagement.Application.Features.QueryType.Queries.GetQueryTypeById;
using LoanProcessManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface IQueryTypeService
    {
        Task<Response<IEnumerable<GetAllQueryTypeQueryDto>>> GetAllQueryTypes();
        Task<Response<CreateQueryCommandDto>> AddQueryType(CreateQueryCommand req);
        Task<Response<DeleteQueryDto>> DeleteQueryType(long id);
        Task<Response<GetQueryTypeByIdQueryDto>> GetQueryTypeById(long id);
        Task<Response<UpdateQueryCommandDto>> UpdateQuery(UpdateQueryCommand req);

    }
}
