using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.QueryHistory.Queries;
using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LoanProcessManagement.Persistence.Repositories
{
    class QueryHistoryRepository : IQueryHistoryRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public QueryHistoryRepository(ApplicationDbContext dbContext, ILogger<QueryHistoryRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        #region This method will fetch query history from db based on leadId by - Pratiksha - 03/12/2021
        /// <summary>
        /// 10/11/2021 - This method will add new lead to the db
        /// Commented by Pratiksha
        /// </summary>
        /// <param name="lead_id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<GetQueryHistoryDto>> GetQueryHistoryByLeadId(string lead_id)
        {
            var user = await _dbContext.LpmLeadMasters.Include(x => x.Product).Include(x => x.LeadStatus).Include(z => z.Branch)
                .Where(x => x.lead_Id == lead_id).FirstOrDefaultAsync();

            var leadQuery = await _dbContext.LpmLeadQuerys.Include(x => x.lead).Where(x => x.lead_Id == user.Id)
               .OrderByDescending(x => x.Id).Select(x => new GetQueryHistoryDto()
               {
                   CreatedDate = x.CreatedDate,
                   FormNo = x.FormNo,
                   lead_Id = x.lead_Id,
                   Query_Comment = x.Query_Comment,
                   Query_Status = x.Query_Status,
                   IPSQueryType1 = x.IPSQueryType1,
                   IPSQueryType2 = x.IPSQueryType2,
                   IPSQueryType3 = x.IPSQueryType3,
                   IPSQueryType4 = x.IPSQueryType4,
                   IPSQueryType5 = x.IPSQueryType5,
                   IPSQueryType_Comment = x.IPSQueryType_Comment,
                   IPSResponseType1 = x.IPSResponseType1,
                   IPSResponseType2 = x.IPSResponseType2,
                   IPSResponseType3 = x.IPSResponseType3,
                   IPSResponseType4 = x.IPSResponseType4,
                   IPSResponseType5 = x.IPSResponseType5,
                   Tat = x.Tat,
                   Succeeded = true,
                   Message = "Query History fetched successfully"
               }
               ).ToListAsync();
            return leadQuery;
        } 
        #endregion

    }
}
