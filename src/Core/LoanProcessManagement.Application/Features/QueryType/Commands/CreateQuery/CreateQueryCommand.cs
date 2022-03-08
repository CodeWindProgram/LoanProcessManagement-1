using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.QueryType.Commands.CreateQuery
{
    public class CreateQueryCommand : IRequest<Response<CreateQueryCommandDto>>
    {
        [Required(ErrorMessage ="Query type is required.")]
        public Char QueryType { get; set; }
        [Required(ErrorMessage = "Query Name is required.")]

        public string QueryName { get; set; }
    }
}
