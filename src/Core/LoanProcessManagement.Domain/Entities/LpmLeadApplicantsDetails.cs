using LoanProcessManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoanProcessManagement.Domain.Entities
{
    public class LpmLeadApplicantsDetails : AuditableEntity
    {
        public long Id { get; set; }
        public string FormNo { get; set; }
        public long lead_Id { get; set; }
        public LpmLeadMaster LpmLeadMaster { get;set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string State { get; set; }
        public string Gender { get; set; } //

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")] //
        public DateTime DateOfBirth { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string EmploymentType { get; set; }
        public string GstNo { get; set; }
        public string PanCardNo { get; set; }    
        public string PassportNo { get; set; }    
        public string VoterId { get; set; }    
        public string RationCardNo { get; set; }    
        public string DrivingLiscenceNo { get; set; }    
        public string AadharId { get; set; }    
        public int ApplicantType { get; set; }  //  
        //public string Qualification { get; set; } //
        public int NoOfBankAccounts { get; set; }
        public bool IsActive { get; set; }

        public bool isItrRequired { get; set; }
        public bool isCibilCheckRequired { get; set; }
        public bool isPerfiosRequired { get; set; }
        public bool isGstRequired { get; set; }
        public bool isItrSubmitSuccess { get; set; }
        public bool isCibilCheckSubmitSuccess { get; set; }
        public bool isPerfiosSubmitSuccess { get; set; }
        public bool isGstSubmitSuccess { get; set; }
        public bool IsSubmit { get; set; }
        
        public ICollection<LPMGSTEnquiryDetail> LPMGSTEnquiryDetails { get; set; }
        public ICollection<LpmLeadITRDetails> LpmLeadITRDetails { get; set; }
        public ICollection<LpmCibilCheckDetails> LpmCibilCheckDetails { get; set; }
        public ICollection<LpmLeadIncomeAssessmentDetails> LpmLeadIncomeAssessmentDetails { get; set; }
    }
}