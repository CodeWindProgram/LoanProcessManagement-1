using LoanProcessManagement.App.Models;
using LoanProcessManagement.Application.Features.ApplicantDetails.Command;
using LoanProcessManagement.Application.Features.ApplicantDetails.Queries.AddApplicantDetails;
using LoanProcessManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface IApplicantDetailsService
    {
        Task<Response<AddApplicantDetailsDto>> UpdateApplicantDetails(AddApplicantDetailsCommandVM applicantDetailsCommandVM);
        Task<Response<GetApplicantDetailsByIdDto>> GetApplicantDetailsByLeadId(long lead_Id, int applicantType);
    }
}
