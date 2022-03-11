using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.SchemeMaster.Commands.UpdateScheme
{
    public class UpdateSchemeCommand : IRequest<Response<UpdateSchemeCommandDto>>
    {
        public long Id { get; set; }
        public string SchemeName { get; set; }
        public bool IsActive { get; set; }
    }
}
