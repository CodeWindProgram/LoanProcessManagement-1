using LoanProcessManagement.Application.Contracts.Persistence;
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
    public class UserListRepository : BaseRepository<LpmUserMaster>, IUserListRepository
    {
        private readonly ILogger _logger;
        public UserListRepository(ApplicationDbContext dbContext, ILogger<LpmUserMaster> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
        //public async Task<LpmUserMaster> GetUserList(string LgId)
        //{
        //    return await _dbContext.LpmMenuMasters.Where(m => m.LgId== LgId).ToListAsync();
        //    var result = await (from A in _dbContext.LpmUserMasters
        //                        join B in _dbContext.LpmBranchMasters on A.LgId equals B.branchname
        //                        where A.LgId == LgId && A.IsActive == true
        //                        select new LpmUserMaster
        //                        {
        //                            LgId = A.LgId,
        //                            EmployeeId = A.EmployeeId,
        //                            Name = A.Name,
        //                            Email = A.Email,
        //                            Branch = A.Branch,
        //                            PhoneNumber = A.PhoneNumber,
        //                            StaffType = A.StaffType,
        //                        }).ToListAsync();
        //    return result;
        //}
    }
}
