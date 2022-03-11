using LoanProcessManagement.Application.Features.LpmCategories.Commands.CreateLpmCategory;
using LoanProcessManagement.Application.Features.LpmCategories.Commands.DeleteLpmCategory;
using LoanProcessManagement.Application.Features.LpmCategories.Commands.UpdateLpmCategory;
using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface ILpmCategoryRepository
    {
        Task<IEnumerable<LpmCategory>> GetAllLpmCategories();
        Task<CreateLpmCategoryCommandDto> CreateLpmCategory(LpmCategory req);
        Task<DeleteLpmCategoryCommandDto> DeleteLpmCategory(long id);
        Task<UpdateLpmCategoryCommandDto> UpdateLpmCategory(UpdateLpmCategoryCommand req);
        Task<LpmCategory> GetLpmCategoryById(long id);



    }
}
