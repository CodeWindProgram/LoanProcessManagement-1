using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Menu.Commands.UpdateCommand
{
    public class UpdateMenuCommand : IRequest<Response<UpdateMenuCommandDto>>
    {
        public long Id { get; set; }
        public string MenuName { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public int? Position { get; set; }
        public int ParentId { get; set; }
        public bool IsActive { get; set; }
    }
}
