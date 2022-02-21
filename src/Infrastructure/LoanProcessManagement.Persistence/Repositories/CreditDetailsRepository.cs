using LoanProcessManagement.Application.Contracts.Infrastructure;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Domain.CustomModels;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoanProcessManagement.Application.Features.CreditITRDetails.UserDetails.Queries;
using LoanProcessManagement.Application.Features.CreditCibilDetails.CreditCibilCheckDetails.Queries;
using LoanProcessManagement.Application.Features.CreditCibilDetails.UserDetails.Queries;
using LoanProcessManagement.Application.Features.CreditGstDetails.CreditGstCheckDetails.Queries;
using LoanProcessManagement.Application.Features.CreditGstDetails.UserDetails.Queries;

namespace LoanProcessManagement.Persistence.Repositories
{
    public class CreditDetailsRepository : BaseRepository<IEnumerable<CreditITRDetailsListModel>>, ICreditDetailsRepository
    {
        private readonly ILogger _logger;
        private readonly IEmailService _emailService;
        public CreditDetailsRepository(ApplicationDbContext dbContext, ILogger<IEnumerable<CreditITRDetailsListModel>> logger, IEmailService emailService) : base(dbContext, logger, emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        #region added Repository methods  to get user cibil, ITR and Gst credit and user details  - Ramya Guduru - 15/02/2022
        public async Task<IEnumerable<GetCreditCibilDetailsVm>> GetCreditCibilDetailsList()
        {
            var result = await(from D in _dbContext.LpmLeadProcessCycles
                               join A in _dbContext.LpmLeadMasters on D.lead_Id equals A.Id 
                               join B in _dbContext.LpmUserMasters on A.Lead_assignee_Id equals B.LgId
                               join C in _dbContext.LpmCibilCheckDetails on A.FormNo equals C.FormNo
                               
                               where C.IsSubmit == true && C.ApplicantType == 0 && D.CurrentStatus == 2

                               select new GetCreditCibilDetailsVm
                               {
                                   FormNo = C.FormNo,
                                   CustomerName = B.Name,
                                   MobileNumber = B.PhoneNumber,
                                   CreatedDate = C.CreatedDate,//.ToShortDateString().ToString(),  
                                   EmailId = B.Email,
                                   LoanAmount = D.LoanAmount.ToString(),
                                   Issuccess = true,
                                   Message = "data fetched"

                               }).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<GetCreditCibilUserDetailsVm>> GetCreditCibilUserDetailsList(string FormNo)
        {
            var result = await(from A in _dbContext.LpmLeadApplicantsDetails
                               join C in _dbContext.LpmCibilCheckDetails on A.Id equals C.ApplicantDetailId
                               where C.IsSuccess == true &&  C.FormNo == FormNo

                               select new GetCreditCibilUserDetailsVm
                               {
                                   FormNo = FormNo,
                                   ApplicantName = A.FirstName + " " + A.LastName,
                                   ApplicantType = A.ApplicantType,
                                   CreatedDate = C.CreatedDate,                                   
                                   Issuccess = true,
                                   Message = "customer cibil data fetched"

                               }).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<GetCreditGstDetailsVm>> GetCreditGstDetailsList()
        {
            var result = await(from A in _dbContext.LpmLeadMasters
                               join B in _dbContext.LpmUserMasters on A.Lead_assignee_Id equals B.LgId
                               join C in _dbContext.LPMGSTEnquiryDetails on A.FormNo equals C.FormNumber
                               
                               where C.IsActive == true && C.ApplicantType == 0

                               select new GetCreditGstDetailsVm
                               {
                                   FormNo = A.FormNo,
                                   CustomerName = B.Name,
                                   MobileNumber = B.PhoneNumber,
                                   CreatedDate = C.CreatedDate,
                                   EmailId = B.Email,
                                   Issuccess = true,
                                   Message = "data fetched"

                               }).ToListAsync();
            return result;
        }
        public async Task<IEnumerable<GetCreditGstUserDetailsVm>> GetCreditGstUserDetailsList(string FormNo)
        {
            var result = await(from A in _dbContext.LpmLeadApplicantsDetails
                               join C in _dbContext.LPMGSTEnquiryDetails on A.FormNo equals C.FormNumber

                               where C.IsActive == true &&  C.FormNumber == FormNo

                               select new GetCreditGstUserDetailsVm
                               {
                                   FormNo = (C.FormNo).ToString(),
                                   ApplicantName = A.FirstName + " " + A.LastName,
                                   ApplicantType = A.ApplicantType,
                                   CreatedDate = A.CreatedDate,
                                   Issuccess = true,
                                   Message = "customer data fetched"

                               }).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<CreditITRDetailsListModel>> GetCreditITRDetailsList()
        {
            var result = await(from A in _dbContext.LpmLeadMasters
                               join B in _dbContext.LpmUserMasters on A.Lead_assignee_Id equals B.LgId
                               join C in _dbContext.LpmLeadITRDetails on A.FormNo equals C.FormNo
                               
                               where C.IsSuccess == true && C.ApplicantType == 0 

                               select new CreditITRDetailsListModel
                               {
                                   FormNo = C.FormNo,
                                   CustomerName = B.Name,
                                   MobileNumber = B.PhoneNumber,
                                   CreatedDate = C.CreatedDate,
                                   EmailId = B.Email,
                                   ApplicantType = C.ApplicantType,
                                   Issuccess = true,
                                   Message = "data fetched"

                               }).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<GetCreditITRUserDetailsVm>> GetCreditITRUserDetailsList(string FormNo)
        {
            var result = await(from A in _dbContext.LpmLeadApplicantsDetails
                               join C in _dbContext.LpmLeadITRDetails on A.Id equals C.ApplicantDetailId
                               where /*C.IsSuccess == true && */ C.FormNo == FormNo 

                               select new GetCreditITRUserDetailsVm
                               {
                                   FormNo = FormNo,
                                   ApplicantName = A.FirstName + " " + A.LastName,
                                   ApplicantType = C.ApplicantType,
                                   CreatedDate = A.CreatedDate,
                                   Status = C.IsSuccess,
                                   Issuccess = true,
                                   Message = "data fetched"

                               }).ToListAsync();
            return result;
        }
        #endregion
    }
}
