using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadStatus.Commands.CreateLeadStatus
{
    public class CreateLeadStatusCommand : IRequest<Response<LeadStatusDto>>
    {
        [Required(ErrorMessage = "StatusDescription  is required")]
        public string StatusDescription { get; set; }
        [Required(ErrorMessage = "SerialOrder is required")]
        public int SerialOrder { get; set; }

       
    }
}
