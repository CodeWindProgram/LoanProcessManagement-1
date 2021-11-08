using LoanProcessManagement.Application.Contracts.Infrastructure;
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
        private readonly IEmailService _emailService;
        public MenuRepository(ApplicationDbContext dbContext, ILogger<LpmMenuMaster> logger,IEmailService emailService) : base(dbContext, logger,emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        public async Task<List<LpmMenuMaster>> GetMenuMasterService(long userroleid)
        {
            //return await _dbContext.LpmMenuMasters.Where(m => m.Id== id).ToListAsync();
            var result = await (from A in _dbContext.LpmUserRoleMenuMaps
                                join B in _dbContext.LpmMenuMasters on A.MenuId equals B.Id
                                where A.UserRoleId == userroleid && A.IsActive == true
                                orderby B.Position
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

