using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTAddEnuiry;
using LoanProcessManagement.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LoanProcessManagement.Persistence.Repositories
{
    public class IncomeAssesmentRepository : IIncomeAssesmentRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public IncomeAssesmentRepository(ApplicationDbContext dbContext, ILogger<GstAddEnquiryCommandDto> logger)
        {
            _dbContext = dbContext; 
            _logger = logger;
        }

        public async Task<IEnumerable<GstAddEnquiryCommandDto>> AddGstEnquiry(int ApplicantType, string Lead_Id)
        {
            var result = await (from A in _dbContext.LPMGSTEnquiryDetails
                                //join B in _dbContext.LpmLeadMasters on A.Lead_Id equals long.Parse(B.lead_Id)
                                where A.ApplicantType == ApplicantType //&& A.IsActive == true
                                select new GstAddEnquiryCommandDto
                                {
                                    //FormNo=B.FormNo,
                                    //CustomerName=A.CustomerName,
                                    //Email=A.Email,
                                    //MobileNo=A.MobileNo,
                                    //GstNo=A.GstNo,
                                    //EmployementType=A.ApplicantType,
                                    //ExcelFilePath=A.ExcelFilePath,
                                    //PdfFilePath=A.PdfFilePath
                                }).ToListAsync();
            return result;
        }
    }
}
