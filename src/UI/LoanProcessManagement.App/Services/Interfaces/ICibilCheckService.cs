using LoanProcessManagement.App.Models;
using LoanProcessManagement.Application.Features.CibilCheck.Commands.AddCibilCheckDetails;
using LoanProcessManagement.Application.Features.CibilCheck.Queries.ApplicantDetails;
using LoanProcessManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface ICibilCheckService
    {
        Task<Response<AddCibilDetailsDto>> UpdateCibilCheckDetailsDetails(CibilCheckDetailsVm cibilCheckDetailsVm);
        Task<Response<GetCibilCheckDetailsDto>> GetCibilCheckDetails(long lead_Id, int applicantType);
    }
}
