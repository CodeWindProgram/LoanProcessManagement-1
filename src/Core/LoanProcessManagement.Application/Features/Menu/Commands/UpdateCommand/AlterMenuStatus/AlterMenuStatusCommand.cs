using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Menu.Commands.UpdateCommand.AlterMenuStatus
{
    public class AlterMenuStatusCommand : IRequest<AlterMenuStatusCommandDTO>
    {
        public int Id { get; set; }
        public string LgId { get; set; }
    }
}
