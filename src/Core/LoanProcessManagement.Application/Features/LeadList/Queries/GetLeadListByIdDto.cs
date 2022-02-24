using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadList.Queries
{
    public class GetLeadListByIdDto
    {
        public long Id { get; set; }

        public string lead_Id { get; set; }
        [DisplayName("Form Number")]
        public string FormNo { get; set; }
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Residence Address")]
        public string CustomerResidenceaddress { get; set; }
        [DisplayName("Residence Pincode")]
        public string CustomerResidencePincode { get; set; }
        [DisplayName("Office Address")]
        public string CustomerOfficeaddress { get; set; }
        [DisplayName("Office Pincode")]
        public string CustomerOfficePincode { get; set; }
        [DisplayName("Phone Number 1")]
        public string CustomerPhone { get; set; }
        [DisplayName("Phone Number 2")]
        public string CustomerPhone_Alternate { get; set; }
        [DisplayName("Email Address")]
        public string CustomerEmail { get; set; }

        public long ProductID { get; set; }
        [DisplayName("Product")]
        public string Product { get; set; }

        public long CurrentStatus { get; set; }
        [DisplayName("Lead Status")]
        public string LeadStatus { get; set; }

        public string CustomerType { get; set; }

        public long BranchID { get; set; }

        public string Branch { get; set; }

        public string Customer_latitude { get; set; }

        public string Customer_longitude { get; set; }

        public string Lead_assignee_Id { get; set; }
        [DisplayName("Appointment Date")]
        public DateTime Appointment_Date { get; set; }

        public DateTime Conversion_date { get; set; }

        public string Disbursal_date { get; set; }

        public string Industry_Major { get; set; }

        public string Sale_type { get; set; }

        public string EmploymentType { get; set; }

        public string NationalityType { get; set; }

        public string IsPropertyIdentified { get; set; }

        public string PropertyPincode { get; set; }

        public string PropertyUnderConstruction { get; set; }

        public string ProjectName { get; set; }

        public string UnitName { get; set; }

        public string ProjectAddress { get; set; }

        public string IsSanctionedPlanReceived { get; set; }

        public long LostLeadReasonID { get; set; }

        public string LostLeadComment { get; set; }

        public long RejectLeadReasonID { get; set; }

        public string RejectedLeadComment { get; set; }

        public string Comment { get; set; }

        public string GoggleLatitude { get; set; }

        public string GoggleLongitude { get; set; }
        public bool IsActive { get; set; }

    }
}

