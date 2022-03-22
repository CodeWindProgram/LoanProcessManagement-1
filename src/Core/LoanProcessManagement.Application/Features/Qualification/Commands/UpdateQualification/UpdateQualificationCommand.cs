using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.Qualification.Commands.UpdateQualification
{
   public  class UpdateQualificationCommand : IRequest<Response<UpdateQualificationDto>>
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Qualification Name is required")]
        public string QualificationName { get; set; }
        public bool IsActive { get; set; }
    }

}
