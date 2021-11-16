using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.PropertyDetails.Commands.UpdatePropertyDetails
{
    #region added UpdateProperty details dto command - Ramya Guduru -15/11/2021
    public class UpdatePropertyDetailsDto
    {
        
        public long PropertyID { get; set; }
        public string lead_Id { get; set; }
        public string PropertyPincode { get; set; }
        public string PropertyUnderConstruction { get; set; }
        public string ProjectName { get; set; }
        public string UnitName { get; set; }
        public string ProjectAddress { get; set; }
        public long IsSanctionedPlanReceivedID { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
    #endregion
}
