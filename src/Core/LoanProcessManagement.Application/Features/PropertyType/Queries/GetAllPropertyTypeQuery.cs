using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.PropertyType.Queries
{
    #region added GetAllpropertyTypeQuery -added by- Ramya Guduru - 15/11/2021
    public class GetAllPropertyTypeQuery: IRequest<IEnumerable<GetAllpropertyTypeDto>>
    {
    }
    #endregion
}
