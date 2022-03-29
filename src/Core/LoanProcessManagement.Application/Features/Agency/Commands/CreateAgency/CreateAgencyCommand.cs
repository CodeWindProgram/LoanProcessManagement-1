using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.Agency.Commands.CreateAgency
{
   public  class CreateAgencyCommand : IRequest<Response<CreateAgencyDto>>
    {
        [Required(ErrorMessage = "Agency Name  is required")]
        public string AgencyName { get; set; }
        [Required(ErrorMessage = "Agency Type  is required")]

        public char Agency_type { get; set; }
    }
}
