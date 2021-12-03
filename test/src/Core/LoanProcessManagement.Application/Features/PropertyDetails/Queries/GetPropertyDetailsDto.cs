using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.PropertyDetails.Queries
{
    #region added GetPropertyDetailsDto -added by- Ramya Guduru - 15/11/2021
    public class GetPropertyDetailsDto
    {
        #region added dto for getting details of property from LmLeadMaster entity
        public long PropertyID { get; set; }
        public string lead_Id { get; set; }
        public string PropertyPincode { get; set; }
        public string PropertyUnderConstruction { get; set; }
        public string ProjectName { get; set; }
        public string UnitName { get; set; }
        public string ProjectAddress { get; set; }
        public string IsSanctionedPlanReceivedID { get; set; }
        #endregion
    }
    #endregion
}
