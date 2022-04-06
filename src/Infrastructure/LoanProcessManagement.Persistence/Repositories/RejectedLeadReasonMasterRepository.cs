using LoanProcessManagement.Application.Contracts.Infrastructure;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.RejectedLeadMaster.Commands.UpdateRejectLeadReasonMaster;
using LoanProcessManagement.Application.Features.RejectedLeadMaster.Queries.GetRejectedLeadMasterbyId;
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
    public class RejectedLeadReasonMasterRepository : BaseRepository<LpmRejectedLeadReasonMaster>, IRejectedLeadReasonMasterRepository
    {
        private readonly ILogger _logger;
        private readonly IEmailService _emailService;

        public RejectedLeadReasonMasterRepository(ApplicationDbContext dbContext, ILogger<LpmRejectedLeadReasonMaster> logger, IEmailService emailService) : base(dbContext, logger, emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }
        public async Task GetByRejectLeadReason(string LostLead)
        {
            _logger.LogInformation("GetByRejectLeadReason With Events Initiated");
            var userDetails = await _dbContext.LpmRejectedLeadReasonMasters.Where(x => x.RejectLeadReason == LostLead).FirstOrDefaultAsync();
            _logger.LogInformation("GetByRejectLeadReason With Events completed");
        }
        public async Task<LpmRejectedLeadReasonMaster> GetRejectedLeadReasonMasterByIdAsync(long id)
        {
            return await _dbContext.LpmRejectedLeadReasonMasters.FirstOrDefaultAsync(p => p.RejectLeadReasonID == id);
        }

        public async  Task<UpdateRejectLeadReasonMasterDto> UpdateRejectLeadReasonMaster(long id, UpdateRejectLeadReasonMasterCommand request)
        {
            UpdateRejectLeadReasonMasterDto response = new UpdateRejectLeadReasonMasterDto();
            _logger.LogInformation("UpdateRoleMaster With Events Initiated");
            var userDetails = await _dbContext.LpmRejectedLeadReasonMasters.Where(x => x.RejectLeadReasonID == id).FirstOrDefaultAsync();
            if (userDetails != null)
            {
                userDetails.RejectLeadReason = request.RejectLeadReason;
                userDetails.IsActive = request.IsActive;
                userDetails.CreatedDate = DateTime.Now;
                _dbContext.SaveChanges();
                response.Message = "Reject Lead Reason  Updated Successfully";
                response.Succeeded = true;
                response.RejectLeadReasonId = userDetails.RejectLeadReasonID;
                return response;
            }
            else
            {
                response.Message = "Lost Lead Reason doesn't exists .";
                response.Succeeded = false;
                response.RejectLeadReasonId= id;
                return response;
            }
        }
    }
}
