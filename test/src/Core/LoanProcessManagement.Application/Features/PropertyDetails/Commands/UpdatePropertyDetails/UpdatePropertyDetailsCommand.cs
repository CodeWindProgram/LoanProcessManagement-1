using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.PropertyDetails.Commands.UpdatePropertyDetails
{
    #region added UpdateProperty details command - Ramya Guduru -15/11/2021
    public class UpdatePropertyDetailsCommand: IRequest<Response<UpdatePropertyDetailsDto>>
    {
        public long PropertyID { get; set; }
        public string lead_Id { get; set; }
        
        public string PropertyPincode { get; set; }
        
        public string PropertyUnderConstruction { get; set; }
        
        public string ProjectName { get; set; }
       
        public string UnitName { get; set; }
        
        public string ProjectAddress { get; set; }
        
        public long IsSanctionedPlanReceivedID { get; set; }
    }
    #endregion
}
