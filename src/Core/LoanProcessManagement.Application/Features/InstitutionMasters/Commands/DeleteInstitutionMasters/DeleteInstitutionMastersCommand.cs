using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.InstitutionMasters.Commands.DeleteInstitutionMasters
{
    public class DeleteInstitutionMastersCommand : IRequest<Response<DeleteInstitutionMastersDto>>
    {
        public long Id { get; set; }
        public DeleteInstitutionMastersCommand(long id)
        {
            this.Id = id;
        }
    }
}
