using LoanProcessManagement.Application.Contracts.Infrastructure;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.LostLeadMaster.Commands.UpdateLostLeadReasonMaster;
using LoanProcessManagement.Application.Features.LostLeadMaster.Queries.GetLostLeadMasterbyId;
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
    public class LostLeadReasonMasterRepository : BaseRepository<LpmLostLeadReasonMaster>, ILostLeadReasonMasterRepository
    {
        private readonly ILogger _logger;
        private readonly IEmailService _emailService;

        public LostLeadReasonMasterRepository(ApplicationDbContext dbContext, ILogger<LpmLostLeadReasonMaster> logger, IEmailService emailService) : base(dbContext, logger, emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }
        public async Task GetByLostLeadReason(string LostLead)
        {
            _logger.LogInformation("GetByLostLeadReason With Events Initiated");
            await _dbContext.LpmLostLeadReasonMasters.Where(x => x.LostLeadReason == LostLead).FirstOrDefaultAsync();
            _logger.LogInformation("GetByLostLeadReason With Events completed");
        }
        public async Task<LpmLostLeadReasonMaster> GetLostLeadReasonMasterByIdAsync(long id)
        {
            return await _dbContext.LpmLostLeadReasonMasters.FirstOrDefaultAsync(p => p.LostLeadReasonID == id);
        }
        public async Task<UpdateLostLeadReasonMasterDto> UpdateLostLeadReasonMaster(long id, UpdateLostLeadReasonMasterCommand request)
        {
            UpdateLostLeadReasonMasterDto response = new UpdateLostLeadReasonMasterDto();
            _logger.LogInformation("UpdateRoleMaster With Events Initiated");
            var userDetails = await _dbContext.LpmLostLeadReasonMasters.Where(x => x.LostLeadReasonID == id).FirstOrDefaultAsync();
            if (userDetails != null)
            {
                userDetails.IsActive = request.IsActive;
                userDetails.LostLeadReason = request.LostLeadReason;
                userDetails.CreatedDate = DateTime.Now;
                _dbContext.SaveChanges();
                response.Message = "Lost Lead Reason  Updated Successfully";
                response.Succeeded = true;
                response.LostLeadReasonId = userDetails.LostLeadReasonID;
                return response;
            }
            else
            {
                response.Message = "Lost Lead Reason doesn't exists .";
                response.Succeeded = false;
                response.LostLeadReasonId = id;
                return response;
            }
        }
    }
}
