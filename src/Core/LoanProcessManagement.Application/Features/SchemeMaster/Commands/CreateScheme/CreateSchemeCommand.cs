using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.SchemeMaster.Commands.CreateScheme
{
    public class CreateSchemeCommand : IRequest<Response<CreateSchemeCommandDto>>
    {
        [Required(ErrorMessage = "SchemeName is required.")]
        public string SchemeName { get; set; }

    }
}
