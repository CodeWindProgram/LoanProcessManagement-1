using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.Product.Commands.UpdateProductCommand
{
    public class UpdateProductCommand : IRequest<Response<UpdateProductCommandDto>>
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Product type is required.")]
        public string ProductType { get; set; }
        [Required(ErrorMessage = "Product name is required.")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Product description is required.")]
        public string ProducDescription { get; set; }
        public List<long> Schemes { get; set; }
        public bool IsActive { get; set; }

    }
}
