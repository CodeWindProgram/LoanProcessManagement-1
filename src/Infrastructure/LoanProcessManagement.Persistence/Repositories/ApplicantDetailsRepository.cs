using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.ApplicantDetails.Command;
using LoanProcessManagement.Application.Features.ApplicantDetails.Queries.AddApplicantDetails;
using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.Persistence.Repositories
{
    public class ApplicantDetailsRepository : IApplicantDetailsRepository
    {
        private readonly ILogger<ApplicantDetailsRepository> _logger;
        private readonly ApplicationDbContext _dbContext;
        public ApplicantDetailsRepository(ILogger<ApplicantDetailsRepository> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        #region This method will get applicant from db - Pratiksha Poshe - 22/11/2021
        /// <summary>
        /// 22/11/2021 - This method will get applicant from db 
        /// commented by Pratiksha
        /// <summary>
        /// </summary>
        /// <param name="lead_id"></param>
        /// <param name="ApplicantType"></param>
        /// <returns>response</returns>
        public async Task<GetApplicantDetailsByIdDto> GetLeadApplicantDetailsAsync(long lead_id, int ApplicantType)
        {
            var lead = await _dbContext.LpmLeadMasters.Include(x => x.Product).Include(x => x.LeadStatus).Include(z => z.Branch)
                .Where(x => x.Id == lead_id).FirstOrDefaultAsync();
            var applicant = await _dbContext.LpmLeadApplicantsDetails.Include(x => x.LpmLeadMaster)
                .Where(x => x.lead_Id == lead_id && x.ApplicantType == ApplicantType).FirstOrDefaultAsync();
            GetApplicantDetailsByIdDto response = new GetApplicantDetailsByIdDto();



            if (applicant != null)
            {
                response.lead_Id = applicant.lead_Id;
                response.FirstName = applicant.FirstName;
                response.MiddleName = applicant.MiddleName;
                response.LastName = applicant.LastName;
                //response.FormNo = applicant.FormNo;
                response.FormNo = lead.FormNo;
                response.ApplicantType = applicant.ApplicantType;
                response.AadharId = applicant.AadharId;
                response.AddressLine1 = applicant.AddressLine1;
                response.AddressLine2 = applicant.AddressLine2;
                response.AddressLine3 = applicant.AddressLine3;
                response.City = applicant.City;
                response.CustomerEmail = applicant.CustomerEmail;
                response.CustomerPhone = applicant.CustomerPhone;
                response.DateOfBirth = applicant.DateOfBirth;
                response.EmploymentType = applicant.EmploymentType;
                response.Gender = applicant.Gender;
                response.GstNo = applicant.GstNo;
                response.DrivingLiscenceNo = applicant.DrivingLiscenceNo;
                response.PanCardNo = applicant.PanCardNo;
                response.PassportNo = applicant.PassportNo;
                response.RationCardNo = applicant.RationCardNo;
                response.VoterId = applicant.VoterId;
                response.Pincode = applicant.Pincode;
                response.State = applicant.State;
                response.NoOfBankAccounts = applicant.NoOfBankAccounts;
                response.LeadID = lead.lead_Id;
                return response;
            }
            else
            {
                response.FormNo = lead.FormNo;
                response.LeadID = lead.lead_Id;
                //response.Succeeded = false;
                //response.Message = $"Co-Applicant{ApplicantType} does not exist";
                return response;
            }

        }

        #endregion

        #region  This method will add applicant - Pratiksha Poshe - 22/11/2021
        /// <summary>
        /// 22/11/2021 - This method will add applicant
        /// commented by Pratiksha
        /// </summary>
        /// <param name="request"></param>
        /// <returns>response</returns>
        public async Task<AddApplicantDetailsDto> UpdateApplicantDetailsByLeadId(LpmLeadApplicantsDetails request)
        {

            var applicant = await _dbContext.LpmLeadApplicantsDetails.Include(x => x.LpmLeadMaster)
                .Where(x => x.lead_Id == request.lead_Id && x.ApplicantType == request.ApplicantType).FirstOrDefaultAsync();

            AddApplicantDetailsDto response = new AddApplicantDetailsDto();

            if (applicant != null)
            {
                applicant.lead_Id = request.lead_Id;
                applicant.FormNo = request.FormNo;
                applicant.FirstName = request.FirstName;
                applicant.MiddleName = request.MiddleName;
                applicant.LastName = request.LastName;
                applicant.DateOfBirth = request.DateOfBirth;
                applicant.AddressLine1 = request.AddressLine1;
                applicant.AddressLine2 = request.AddressLine2;
                applicant.AddressLine3 = request.AddressLine3;
                applicant.City = request.City;
                applicant.State = request.State;
                applicant.Pincode = request.Pincode;
                applicant.PanCardNo = request.PanCardNo;
                applicant.PassportNo = request.PassportNo;
                applicant.RationCardNo = request.RationCardNo;
                applicant.NoOfBankAccounts = request.NoOfBankAccounts;
                applicant.AadharId = request.AadharId;
                applicant.VoterId = request.VoterId;
                applicant.Gender = request.Gender;
                applicant.CustomerEmail = request.CustomerEmail;
                applicant.GstNo = request.GstNo;
                applicant.EmploymentType = request.EmploymentType;
                applicant.ApplicantType = request.ApplicantType;
                applicant.AadharId = request.AadharId;
                applicant.DrivingLiscenceNo = request.DrivingLiscenceNo;
                applicant.CustomerPhone = request.CustomerPhone;
                //applicant.IsActive = request.IsActive;
                applicant.IsActive = true;
                applicant.CreatedBy = request.CreatedBy;
                applicant.LastModifiedBy = request.LastModifiedBy;
                
                await _dbContext.SaveChangesAsync();

                response.Message = "Applicant details Updated Successfully";
                response.Succeeded = true;

                return response;

            }
            else
            {
                LpmLeadApplicantsDetails applicantsDetails = new LpmLeadApplicantsDetails();

                applicantsDetails.lead_Id = request.lead_Id;
                applicantsDetails.FormNo = request.FormNo;
                applicantsDetails.AadharId = request.AadharId;
                applicantsDetails.FirstName = request.FirstName;
                applicantsDetails.MiddleName = request.MiddleName;
                applicantsDetails.LastName = request.LastName;
                applicantsDetails.AddressLine1 = request.AddressLine1;
                applicantsDetails.AddressLine2 = request.AddressLine2;
                applicantsDetails.AddressLine3 = request.AddressLine3;
                applicantsDetails.ApplicantType = request.ApplicantType;
                applicantsDetails.City = request.City;
                applicantsDetails.CustomerEmail = request.CustomerEmail;
                applicantsDetails.CustomerPhone = request.CustomerPhone;
                applicantsDetails.DateOfBirth = request.DateOfBirth;
                applicantsDetails.DrivingLiscenceNo = request.DrivingLiscenceNo;
                applicantsDetails.EmploymentType = request.EmploymentType;
                applicantsDetails.PanCardNo = request.PanCardNo;
                applicantsDetails.PassportNo = request.PassportNo;
                applicantsDetails.Pincode = request.Pincode;
                applicantsDetails.RationCardNo = request.RationCardNo;
                applicantsDetails.VoterId = request.VoterId;
                applicantsDetails.NoOfBankAccounts = request.NoOfBankAccounts;
                applicantsDetails.Gender = request.Gender;
                applicantsDetails.CreatedBy = request.CreatedBy;
                applicantsDetails.LastModifiedBy = request.LastModifiedBy;

                await _dbContext.LpmLeadApplicantsDetails.AddAsync(applicantsDetails);
                await _dbContext.SaveChangesAsync();

                response.Message = "New Applicant Added Sucessfully .";
                response.Succeeded = true;

                return response;
            }

        } 
        #endregion
    }
}
