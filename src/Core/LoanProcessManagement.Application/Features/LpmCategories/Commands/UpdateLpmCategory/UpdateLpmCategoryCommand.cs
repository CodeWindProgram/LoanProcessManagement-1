using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.LpmCategories.Commands.UpdateLpmCategory
{
    public class UpdateLpmCategoryCommand : IRequest<Response<UpdateLpmCategoryCommandDto>>
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Category name is required.")]
        public string categoryName { get; set; }
        public bool IsActive { get; set; }
    }
}
