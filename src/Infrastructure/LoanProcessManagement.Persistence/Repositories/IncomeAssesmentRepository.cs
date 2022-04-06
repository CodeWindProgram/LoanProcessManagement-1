using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTAddEnuiry;
using LoanProcessManagement.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTCreateEnquiry;
using LoanProcessManagement.Application.Contracts.Infrastructure;
using LoanProcessManagement.Application.Features.IncomeAssesment.Queries.GetIncomeAssessment;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.AddIncomeAssessment;
using LoanProcessManagement.Domain.CustomModels;
using System;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.UpdateSubmitGst;
using LoanProcessManagement.Application.Features.IncomeAssesment.Queries.GetIncomeAssessmentRecordsList;

namespace LoanProcessManagement.Persistence.Repositories
{
    public class IncomeAssesmentRepository : BaseRepository<LPMGSTEnquiryDetail>, IIncomeAssesmentRepository
    {
        private readonly ILpmInstitutionMastersRepository _lpmInstitutionMastersRepository;
        public IncomeAssesmentRepository(ApplicationDbContext dbContext, ILogger<LPMGSTEnquiryDetail> logger, IEmailService emailService, ILpmInstitutionMastersRepository lpmInstitutionMastersRepository) : base(dbContext, logger, emailService)
        {
            _lpmInstitutionMastersRepository = lpmInstitutionMastersRepository;
        }

        public async Task<GstCreateEnquiryCommandDto> CreateGstEnquiry(GstCreateEnquiryCommand request)
        {
            var lead = _dbContext.LpmLeadMasters.Where(a => a.lead_Id == (request.Lead_IdId).ToString()).FirstOrDefault();
            var applicantDetails = await _dbContext.LpmLeadApplicantsDetails
            .Where(x => x.lead_Id == request.Lead_IdId && x.ApplicantType == request.ApplicantType).FirstOrDefaultAsync();
            GstCreateEnquiryCommandDto response = new GstCreateEnquiryCommandDto();
            var gstCreateEnquiryCommandDto = new LPMGSTEnquiryDetail()
            {
                FormNumber = request.FormNo.ToString(),
                Lead_Id = lead,
                CustomerName = request.CustomerName,
                MobileNo = request.MobileNo,
                Email = request.Email,
                ExcelFilePath = request.ExcelFilePath,
                PdfFilePath = request.PdfFilePath,
                GstNo = request.GstNo,
                ApplicantType = request.ApplicantType,
                IsActive = request.IsActive,
                EmploymentType = request.EmploymentType,
                ApplicantDetailId = request.ApplicantDetailId
            };
            await _dbContext.LPMGSTEnquiryDetails.AddAsync(gstCreateEnquiryCommandDto);
            applicantDetails.isGstSubmitSuccess = true;
            _dbContext.SaveChanges();
            response.ApplicantDetailId = request.ApplicantDetailId;
            response.ApplicantType = request.ApplicantType;
            response.GstNo = request.GstNo;
            response.Succeeded = true;
            response.Message = "GST details added successfully";
            return response;
        }

        public async Task<GstAddEnquiryCommandDto> AddGstEnquiry(int ApplicantType, int Lead_Id)
        {
            List<int> applicantTypeList = await _dbContext.LpmLeadApplicantsDetails.Where(x => x.lead_Id == Lead_Id).OrderBy(x => x.ApplicantType).Select(x => x.ApplicantType).ToListAsync();      //represent list of applicant types under particular lead
            //var res = await (from A in _dbContext.LpmLeadApplicantsDetails
            //                  //join B in _dbContext.LPMGSTEnquiryDetails on A.Id equals B.ApplicantDetailId
            //              where A.ApplicantType == ApplicantType && A.lead_Id == Lead_Id //&& A.IsActive
            //              select new GstAddEnquiryCommandDto 
            //              {
            //                  Lead_Id = Lead_Id,
            //                  ID = A.Id,
            //                  FormNo = long.Parse(A.FormNo),
            //                  CustomerName = A.FirstName + " " + A.LastName,
            //                  Email = A.CustomerEmail,
            //                  MobileNo = A.CustomerPhone,
            //                  //GstNo = B.GstNo,
            //                  EmploymentType = A.EmploymentType,
            //                  //ExcelFilePath = B.ExcelFilePath,
            //                  //PdfFilePath = B.PdfFilePath,
            //                  IsActive = A.IsActive,
            //                  ApplicantType = A.ApplicantType,
            //                  ApplicantDetailId = A.Id,
            //                  AppTypeList = applicantTypeList
            //              }).FirstOrDefaultAsync();
            var applicantDetails = await _dbContext.LpmLeadApplicantsDetails.Where(x => x.ApplicantType == ApplicantType && x.lead_Id == Lead_Id).FirstOrDefaultAsync();
            var gstDetails = await _dbContext.LPMGSTEnquiryDetails.Where(x => x.ApplicantDetailId == applicantDetails.Id).FirstOrDefaultAsync();
            GstAddEnquiryCommandDto res = new GstAddEnquiryCommandDto();
            if (applicantDetails != null && gstDetails!= null)
            {
                res.Lead_Id = Lead_Id;
                res.ID = applicantDetails.Id;
                res.FormNo = long.Parse(applicantDetails.FormNo);
                res.CustomerName = applicantDetails.FirstName + " " + applicantDetails.LastName;
                res.Email = applicantDetails.CustomerEmail;
                res.MobileNo = applicantDetails.CustomerPhone;
                res.GstNo = gstDetails.GstNo;
                res.EmploymentType = applicantDetails.EmploymentType;
                res.IsActive = applicantDetails.IsActive;
                res.ApplicantType = applicantDetails.ApplicantType;
                res.ApplicantDetailId = applicantDetails.Id;
                res.AppTypeList = applicantTypeList;
            }
            else
            {
                res.Lead_Id = Lead_Id;
                res.ID = applicantDetails.Id;
                res.FormNo = long.Parse(applicantDetails.FormNo);
                res.CustomerName = applicantDetails.FirstName + " " + applicantDetails.LastName;
                res.Email = applicantDetails.CustomerEmail;
                res.MobileNo = applicantDetails.CustomerPhone;
                res.EmploymentType = applicantDetails.EmploymentType;
                res.IsActive = applicantDetails.IsActive;
                res.ApplicantType = applicantDetails.ApplicantType;
                res.ApplicantDetailId = applicantDetails.Id;
                res.AppTypeList = applicantTypeList;
            }
            return res;
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

            var isSubmitCount = _dbContext.LpmLeadIncomeAssessmentDetails.Include(x => x.LeadApplicantDetails).Where(x => x.lead_Id == lead_id && x.ApplicantType == ApplicantType && x.IsActive).Count();    //to fetch all applicant types under a particular lead 

            var incomeRecordsCount = _dbContext.LpmLeadIncomeAssessmentDetails.Include(x => x.LeadApplicantDetails).Where(x => x.lead_Id == lead_id && x.ApplicantType == ApplicantType).Count();             //to count existing income details records

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
                response.IncomeRecords = incomeRecordsCount;     
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
        /// <summary>
        /// 14/02/2021 - this repository method will add IncomeAssessment Details 
        /// commented by Pratiksha Poshe.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IncomeAssessmentDetailsModel> AddIncomeAssessmentDetailsAsync(IncomeAssessmentDetailsModel request)
        {
            var applicantDetails = await _dbContext.LpmLeadApplicantsDetails.Include(x => x.LpmLeadMaster)
                .Where(x => x.lead_Id == request.lead_Id && x.ApplicantType == request.ApplicantType).FirstOrDefaultAsync();

            LpmLeadIncomeAssessmentDetails details = new LpmLeadIncomeAssessmentDetails
            {
                FormNo = request.FormNo,
                lead_Id = request.lead_Id,
                CreatedDate = DateTime.Now,
                CreatedBy = request.CreatedBy,
                LastModifiedDate = DateTime.Now,
                LastModifiedBy = request.LastModifiedBy,
                ApplicantDetailId = applicantDetails.Id,
                ApplicantType = request.ApplicantType,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                EmployerName1 = request.EmployerName1,
                EmployerName2 = request.EmployerName2,
                EmployerName3 = request.EmployerName3,
                EmployerName4 = request.EmployerName4,
                EmployerName5 = request.EmployerName5,
                FileType = request.FileType,
                Institution_Id = request.Institution_Id,
                DocumentType = request.DocumentType,
                PdfFileName = request.PdfFileName,
                FilePassword = request.FilePassword,
                IsActive = true,
                IsSuccess = true
            };
            await _dbContext.LpmLeadIncomeAssessmentDetails.AddAsync(details);
            applicantDetails.isPerfiosSubmitSuccess = true;
            await _dbContext.SaveChangesAsync();

            request.Message = "Income Assessment Details Added Successfully";
            request.Succeeded = true;

            return request;
        }
        #endregion

        #region Method to fetch income assessment records list from db - Pratiksha Poshe - 03/03/2022
        /// <summary>
        /// 03/03/2022 - Method to fetch income assessment records list from db
        /// commented by Pratiksha Poshe
        /// </summary>
        /// <param name="ApplicantType"></param>
        /// <param name="lead_id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<GetIncomeAssessmentRecordsListDto>> GetIncomeAssessmentRecordsList (int ApplicantType, long lead_id)
        {
            var incomeAssessmentRecords = await _dbContext.LpmLeadIncomeAssessmentDetails.Where(x => x.ApplicantType == ApplicantType && x.lead_Id == lead_id).Include(x => x.LeadApplicantDetails).OrderByDescending(x => x.Id)
                .Select( x => new GetIncomeAssessmentRecordsListDto()
                {
                    CreatedDate = x.CreatedDate,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    EmployerName1 = x.EmployerName1,
                    EmployerName2 = x.EmployerName2,
                    EmployerName3 = x.EmployerName3,
                    EmployerName4 = x.EmployerName4,
                    EmployerName5 = x.EmployerName5,
                    FileType = x.FileType,
                    Institution_Id = x.Institution_Id,
                    DocumentType = x.DocumentType,
                    IsActive = x.IsActive,
                    Succeeded = true,
                    Message = "Income assessment records fetched successfully"
                }).ToListAsync();

                foreach (var records in incomeAssessmentRecords)
                {
                    if (records.FileType == "FileUpload")
                    {
                        var institutionName = await _lpmInstitutionMastersRepository.GetInstitutionMastersByIdAsync(records.Institution_Id);
                        records.InstitutionName = institutionName.Institution_Name ?? string.Empty;
                    }
                }
                return incomeAssessmentRecords;
        }
        #endregion

        public async Task<Response<UpdateSubmitGstCommandDto>>UpdateIsSubmit(UpdateSubmitGstCommand req)
        {
            UpdateSubmitGstCommandDto response = new UpdateSubmitGstCommandDto();
            var data =  _dbContext.LpmLeadApplicantsDetails.Where(x => x.Id == req.Id).FirstOrDefault();
            if (data != null)
            {
                data.Id = req.Id;
                data.IsSubmit = req.IsSubmit;
                await _dbContext.SaveChangesAsync();
            }
            return new Response<UpdateSubmitGstCommandDto>(response);
        }
    }
}