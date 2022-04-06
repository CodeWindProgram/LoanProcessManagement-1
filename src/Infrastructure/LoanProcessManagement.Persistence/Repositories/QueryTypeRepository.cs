using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.QueryType.Commands.CreateQuery;
using LoanProcessManagement.Application.Features.QueryType.Commands.DeleteQuery;
using LoanProcessManagement.Application.Features.QueryType.Commands.UpdateQuery;
using LoanProcessManagement.Application.Features.QueryType.Queries.GetQueryTypeById;
using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Persistence.Repositories
{
    public class QueryTypeRepository : IQueryTypeRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        public QueryTypeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CreateQueryCommandDto> CreateQueryType(LpmQueryTypeMaster request)
        {
            CreateQueryCommandDto res = new CreateQueryCommandDto();

            var result=await _dbContext.LpmQueryTypeMasters.FirstOrDefaultAsync(x => x.QueryName == request.QueryName && x.QueryType==request.QueryType);
            if (result != null)
            {
                res.Message = "Query already exists.";
                res.Succeeded = false;
                return res;

            }
            else
            {
                request.IsActive = true;
                await _dbContext.LpmQueryTypeMasters.AddAsync(request);
                await _dbContext.SaveChangesAsync();
                res.Message = "Query Added Successfully.";
                res.Succeeded = true;
                return res;
            }
        }

        public async Task<DeleteQueryDto> DeleteQueryType(long id)
        {
            DeleteQueryDto res = new DeleteQueryDto();
            var result = await _dbContext.LpmQueryTypeMasters.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                result.IsActive = false;
                await _dbContext.SaveChangesAsync();
                res.Message = "Query removed successfully.";
                res.Succeeded = true;

            }
            else
            {
                res.Message = "Invalid Id.";
                res.Succeeded = false;
            }
            return res;
        }

        public async Task<IEnumerable<LpmQueryTypeMaster>> GetAllQueryType()
        {
            return await _dbContext.LpmQueryTypeMasters.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<LpmQueryTypeMaster> GetQueryTypeById(long id)
        {
            return await _dbContext.LpmQueryTypeMasters.FirstOrDefaultAsync(x => x.Id==id);
        }

        public async Task<UpdateQueryCommandDto> UpdateQuery(UpdateQueryCommand req)
        {
            UpdateQueryCommandDto response = new UpdateQueryCommandDto();
            var result = await _dbContext.LpmQueryTypeMasters.FirstOrDefaultAsync(x => x.QueryName==req.QueryName && x.QueryType==req.QueryType
            &&  x.Id != req.Id);
            if (result != null)
            {
                response.Message = "Query already exists.";
                response.Succeeded = false;
                return response;

            }
            var branchToUpdate = await _dbContext.LpmQueryTypeMasters.FirstOrDefaultAsync(x => x.Id == req.Id);

            if (branchToUpdate != null)
            {
                branchToUpdate.QueryType = req.QueryType;
                branchToUpdate.QueryName = req.QueryName;
                branchToUpdate.IsActive = req.IsActive;
                await _dbContext.SaveChangesAsync();
                response.Message = "Query details updated successfully.";
                response.Succeeded = true;
                return response;

            }
            else
            {
                response.Message = "Invalid Id.";
                response.Succeeded = true;
                return response;
            }

        }
    }
}
