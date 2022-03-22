using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.Qualification.Commands.CreateQualification
{
   public  class CreateQualificationCommand : IRequest<Response<QualificationDto>>
    {
        [Required(ErrorMessage = "Qualification Name is required")]
        public string QualificationName { get; set; }
    }
}
