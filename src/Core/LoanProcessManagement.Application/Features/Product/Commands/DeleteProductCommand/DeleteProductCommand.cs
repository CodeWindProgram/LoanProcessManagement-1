using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Product.Commands.DeleteProductCommand
{
    public class DeleteProductCommand : IRequest<Response<DeleteProductCommandDto>>
    {
        public DeleteProductCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
