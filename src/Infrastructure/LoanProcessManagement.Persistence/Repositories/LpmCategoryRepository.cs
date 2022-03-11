using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.LpmCategories.Commands.CreateLpmCategory;
using LoanProcessManagement.Application.Features.LpmCategories.Commands.DeleteLpmCategory;
using LoanProcessManagement.Application.Features.LpmCategories.Commands.UpdateLpmCategory;
using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Persistence.Repositories
{
    public class LpmCategoryRepository : ILpmCategoryRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly ILogger<LpmCategoryRepository> _logger;
        public LpmCategoryRepository(ApplicationDbContext dbContext, ILogger<LpmCategoryRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;

        }

        public async Task<CreateLpmCategoryCommandDto> CreateLpmCategory(LpmCategory req)
        {
            CreateLpmCategoryCommandDto res = new CreateLpmCategoryCommandDto();
            var result = await _dbContext.LpmCategories.FirstOrDefaultAsync(x => x.categoryName == req.categoryName);
            if (result == null)
            {
                req.IsActive = true;
                await _dbContext.LpmCategories.AddAsync(req);
                await _dbContext.SaveChangesAsync();
                res.Message = "Category added successfully.";
                res.Succeeded = true;

            }
            else
            {
                res.Message = "Category already exists.";
                res.Succeeded = false;

            }
            return res;
        }

        public async Task<DeleteLpmCategoryCommandDto> DeleteLpmCategory(long id)
        {
            DeleteLpmCategoryCommandDto res = new DeleteLpmCategoryCommandDto();
            var result = await _dbContext.LpmCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                result.IsActive = false;
                //_dbContext.LpmBranchMasters.Remove(result);
                await _dbContext.SaveChangesAsync();
                res.Message = "Category removed successfully.";
                res.Succeeded = true;

            }
            else
            {
                res.Message = "Invalid Id.";
                res.Succeeded = false;
            }
            return res;
        }

        public async Task<IEnumerable<LpmCategory>> GetAllLpmCategories()
        {
            return await _dbContext.LpmCategories.ToListAsync();
        }

        public async Task<LpmCategory> GetLpmCategoryById(long id)
        {
            return await _dbContext.LpmCategories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UpdateLpmCategoryCommandDto> UpdateLpmCategory(UpdateLpmCategoryCommand req)
        {
            UpdateLpmCategoryCommandDto response = new UpdateLpmCategoryCommandDto();
            var result = await _dbContext.LpmCategories.FirstOrDefaultAsync(x => x.categoryName == req.categoryName && x.Id != req.Id);
            if (result != null)
            {
                response.Message = "Category already exists.";
                response.Succeeded = false;
                return response;

            }
            var categoryToUpdate = await _dbContext.LpmCategories.FirstOrDefaultAsync(x => x.Id == req.Id);

            if (categoryToUpdate != null)
            {
                categoryToUpdate.categoryName = req.categoryName;
                categoryToUpdate.IsActive = req.IsActive;
                await _dbContext.SaveChangesAsync();
                response.Message = "Category details updated successfully.";
                response.Succeeded = true;
                return response;

            }
            else
            {
                response.Message = "Invalid Id.";
                response.Succeeded = true;
                return response;
            }
        }
    }
}
