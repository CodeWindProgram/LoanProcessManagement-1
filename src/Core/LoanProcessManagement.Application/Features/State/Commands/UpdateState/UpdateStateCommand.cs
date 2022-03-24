using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.State.Commands.UpdateState
{
    public class UpdateStateCommand : IRequest<Response<UpdateStateDto>>
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "State Name is required")]
        public string StateName { get; set; }
        public bool IsActive { get; set; }
    }
}
