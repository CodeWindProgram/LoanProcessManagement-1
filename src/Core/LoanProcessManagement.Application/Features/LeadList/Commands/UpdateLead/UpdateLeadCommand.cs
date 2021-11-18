using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadList.Commands.UpdateLead
{
    public class UpdateLeadCommand : IRequest<Response<UpdateLeadDto>>
    {
        public string lead_Id { get; set; }
        public string login_id { get; set; }
        public long UserRoleId { get; set; }
        public string FormNo { get; set; }
        public string ResidentialStatus { get; set; }
        public long? LoanProductID { get; set; }
        public long? InsuranceProductID { get; set; }
        public long CurrentStatus { get; set; }
        public string Comments { get; set; }
        public long? loanAmount { get; set; }
        public long? insuranceAmount { get; set; }
        public DateTime DateOfAction { get; set; }
    }
}
