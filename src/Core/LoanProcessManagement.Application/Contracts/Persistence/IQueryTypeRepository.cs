using LoanProcessManagement.Application.Features.QueryType.Commands.CreateQuery;
using LoanProcessManagement.Application.Features.QueryType.Commands.DeleteQuery;
using LoanProcessManagement.Application.Features.QueryType.Commands.UpdateQuery;
using LoanProcessManagement.Application.Features.QueryType.Queries.GetQueryTypeById;
using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface IQueryTypeRepository
    {
        Task<IEnumerable<LpmQueryTypeMaster>> GetAllQueryType();
        Task<LpmQueryTypeMaster> GetQueryTypeById(long id);

        Task<CreateQueryCommandDto> CreateQueryType(LpmQueryTypeMaster request);
        Task<DeleteQueryDto> DeleteQueryType(long id);
        Task<UpdateQueryCommandDto> UpdateQuery(UpdateQueryCommand req);

    }
}
