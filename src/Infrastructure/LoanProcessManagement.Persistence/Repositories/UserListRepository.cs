using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Domain.CustomModels;
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
    public class UserListRepository : BaseRepository<IEnumerable<UserMasterListModel>>, IUserListRepository
    {
        private readonly ILogger _logger;
        public UserListRepository(ApplicationDbContext dbContext, ILogger<IEnumerable<UserMasterListModel>> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        #region Get All User List - Saif Khan - 30/10/2021
        /// <summary>
        /// 2021/10/30 -  Get All User List API Call
        /// Commented By Saif Khan
        /// </summary>
        /// <returns>UserListResponse</returns>
        public async Task<IEnumerable<UserMasterListModel>> GetUserList()
        {
            var result = await (from A in _dbContext.LpmUserMasters
                                join B in _dbContext.LpmBranchMasters on A.BranchId equals B.Id
                                where A.IsActive == true
                                select new UserMasterListModel
                                {
                                    Id = A.Id,
                                    BranchId = A.BranchId,
                                    LgId = A.LgId,
                                    EmployeeId = A.EmployeeId,
                                    Name = A.Name,
                                    Email = A.Email,
                                    BranchName = B.branchname,
                                    PhoneNumber = A.PhoneNumber,
                                    StaffType = A.StaffType,
                                    IsActive = A.IsActive
                                }).ToListAsync();
            return result;
        }
        #endregion
    }
}
