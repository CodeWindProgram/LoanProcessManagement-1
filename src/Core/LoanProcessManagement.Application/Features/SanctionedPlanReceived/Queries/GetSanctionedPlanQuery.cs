using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.SanctionedPlanReceived.Queries
{
#region added getsanctioned query to get response added by - Ramya Guduru -15/11/2021
    public class GetSanctionedPlanQuery:IRequest<IEnumerable<GetSanctionedPlanDto>>
    {
    }
    #endregion
}
