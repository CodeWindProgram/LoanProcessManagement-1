using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadList.Commands.AddLead
{
    public class AddLeadCommand : IRequest<Response<AddLeadDto>>
    {
        public long Id { get; set; }
        public string lead_Id { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        //public string CreatedDate { get; set; }
        public string FormNo { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string CustomerResidenceaddress { get; set; }

        public string CustomerResidencePincode { get; set; }

        public string CustomerOfficeaddress { get; set; }

        public string CustomerOfficePincode { get; set; }

        public string CustomerPhone { get; set; }

        public string CustomerPhone_Alternate { get; set; }

        public string CustomerEmail { get; set; }

        public string EmploymentType { get; set; }

        public long ProductID { get; set; }

        public long CurrentStatus { get; set; }

        public string CustomerType { get; set; }

        public long BranchID { get; set; }

        public string Lead_assignee_Id { get; set; }

        public DateTime Appointment_Date { get; set; }

        public DateTime Conversion_date { get; set; }

        public string NationalityType { get; set; }

        public string IsPropertyIdentified { get; set; }

        public string Comment { get; set; }

        public string PropertyPincode { get; set; }

        public string PropertyUnderConstruction { get; set; }

        public string ProjectName { get; set; }

        public string UnitName { get; set; }

        public string ProjectAddress { get; set; }

        public long? IsSanctionedPlanReceivedID { get; set; }

        public long? PropertyID { get; set; }

        public string AnnualTurnOverInLastFy { get; set; }

        public string IsApplicantExemptedFromGst { get; set; }

        public string ExemptedCategory { get; set; }

        public string TypeOfFirms { get; set; }

        public long? SchemeID { get; set; }
    }
}
