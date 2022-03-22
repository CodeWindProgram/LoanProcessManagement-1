using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Qualification.Commands.DeleteQualification
{
    public class DeleteQualificationCommand : IRequest<Response<DeleteQualificationDto>>
    {
        public long Id { get; set; }
        public DeleteQualificationCommand(long id)
        {
            this.Id = id;
        }
    }
}
