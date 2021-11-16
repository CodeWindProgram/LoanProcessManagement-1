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
        [Required(ErrorMessage = "Please enter Pincode* ")]
        public string PropertyPincode { get; set; }
        [Required(ErrorMessage = "Please select property construction*")]
        public string PropertyUnderConstruction { get; set; }
        [Required(ErrorMessage = "Please enter Project Name*")]
        public string ProjectName { get; set; }
        [Required(ErrorMessage = "Please enter Unit Name*")]
        public string UnitName { get; set; }
        [Required(ErrorMessage = "Please enter Project Address* ")]
        public string ProjectAddress { get; set; }
        [Required(ErrorMessage = "Please Choose Sanctioned Plan")]
        public long IsSanctionedPlanReceivedID { get; set; }
    }
    #endregion
}
