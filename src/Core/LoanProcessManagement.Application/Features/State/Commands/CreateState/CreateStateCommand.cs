using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.State.Commands.CreateState
{
    public class CreateStateCommand : IRequest<Response<CreateStateDto>>
    {
        [Required(ErrorMessage = "State Name is required")]

        public string StateName { get; set; }
    }
}
