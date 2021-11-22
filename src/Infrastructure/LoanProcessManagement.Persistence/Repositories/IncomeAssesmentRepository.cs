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
                                    EmployementType = A.EmploymentType,
                                    ExcelFilePath = A.ExcelFilePath,
                                    PdfFilePath = A.PdfFilePath
                                }).FirstOrDefaultAsync();
            return result;
        }

        //public async Task<GstCreateEnquiryCommandDto> CreateGstEnquiry(GstCreateEnquiryCommand request)
        //{
        //    //await _dbContext.LPMGSTEnquiryDetails.AddAsync(request);
        //    //await _dbContext.SaveChangesAsync();
        //    //return request;
        //    return await _incomeAssesmentRepository.CreateGstEnquiry(request);
        //}
    }
}
