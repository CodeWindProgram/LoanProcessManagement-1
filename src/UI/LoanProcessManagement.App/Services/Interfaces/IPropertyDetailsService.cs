using LoanProcessManagement.Application.Features.PropertyType.Queries;
using LoanProcessManagement.Application.Features.SanctionedPlanReceived.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface IPropertyDetailsService
    {
        Task<IEnumerable<GetAllpropertyTypeDto>> GetAllPropertyType();
        Task<IEnumerable<GetSanctionedPlanDto>> GetSanctionedPlan();


    }
}
