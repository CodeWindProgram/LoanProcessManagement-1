using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Product.Commands.DeleteProductCommand
{
    public class DeleteProductCommandDto
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
