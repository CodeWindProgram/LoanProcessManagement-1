using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadList.Queries
{
    public class GetLeadByLeadIdDto
    {
        public long Id { get; set; }

        public string lead_Id { get; set; }

        public string FormNo { get; set; }
        public string CustomerName { get; set; }

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

        public long? LoanProductID { get; set; }

        public long? InsuranceProductID { get; set; }

        public string Product { get; set; }

        public long CurrentStatus { get; set; }

        public string LeadStatus { get; set; }

        public string CustomerType { get; set; }

        public string ResidentialStatus { get; set; }

        public long BranchID { get; set; }

        public string Branch { get; set; }

        public long? LoanAmount { get; set; }

        public long? InsuranceAmount { get; set; }
  
        public string Customer_latitude { get; set; }

        public string Customer_longitude { get; set; }

        public string Lead_assignee_Id { get; set; }

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
        public char QueryStatus { get; set; }
        public string IPSQueryType1 { get; set; }
        public string IPSQueryType2 { get; set; }
        public string IPSQueryType3 { get; set; }
        public string IPSQueryType4 { get; set; }
        public string IPSQueryType5 { get; set; }
        public string IPSQueryType_Comment { get; set; }
        public string IPSResponseType1 { get; set; }
        public string IPSResponseType2 { get; set; }
        public string IPSResponseType3 { get; set; }
        public string IPSResponseType4 { get; set; }
        public string IPSResponseType5 { get; set; }
        public string HoSanction_query_comment { get; set; }
        public string HoSanction_query_commentResponse { get; set; }
        public char HoQueryStatus { get; set; }

    }
}
