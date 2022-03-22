using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadStatus.Commands.UpdateLeadStatus
{
    public class UpdateLeadStatusCommand : IRequest<Response<UpdateLeadStatusDto>>
    {
        public long Id { get; set; }

       [Required(ErrorMessage = "Status Description  is required")]
        public string StatusDescription { get; set; }
        [Required(ErrorMessage = "Status Serial Order  is required")]
        public int SerialOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
