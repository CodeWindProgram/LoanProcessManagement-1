using LoanProcessManagement.Application.Features.LpmCategories.Commands.CreateLpmCategory;
using LoanProcessManagement.Application.Features.LpmCategories.Commands.DeleteLpmCategory;
using LoanProcessManagement.Application.Features.LpmCategories.Commands.UpdateLpmCategory;
using LoanProcessManagement.Application.Features.LpmCategories.Queries.GetAllCategories;
using LoanProcessManagement.Application.Features.LpmCategories.Queries.GetLpmCategoryById;
using LoanProcessManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface ILpmCategoryServices
    {
        Task<Response<IEnumerable<GetAllCategoriesQueryDto>>> GetAllLpmCategories();
        Task<Response<CreateLpmCategoryCommandDto>> AddLpmCategory(CreateLpmCategoryCommand req);
        Task<Response<DeleteLpmCategoryCommandDto>> DeleteLpmCategory(long id);
        Task<Response<GetLpmCategoryByIdCommandDto>> GetLpmCategoryById(long id);
        Task<Response<UpdateLpmCategoryCommandDto>> UpdateLpmCategory(UpdateLpmCategoryCommand req);





    }
}
