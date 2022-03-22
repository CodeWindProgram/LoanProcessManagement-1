using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.InstitutionMasters.Commands.UpdateInstitutionMasters
{
    public class UpdateInstitutionMastersCommand : IRequest<Response<UpdateInstitutionMastersDto>>
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Institution type is required")]
        public string Institution_Type { get; set; }

        [Required(ErrorMessage = "Institution Name is required")]
        public string Institution_Name { get; set; }
        public bool IsActive { get; set; }
    }
}
