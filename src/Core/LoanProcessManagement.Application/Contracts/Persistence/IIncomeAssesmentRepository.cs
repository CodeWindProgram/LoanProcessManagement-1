using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTAddEnuiry;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface IIncomeAssesmentRepository
    {
        Task<IEnumerable<GstAddEnquiryCommandDto>> AddGstEnquiry(int ApplicantType , string Lead_Id);
    }
}
