using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.LpmCategories.Commands.CreateLpmCategory
{
    public class CreateLpmCategoryCommand : IRequest<Response<CreateLpmCategoryCommandDto>>
    {
        [Required(ErrorMessage ="Category name is required.")]
        public string categoryName { get; set; }

    }
}
