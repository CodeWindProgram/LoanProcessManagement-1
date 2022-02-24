using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.CibilCheck.Commands.AddCibilCheckDetails;
using LoanProcessManagement.Application.Features.CibilCheck.Queries.ApplicantDetails;
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
    public class CibilCheckDetailsRepository : ICibilCheckDetailsRepository
    {
        private readonly ILogger<CibilCheckDetailsRepository> _logger;
        private readonly ApplicationDbContext _dbContext;
        public CibilCheckDetailsRepository(ILogger<CibilCheckDetailsRepository> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        #region This repository method will internally get and update details of cibil check applicant db table - Ramya Guduru - 16/12/2021
        /// <summary>
        ///  16/12/2021 - This action method will internally get and update details of cibil check applicant table by
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="lead_Id"></param>
        /// <param name="applicantType"></param>
        /// <returns>Index view</returns>
        public async Task<GetCibilCheckDetailsDto> GetCibilApplicantDetailsAsync(long lead_id, int ApplicantType)
        {
            
            var lead = await _dbContext.LpmLeadMasters.Include(x => x.Product).Include(x => x.LeadStatus).Include(z => z.Branch)
                .Where(x => x.Id == lead_id).FirstOrDefaultAsync();

            var applicant = await _dbContext.LpmLeadApplicantsDetails.Include(x => x.LpmLeadMaster)
                .Where(x => x.lead_Id == lead_id && x.ApplicantType == ApplicantType).FirstOrDefaultAsync();

            var details = _dbContext.LpmCibilCheckDetails.Where(x => x.ApplicantType == ApplicantType && x.lead_Id==lead_id).FirstOrDefault();
            ///*&& applicant.FormNo == x.FormNo && applicant.Id==x.ApplicantDetailId*/

            List<int> applicantTypeList = await _dbContext.LpmLeadApplicantsDetails.Where(x => x.lead_Id == lead_id).OrderBy(x => x.ApplicantType).Select(x => x.ApplicantType).ToListAsync();   //to fetch all applicant types under a particular lead 

            GetCibilCheckDetailsDto response = new GetCibilCheckDetailsDto();

            if (applicant != null)
            {
                response.lead_Id = applicant.lead_Id;
                response.CustomerName = applicant.FirstName;
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
                response.DrivingLiscenceNo = applicant.DrivingLiscenceNo;
                response.PanCardNo = applicant.PanCardNo;
                response.PassportNo = applicant.PassportNo;
                response.RationCardNo = applicant.RationCardNo;
                response.VoterId = applicant.VoterId;
                response.Pincode = applicant.Pincode;
                response.State = applicant.State;
                response.LeadID = lead.lead_Id;
                response.AppTypeList = applicantTypeList;
                if (details != null)
                {
                    response.IsSubmit = details.IsSubmit;
                    response.PhoneNumber1 = details.PhoneNumber1;
                    response.PhoneNumber2 = details.PhoneNumber2;
                    response.Category = details.Category;
                    response.Qualification = details.Qualification;
                    response.Residence = details.Residence;
                }
                
                response.Message = "data fetched";
                response.Succeeded = true;
                return response;
            }
            else
            {
                response.IsSubmit = false;
                response.FormNo = lead.FormNo;
                response.LeadID = lead.lead_Id;
                response.Succeeded = false;
                response.Message = "data not fetched";
                return response;
            }

        }

        //public async Task<AddCibilDetailsDto> UpdateApplicantDetailsByLeadId(LpmCibilCheckDetails request)
        public async Task<CibilCheckDetailsModel> UpdateApplicantDetailsByLeadId(CibilCheckDetailsModel request)
        {
            var applicant = _dbContext.LpmCibilCheckDetails.Where(x => x.FormNo == request.FormNo && x.lead_Id == request.lead_Id && x.ApplicantType == request.ApplicantType).FirstOrDefault();

           // var applicantDetails = _dbContext.LpmLeadApplicantsDetails.Where(x=>x.FormNo==request.FormNo && x.lead_Id==request.lead_Id && x.ApplicantType==request.ApplicantType).FirstOrDefault();

            var applicantDetails = await _dbContext.LpmLeadApplicantsDetails.Include(x => x.LpmLeadMaster)
                .Where(x => x.lead_Id == request.lead_Id && x.ApplicantType == request.ApplicantType).FirstOrDefaultAsync();


            AddCibilDetailsDto response = new AddCibilDetailsDto();

            if (applicant != null)
            {
                applicant.lead_Id = request.lead_Id;
                applicant.FormNo = request.FormNo;
                applicant.PhoneNumber1 = request.PhoneNumber1;
                applicant.PhoneNumber2 = request.PhoneNumber2;
                applicant.Category = request.Category;
                applicant.Residence = request.Residence;
                applicant.Qualification = request.Qualification;
                applicant.IsSuccess = true;
                applicant.IsSubmit = true;
                applicant.IsActive = true;

                applicant.CreatedBy = request.CreatedBy;
                applicant.LastModifiedBy = request.LastModifiedBy;
                applicant.LastModifiedDate = DateTime.Now;

                applicantDetails.AddressLine1 = request.AddressLine1;
                applicantDetails.AddressLine2 = request.AddressLine2;
                applicantDetails.AddressLine3 = request.AddressLine3;
                applicantDetails.State = request.State;
                applicantDetails.Pincode = request.Pincode;
                applicantDetails.City = request.City;
                applicantDetails.LastModifiedDate = DateTime.Now;

                await _dbContext.SaveChangesAsync();

                request.Message = "Cibil Enquiry Added Successfully";
                request.Succeeded = true;

                return request;

            } else {

                LpmCibilCheckDetails details = new LpmCibilCheckDetails();
                
                details.LastModifiedDate = DateTime.Now;
                details.LastModifiedBy = request.LastModifiedBy;
                details.CreatedBy = request.CreatedBy;
                details.CreatedDate = DateTime.Now;
                details.FormNo = request.FormNo;
                details.lead_Id = request.lead_Id;
                details.PhoneNumber1 = request.PhoneNumber1;
                details.PhoneNumber2 = request.PhoneNumber2;
                details.ApplicantDetailId = applicantDetails.Id;
                details.Category = request.Category;
                details.Residence = request.Residence;
                details.Qualification = request.Qualification;
                details.ApplicantType = request.ApplicantType;
                details.IsSubmit = true;
                details.IsSuccess = true;
                details.IsActive = true;

                applicantDetails.AddressLine1 = request.AddressLine1;
                applicantDetails.AddressLine2 = request.AddressLine2;
                applicantDetails.AddressLine3 = request.AddressLine3;
                applicantDetails.State = request.State;
                applicantDetails.Pincode = request.Pincode;
                applicantDetails.City = request.City;
                applicantDetails.LastModifiedDate = DateTime.Now;

                await _dbContext.LpmCibilCheckDetails.AddAsync(details);

                await _dbContext.SaveChangesAsync();

                request.Message = "Cibil Enquiry Added Successfully";
                request.Succeeded = true;

                return request;
            }
        }
        #endregion
    }
}
