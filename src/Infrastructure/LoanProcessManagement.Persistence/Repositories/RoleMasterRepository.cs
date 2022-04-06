using LoanProcessManagement.Application.Contracts.Infrastructure;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.RoleMaster.Commands.UpdateRoleMaster;
using LoanProcessManagement.Application.Features.RoleMaster.Queries.GetRoleMaster;
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
            var userDetails = await _dbContext.LpmUserRoleMasters.Where(x => x.Rolename == RoleName).FirstOrDefaultAsync();
            _logger.LogInformation("GetByRoleName With Events completed");
        }
        public async Task<LpmUserRoleMaster> GetRoleMasterByIdAsync(long id)
        {
            return await _dbContext.LpmUserRoleMasters.FirstOrDefaultAsync(p => p.Id == id);
        }
        
        public async Task<UpdateRoleMasterDto> UpdateRoleMaster(long id,UpdateRoleMasterCommand request)
        {
            UpdateRoleMasterDto response = new UpdateRoleMasterDto();
            _logger.LogInformation("UpdateRoleMaster With Events Initiated");
            var userDetails = await _dbContext.LpmUserRoleMasters.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (userDetails!=null) {
                userDetails.Rolename = request.RoleName;
                userDetails.CreatedDate = DateTime.Now;
                userDetails.IsActive = request.IsActive;
                _dbContext.SaveChanges();
                response.Message = "Menu details Updated Successfully";
                response.Succeeded = true;
                response.Id = userDetails.Id;
                return response;
            }
            else
            {
                response.Message = "Menu doesn't exists .";
                response.Succeeded = false;
                response.Id = id;
                return response;
            }
            
        }
        #endregion
    }
}
