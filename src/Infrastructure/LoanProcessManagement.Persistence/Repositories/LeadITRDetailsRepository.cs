using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.LeadITRDetails.Command;
using LoanProcessManagement.Application.Features.LeadITRDetails.Queries.LeadITRDetails;
using LoanProcessManagement.Domain.Entities;
using LoanProcessManagement.Infrastructure.EncryptDecrypt;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Persistence.Repositories
{
    public class LeadITRDetailsRepository: ILeadITRDetailsRepository
    {

        private readonly ILogger<LeadITRDetailsRepository> _logger;
        private readonly ApplicationDbContext _dbContext;
        public LeadITRDetailsRepository(ILogger<LeadITRDetailsRepository> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        #region This method will get LeadITRDetails from db - Ramya Guduru - 13/12/2021
        /// <summary>
        /// 22/11/2021 - This method will get LeadITRDetails from db 
        /// commented by Ramya
        /// <summary>
        /// </summary>
        /// <param name="lead_id"></param>
        /// <param name="ApplicantType"></param>
        /// <returns>response</returns>
        public async Task<GetLeadITRDetailsDto> GetLeadITRDetailsAsync(long lead_id, int ApplicantType)
        {
            var details =  _dbContext.LpmLeadApplicantsDetails.Where(x=>x.lead_Id == lead_id && x.ApplicantType == ApplicantType).FirstOrDefault();
            
            var lead = await _dbContext.LpmLeadMasters.Include(x => x.Product).Include(x => x.LeadStatus).Include(z => z.Branch)
                .Where(x => x.Id == lead_id).FirstOrDefaultAsync();

            GetLeadITRDetailsDto response = new GetLeadITRDetailsDto();

            if (details != null)
            {
                response.lead_Id = details.lead_Id;
                response.FormNo = details.FormNo;
                response.CustomerName = details.FirstName;
                response.CustomerPhone = details.CustomerPhone;
                response.CustomerEmail = details.CustomerEmail;
                response.EmploymentType = details.EmploymentType;
                response.Consent = true;
                response.PanCardNo = details.PanCardNo;
                response.UserName = details.PanCardNo;
                response.Message = "Data Fetched";
                response.Succeeded = true;
                return response;
            }
            else {
                response.Message = "Data null";
                response.Succeeded = false;
                response.FormNo = lead.FormNo;
                return response;
            }
            
        }
        #endregion

        #region  This method will add LeadITRDetails to db - Ramya Guduru - 14/12/2021
        /// <summary>
        /// 14/12/2021 - This method will add LeadITRDetails
        /// commented by Ramya
        /// </summary>
        /// <param name="request"></param>
        /// <returns>response</returns>
       
        public async Task<LeadITRDetailsDto> UpdateLeadITRDetails(LpmLeadITRDetails request)
        {
           
            var applicant = _dbContext.LpmLeadITRDetails.Where(x => x.FormNo == request.FormNo && x.lead_Id==request.lead_Id && x.ApplicantType==request.ApplicantType).FirstOrDefault();
            
            var encryptPassword = EncryptionDecryption.EncryptString(request.Password);

            LeadITRDetailsDto response = new LeadITRDetailsDto();

            if (applicant != null)
            {
                applicant.Password = encryptPassword;
                applicant.LastModifiedDate = DateTime.Now;
                applicant.LastModifiedBy = request.LastModifiedBy;
                applicant.CreatedBy = request.CreatedBy;

                await _dbContext.SaveChangesAsync();

                response.Message = "Password Updated Successfully";
                response.Succeeded = true;
                
            }
            else {
                response.Message = "Failed to Update Password";
                response.Succeeded = false;
            }

            return response;
        }
        #endregion
    }
}
