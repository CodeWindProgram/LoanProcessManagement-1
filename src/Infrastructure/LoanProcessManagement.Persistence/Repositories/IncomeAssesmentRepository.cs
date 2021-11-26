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

namespace LoanProcessManagement.Persistence.Repositories
{
    public class IncomeAssesmentRepository : BaseRepository<LPMGSTEnquiryDetail>,IIncomeAssesmentRepository
    {
        //protected readonly ApplicationDbContext _dbContext;
        private readonly IEmailService emailService;
        private readonly ILogger _logger;
        //private readonly IIncomeAssesmentRepository _incomeAssesmentRepository;
        public IncomeAssesmentRepository(ApplicationDbContext dbContext, ILogger<LPMGSTEnquiryDetail> logger,IEmailService emailService) : base(dbContext, logger, emailService)
        {
            _logger = logger;
           
        }

        public async Task<GstAddEnquiryCommandDto> AddGstEnquiry(int ApplicantType, int Lead_Id)
        {
            var result = await (from A in _dbContext.LPMGSTEnquiryDetails
                                join B in _dbContext.LpmLeadMasters on A.Lead_Id.lead_Id equals B.lead_Id
                                where A.ApplicantType == ApplicantType && A.Lead_Id.Id == Lead_Id && A.IsActive == true
                                select new GstAddEnquiryCommandDto
                                {
                                    FormNo = B.FormNo,
                                    CustomerName = A.CustomerName,
                                    Email = A.Email,
                                    MobileNo = A.MobileNo,
                                    GstNo = A.GstNo,
                                    EmploymentType = A.EmploymentType,
                                    ExcelFilePath = A.ExcelFilePath,
                                    PdfFilePath = A.PdfFilePath
                                }).FirstOrDefaultAsync();
            return result;
        }

        //public async Task<GstCreateEnquiryCommandDto> CreateGstEnquiry(GstCreateEnquiryCommand request)
        //{
        //    var user = await _dbContext.LpmLeadMasters.Include(x => x.FormNo).Where(x => x.Id == request.FormNo).FirstOrDefaultAsync();

        //    var userProcessCycle = await _dbContext.LPMGSTEnquiryDetails.Include(x => x.FormNo).Where(x => x.ID == user.Id).FirstOrDefaultAsync();


        //    var response = new GstCreateEnquiryCommandDto();
        //    if (userProcessCycle != null)
        //    {
        //        userProcessCycle.CustomerName = request.CustomerName;
        //        userProcessCycle.Email = request.Email;
        //        userProcessCycle.MobileNo = request.MobileNo;
        //        userProcessCycle.EmploymentType = request.EmploymentType;
        //        userProcessCycle.GstNo = request.GstNo;
        //        userProcessCycle.PdfFilePath = request.PdfFilePath;
        //        userProcessCycle.ExcelFilePath = request.ExcelFilePath;
        //        await _dbContext.SaveChangesAsync();
        //        response.Message = "GST Data Has Been Updated Successfully !!";
        //        response.FormNo = request.FormNo;
        //        return response;

        //    }
        //    else
        //    {
                //var newLeadEntry = new LpmLeadProcessCycle()
                //{
                //    lead_Id = user.Id,
                //    CurrentStatus = request.CurrentStatus,
                //    DateOfAction = request.DateOfAction,
                //    LoanProductID = request.LoanProductID,
                //    InsuranceProductID = request.InsuranceProductID,
                //    LoanAmount = request.loanAmount,
                //    InsuranceAmount = request.insuranceAmount,
                //    Comment = request.Comments
                //};
                //await _dbContext.LpmLeadProcessCycles.AddAsync(newLeadEntry);
                //newLeadEntry.lead.NationalityType = request.ResidentialStatus;
                //newLeadEntry.lead.CurrentStatus = request.CurrentStatus;
                //newLeadEntry.lead.ProductID = (int)request.LoanProductID;
                //await _dbContext.SaveChangesAsync();
                //response.Message = "Lead Data Has Been Added Successfully !!";
                //response.Succeeded = true;
                //response.Lead_Id = request.lead_Id;
                //return response;

    }
}
