using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.Persistence.Repositories
{
    public class MenuRepository : BaseRepository<LpmMenuMaster> ,IMenuRepository
    {
        private readonly ILogger _logger;
        public MenuRepository(ApplicationDbContext dbContext, ILogger<LpmMenuMaster> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<LpmMenuMaster>> GetMenuMasterService(long userroleid)
        {
            //return await _dbContext.LpmMenuMasters.Where(m => m.Id== id).ToListAsync();
            var result = await (from A in _dbContext.LpmUserRoleMenuMaps
                          join B in _dbContext.LpmMenuMasters on A.MenuId equals B.Id
                          where A.UserRoleId == userroleid && A.IsActive == true
                          select new LpmMenuMaster
                          {
                              Position =  B.Position,
                              Icon = B.Icon,
                              Link = B.Link,
                              MenuName = B.MenuName,
                          }).ToListAsync();
            return result;
        }
    }
}

