using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.SchemeMaster.Commands.CreateScheme;
using LoanProcessManagement.Application.Features.SchemeMaster.Commands.DeleteScheme;
using LoanProcessManagement.Application.Features.SchemeMaster.Commands.UpdateScheme;
using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Persistence.Repositories
{
    public class SchemeRepository : ISchemeRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public SchemeRepository(ApplicationDbContext dbContext, ILogger<SchemeRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<CreateSchemeCommandDto> CreateScheme(LpmLoanSchemeMaster request)
        {
            CreateSchemeCommandDto res = new CreateSchemeCommandDto();

            var result = await _dbContext.LpmLoanSchemeMasters.FirstOrDefaultAsync(x => x.SchemeName == request.SchemeName);
            if (result != null)
            {
                res.Message = "Scheme already exists.";
                res.Succeeded = false;
                return res;

            }
            else
            {
                request.IsActive = true;
                await _dbContext.LpmLoanSchemeMasters.AddAsync(request);
                await _dbContext.SaveChangesAsync();
                res.Message = "Scheme Added Successfully.";
                res.Succeeded = true;
                return res;
            }
        }

        public async Task<DeleteSchemeDto> DeleteScheme(long id)
        {
            DeleteSchemeDto res = new DeleteSchemeDto();
            var result = await _dbContext.LpmLoanSchemeMasters.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                result.IsActive = false;
                await _dbContext.SaveChangesAsync();
                res.Message = "Scheme removed successfully.";
                res.Succeeded = true;

            }
            else
            {
                res.Message = "Invalid Id.";
                res.Succeeded = false;
            }
            return res;
        }

        public async Task<IEnumerable<LpmLoanSchemeMaster>> GetAllScheme()
        {
            return await _dbContext.LpmLoanSchemeMasters.ToListAsync();
        }
        public async Task<LpmLoanSchemeMaster> GetSchemeById(long id)
        {
            return await _dbContext.LpmLoanSchemeMasters.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UpdateSchemeCommandDto> UpdateScheme(UpdateSchemeCommand req)
        {
            UpdateSchemeCommandDto response = new UpdateSchemeCommandDto();
            var result = await _dbContext.LpmLoanSchemeMasters.FirstOrDefaultAsync(x => x.SchemeName == req.SchemeName
            && x.Id != req.Id);
            if (result != null)
            {
                response.Message = "Scheme already exists.";
                response.Succeeded = false;
                return response;

            }
            var branchToUpdate = await _dbContext.LpmLoanSchemeMasters.FirstOrDefaultAsync(x => x.Id == req.Id);

            if (branchToUpdate != null)
            {
                branchToUpdate.SchemeName = req.SchemeName;
                branchToUpdate.IsActive = req.IsActive;
                await _dbContext.SaveChangesAsync();
                response.Message = "Scheme details updated successfully.";
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
