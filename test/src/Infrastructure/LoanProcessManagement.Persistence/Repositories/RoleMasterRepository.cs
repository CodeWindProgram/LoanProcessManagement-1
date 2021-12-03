using LoanProcessManagement.Application.Contracts.Infrastructure;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Domain.CustomModels;
using LoanProcessManagement.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Persistence.Repositories
{
    public class RoleMasterRepository : BaseRepository<LpmUserRoleMaster>, IRoleMasterRepository
    {

        private readonly ILogger _logger;
        private readonly IEmailService _emailService;

        public RoleMasterRepository(ApplicationDbContext dbContext, ILogger<LpmUserRoleMaster> logger, IEmailService emailService) : base(dbContext, logger, emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        #region This method will send response to IRoleMasterRepository methods. by - Ramya Guduru - 10/11/2021
        /// <summary>
        /// 10/11/2021 - This method will send response to RoleMasterRepository
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="RoleMasterRepository">RoleMasterRepository</param>
        /// <returns>RoleMasterRepository</returns>

        public async Task GetByRoleName(string RoleName)
        {
            _logger.LogInformation("GetByRoleName With Events Initiated");
            var userDetails = _dbContext.LpmUserRoleMasters.Where(x => x.Rolename == RoleName).FirstOrDefault();
            _logger.LogInformation("GetByRoleName With Events completed");
        }

        public async Task UpdateRoleMaster(LpmUserRoleMaster lpmUserRoleMaster)
        {
            _logger.LogInformation("UpdateRoleMaster With Events Initiated");
            var userDetails = _dbContext.LpmUserRoleMasters.Where(x => x.Id == lpmUserRoleMaster.Id).FirstOrDefault();
            if (userDetails!=null) {
                userDetails.Rolename = lpmUserRoleMaster.Rolename;
                userDetails.CreatedDate = DateTime.Now;
                _dbContext.SaveChanges();
            }
            _logger.LogInformation("UpdateRoleMaster With Events completed");
            //return userDetails;
        }

        //public Task GetByName(string roleName)
        //{
        //    var userDetails = _dbContext.LpmUserRoleMasters.Where(x => x.Rolename == roleName).FirstOrDefault();
        //    return userDetails; 
        //}
        #endregion
    }
}
