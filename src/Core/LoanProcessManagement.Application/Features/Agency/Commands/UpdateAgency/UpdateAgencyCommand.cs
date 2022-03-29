using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.Agency.Commands.UpdateAgency
{
    public class UpdateAgencyCommand : IRequest<Response<UpdateAgencyDto>>
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Agency Name  is required")]
        public string AgencyName { get; set; }

        [Required(ErrorMessage = "Agency Type  is required")]
        public char Agency_type { get; set; }
        public bool IsActive { get; set; }
    }
}
