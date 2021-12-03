using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.PropertyType.Queries
{
    #region added GetAllpropertyTypeDto - added by - Ramya Guduru - 15/11/2021
    public class GetAllpropertyTypeDto
    {
        #region added dto for getting details of propertyType from propertytype entity
        public long PropertyID { get; set; }
        public string PropertyType { get; set; }
        #endregion
    }
    #endregion
}
