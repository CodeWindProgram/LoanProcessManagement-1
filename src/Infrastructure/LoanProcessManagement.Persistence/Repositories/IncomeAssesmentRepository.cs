using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTAddEnuiry;
using LoanProcessManagement.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTCreateEnquiry;
using LoanProcessManagement.Application.Contracts.Infrastructure;
using LoanProcessManagement.Application.Features.IncomeAssesment.Queries.GetIncomeAssessment;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.AddIncomeAssessment;
using LoanProcessManagement.Domain.CustomModels;
using System;

namespace LoanProcessManagement.Persistence.Repositories
{
    public class IncomeAssesmentRepository : BaseRepository<LPMGSTEnquiryDetail>, IIncomeAssesmentRepository
    {
        //protected readonly ApplicationDbContext _dbContext;
        private readonly IEmailService emailService;
        private readonly ILogger _logger;
        //private readonly IIncomeAssesmentRepository _incomeAssesmentRepository;
        public IncomeAssesmentRepository(ApplicationDbContext dbContext, ILogger<LPMGSTEnquiryDetail> logger, IEmailService emailService) : base(dbContext, logger, emailService)
        {
            _logger = logger;

        }

        public async Task<GstAddEnquiryCommandDto> AddGstEnquiry(int ApplicantType, int Lead_Id)
        {
            List<int> applicantTypeList = await _dbContext.LpmLeadApplicantsDetails.Where(x => x.lead_Id == Lead_Id).OrderBy(x => x.ApplicantType).Select(x => x.ApplicantType).ToListAsync();      //represent list of applicant types under particular lead
            var result = await (from A in _dbContext.LPMGSTEnquiryDetails
                                join B in _dbContext.LpmLeadMasters on A.Lead_Id.lead_Id equals B.lead_Id
                                where A.ApplicantType == ApplicantType && A.Lead_Id.Id == Lead_Id && A.IsActive == true
                                select new GstAddEnquiryCommandDto
                                {
                                    Lead_Id = Lead_Id,
                                    ID = A.ID,
                                    FormNo = int.Parse(B.FormNo),
                                    CustomerName = A.CustomerName,
                                    Email = A.Email,
                                    MobileNo = A.MobileNo,
                                    GstNo = A.GstNo,
                                    EmploymentType = A.EmploymentType,
                                    ExcelFilePath = A.ExcelFilePath,
                                    PdfFilePath = A.PdfFilePath,
                                    IsActive = A.IsActive,
                                    ApplicantType = A.ApplicantType,
                                    AppTypeList = applicantTypeList
                                }).FirstOrDefaultAsync();
            
            return result;
        }

        #region this repository method will get IncomeAssessment Details - Pratiksha Poshe - 14/02/2021
        /// <summary>
        /// 14/02/2021 - this repository method will get IncomeAssessment Details
        /// Commented by Pratiksha Poshe
        /// </summary>
        /// <param name="lead_id"></param>
        /// <param name="ApplicantType"></param>
        /// <returns></returns>
        public async Task<GetIncomeAssessmentDetailsDto> GetIncomeAssessmentDetailsAsync(int ApplicantType, long lead_id)
        {
            var lead = await _dbContext.LpmLeadMasters.Include(x => x.Product).Include(x => x.LeadStatus).Include(z => z.Branch)
               .Where(x => x.Id == lead_id).FirstOrDefaultAsync();

            var applicant = await _dbContext.LpmLeadApplicantsDetails.Include(x => x.LpmLeadMaster)
                .Where(x => x.lead_Id == lead_id && x.ApplicantType == ApplicantType).FirstOrDefaultAsync();

            List<int> applicantTypeList = await _dbContext.LpmLeadApplicantsDetails.Where(x => x.lead_Id == lead_id).OrderBy(x => x.ApplicantType).Select(x => x.ApplicantType).ToListAsync();

            var isSubmitCount = _dbContext.LpmLeadIncomeAssessmentDetails.Include(x => x.LeadApplicantDetails).Where(x => x.lead_Id == lead_id && x.ApplicantType == ApplicantType && x.IsActive).Count();

            GetIncomeAssessmentDetailsDto response = new GetIncomeAssessmentDetailsDto();

            if (applicant != null)
            {
                response.lead_Id = applicant.lead_Id;
                response.CustomerName = applicant.FirstName + " " + applicant.MiddleName + " " + applicant.LastName;
                response.FormNo = lead.FormNo;
                response.ApplicantType = applicant.ApplicantType;
                response.CustomerEmail = applicant.CustomerEmail;
                response.CustomerPhone = applicant.CustomerPhone;
                response.EmploymentType = applicant.EmploymentType;
                response.NoOfBankAccounts = applicant.NoOfBankAccounts;
                response.ApplicantDetailId = applicant.Id;
                response.ApplicantType = applicant.ApplicantType;
                response.LeadID = lead.lead_Id;
                response.IsSubmitCount = isSubmitCount;
                response.AppTypeList = applicantTypeList;

                response.Message = "Income Assessment Details fetched";
                response.Succeeded = true;
                return response;
            }
            else
            {
                
                response.FormNo = lead.FormNo;
                response.LeadID = lead.lead_Id;
                response.Succeeded = false;
                response.Message = "Income Assessment Details not fetched";
                return response;
            }
            
        }
        #endregion

        #region this repository method will add IncomeAssessment Details - Pratiksha Poshe - 14/02/2021
        public async Task<IncomeAssessmentDetailsModel> AddIncomeAssessmentDetailsAsync(IncomeAssessmentDetailsModel request)
        {
            var applicantDetails = await _dbContext.LpmLeadApplicantsDetails.Include(x => x.LpmLeadMaster)
                .Where(x => x.lead_Id == request.lead_Id && x.ApplicantType == request.ApplicantType).FirstOrDefaultAsync();

            LpmLeadIncomeAssessmentDetails details = new LpmLeadIncomeAssessmentDetails();

            details.FormNo = request.FormNo;
            details.lead_Id = request.lead_Id;
            details.CreatedDate = DateTime.Now;
            details.CreatedBy = request.CreatedBy;
            details.LastModifiedDate = DateTime.Now;
            details.LastModifiedBy = request.LastModifiedBy;
            details.ApplicantDetailId = applicantDetails.Id;
            details.ApplicantType = request.ApplicantType;
            details.StartDate = request.StartDate;
            details.EndDate = request.EndDate;
            details.EmployerName1 = request.EmployerName1;
            details.EmployerName2 = request.EmployerName2;
            details.EmployerName3 = request.EmployerName3;
            details.EmployerName4 = request.EmployerName4;
            details.EmployerName5 = request.EmployerName5;
            details.FileType = request.FileType;
            details.Institution_Id = request.Institution_Id;
            details.DocumentType = request.DocumentType;
            details.PdfFileName = request.PdfFileName;
            details.FilePassword = request.FilePassword;
            details.IsActive = true;
            details.IsSuccess = true;
            await _dbContext.LpmLeadIncomeAssessmentDetails.AddAsync(details);
            await _dbContext.SaveChangesAsync();

            request.Message = "Income Assessment Details Added Successfully";
            request.Succeeded = true;

            return request;
        }
        #endregion

        //public async Task<GstCreateEnquiryCommandDto> CreateGstEnquiry(GstCreateEnquiryCommand request)
        //{
        //    //var user = await _dbContext.LpmLeadMasters.Include(x => x.FormNo).Where(x => x.Id == request.FormNo).FirstOrDefaultAsync();

        //    //var userProcessCycle = await _dbContext.LPMGSTEnquiryDetails.Include(x => x.FormNo).Where(x => x.ID == user.Id).FirstOrDefaultAsync();


        //    var result = await (from A in _dbContext.LPMGSTEnquiryDetails
        //                        join B in _dbContext.LpmLeadMasters on A.Lead_Id.lead_Id equals B.lead_Id
        //                        where A.IsActive == true
        //                        select new GstCreateEnquiryCommandDto
        //                        {
        //                            ID = A.ID,
        //                            FormNo = int.Parse(B.FormNo),
        //                            CustomerName = A.CustomerName,
        //                            Email = A.Email,
        //                            MobileNo = A.MobileNo,
        //                            GstNo = A.GstNo,
        //                            EmploymentType = A.EmploymentType,
        //                            ExcelFilePath = A.ExcelFilePath,
        //                            PdfFilePath = A.PdfFilePath,
        //                            IsActive = A.IsActive,
        //                            ApplicantType = A.ApplicantType

        //                        }).FirstOrDefaultAsync();
        //    return result;
        //}
    }
}
