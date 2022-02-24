using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.ApplicantDetails.Command
{
    public class AddApplicantDetailsCommand : IRequest<Response<AddApplicantDetailsDto>>
    {
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public string FormNo { get; set; }
        public long lead_Id { get; set; }
        public string LeadID { get; set; }
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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
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
        public int NoOfBankAccounts { get; set; }
        public bool isItrRequired { get; set; }
        public bool isCibilCheckRequired { get; set; }
        public bool isPerfiosRequired { get; set; }
        public bool isGstRequired { get; set; }
    }
}
