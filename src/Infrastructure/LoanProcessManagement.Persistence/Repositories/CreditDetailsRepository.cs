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
using LoanProcessManagement.Application.Features.CreditIncomeDetails.Queries;
using LoanProcessManagement.Application.Features.CreditIncomeDetails.UserDetails.Queries;

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
            var result = await (from D in _dbContext.LpmLeadProcessCycles
                                join A in _dbContext.LpmLeadMasters on D.lead_Id equals A.Id
                                join B in _dbContext.LpmUserMasters on A.Lead_assignee_Id equals B.LgId
                                join C in _dbContext.LpmCibilCheckDetails on A.FormNo equals C.FormNo

                                where C.IsSubmit == true && C.ApplicantType == 0 && D.CurrentStatus == 2

                                select new GetCreditCibilDetailsVm
                                {
                                    FormNo = C.FormNo,
                                    CustomerName = A.FirstName + " "+A.LastName,
                                    MobileNumber = A.CustomerPhone,
                                    CreatedDate = C.CreatedDate,//.ToShortDateString().ToString(),  
                                    EmailId = A.CustomerEmail,
                                    LoanAmount = D.LoanAmount.ToString(),
                                    Issuccess = true,
                                    Message = "data fetched"

                                }).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<GetCreditCibilUserDetailsVm>> GetCreditCibilUserDetailsList(string FormNo)
        {
            var result = await (from A in _dbContext.LpmLeadApplicantsDetails
                                join C in _dbContext.LpmCibilCheckDetails on A.Id equals C.ApplicantDetailId
                                where C.IsSuccess == true && C.FormNo == FormNo

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
            var result = await (from A in _dbContext.LpmLeadMasters
                                join B in _dbContext.LpmUserMasters on A.Lead_assignee_Id equals B.LgId
                                join C in _dbContext.LPMGSTEnquiryDetails on A.FormNo equals C.FormNumber

                                where C.IsActive == true && C.ApplicantType == 0

                                select new GetCreditGstDetailsVm
                                {
                                    FormNo = A.FormNo,
                                    CustomerName = A.FirstName+""+A.LastName,
                                    MobileNumber =A.CustomerPhone,
                                    CreatedDate = C.CreatedDate,
                                    EmailId = A.CustomerEmail,
                                    Issuccess = true,
                                    Message = "data fetched"

                                }).ToListAsync();
            return result;
        }
        public async Task<IEnumerable<GetCreditGstUserDetailsVm>> GetCreditGstUserDetailsList(string FormNo)
        {
            //var temp = _dbContext.LpmLeadMasters;
            //var gst = _dbContext.LPMGSTEnquiryDetails;
            var result = _dbContext.LPMGSTEnquiryDetails.Where(x => x.FormNumber == FormNo).Select(x => new GetCreditGstUserDetailsVm()
            {
                FormNo = x.FormNumber,
                ApplicantName = x.CustomerName,
                CreatedDate = x.CreatedDate,
                PdfFile = x.PdfFilePath,
                ExcelFile=x.ExcelFilePath,
                Issuccess = true,
                Message = "Customer Data Fetched"

            }); ;
            

            //var result = await (from A in _dbContext.LpmLeadMasters
            //                     join C in _dbContext.LPMGSTEnquiryDetails on A.FormNo equals C.FormNumber
            //                     where C.ApplicantType == 0
            //                     select new GetCreditGstUserDetailsVm
            //                     {
            //                         FormNo = (C.FormNo).ToString(),
            //                         ApplicantName = A.FirstName + " " + A.LastName,

            //                         CreatedDate = A.CreatedDate,
            //                         Issuccess = true,
            //                         Message = "customer data fetched"
            //                     }).ToListAsync();

            //var result = await (from A in _dbContext.LpmLeadApplicantsDetails
            //                    join C in _dbContext.LPMGSTEnquiryDetails on A.FormNo equals C.FormNumber
            //                    where C.IsActive == true && C.FormNumber == FormNo

            //                    select new GetCreditGstUserDetailsVm
            //                    {
            //                        FormNo = (C.FormNo).ToString(),
            //                        ApplicantName = A.FirstName + " " + A.LastName,
            //                        ApplicantType = A.ApplicantType,
            //                        CreatedDate = A.CreatedDate,
            //                        Issuccess = true,
            //                        Message = "customer data fetched"

            //                    }).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<CreditITRDetailsListModel>> GetCreditITRDetailsList()
        {
            var result = await (from A in _dbContext.LpmLeadMasters
                                join B in _dbContext.LpmUserMasters on A.Lead_assignee_Id equals B.LgId
                                join C in _dbContext.LpmLeadITRDetails on A.FormNo equals C.FormNo

                                where C.IsSuccess == true && C.ApplicantType == 0

                                select new CreditITRDetailsListModel
                                {
                                    FormNo = C.FormNo,
                                    CustomerName = A.FirstName +" "+A.LastName,
                                    MobileNumber = A.CustomerPhone,
                                    CreatedDate = C.CreatedDate,
                                    EmailId = A.CustomerEmail,
                                    ApplicantType = C.ApplicantType,
                                    Issuccess = true,
                                    Message = "data fetched"

                                }).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<GetCreditITRUserDetailsVm>> GetCreditITRUserDetailsList(string FormNo)
        {
            var result = await (from A in _dbContext.LpmLeadApplicantsDetails
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
        public async Task<IEnumerable<GetIncomeDetailsVm>> GetIncomeDetailsList()
        {
            var result = await (from A in _dbContext.LpmLeadMasters
                                join B in _dbContext.LpmUserMasters on A.Lead_assignee_Id equals B.LgId
                                join C in _dbContext.LpmLeadApplicantsDetails on A.FormNo equals C.FormNo

                                where C.IsActive == true && C.ApplicantType == 0 && C.isPerfiosSubmitSuccess==true
                                select new GetIncomeDetailsVm
                                {
                                    FormNo = C.FormNo,
                                    CustomerName = A.FirstName + " " + A.LastName,
                                    MobileNumber = A.CustomerPhone,
                                    StartDate = C.CreatedDate,//.ToShortDateString().ToString(),  
                                    EmailId = A.CustomerEmail,
                                    EmploymentType=A.EmploymentType,
                                    Issuccess = true,
                                    Message = "data fetched"

                                }).ToListAsync();
            return result;
        }
        public async Task<IEnumerable<GetIncomeUserDetailsVm>> GetIncomeUserDetailsList(string FormNo)
        {
            var result1 = _dbContext.LpmLeadApplicantsDetails.Where(x => x.FormNo == FormNo).FirstOrDefault();

             var result = _dbContext.LpmLeadIncomeAssessmentDetails.Where(x => x.FormNo == FormNo).Select(x => new GetIncomeUserDetailsVm()
            {
                FormNo = x.FormNo,
                ApplicantName = result1.FirstName+" "+result1.LastName,
                ApplicantType=x.ApplicantType,
                CreatedDate = x.CreatedDate,
                PdfFile = x.PdfFileName,
                FileType=x.FileType,
                Institution_Id=x.Institution_Id,
                EmployerName1=x.EmployerName1,
                EmployerName2=x.EmployerName2,
                EmployerName3=x.EmployerName3,
                EmployerName4=x.EmployerName4,
                EmployerName5=x.EmployerName5,
                Issuccess = true,
                Message = "Customer Data Fetched"

            });
            return result;
        }

    }
}
